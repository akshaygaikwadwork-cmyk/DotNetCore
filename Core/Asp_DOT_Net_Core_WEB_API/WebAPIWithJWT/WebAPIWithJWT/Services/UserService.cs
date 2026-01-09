using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebAPIWithJWT.Model;

namespace WebAPIWithJWT.Services
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        private readonly OurDbContext db;
        private readonly IConfiguration _configuration;

        public UserService(IOptions<AppSettings> appSettings, OurDbContext _db, IConfiguration configuration)
        {
            _appSettings = appSettings.Value;
            db = _db;
            _configuration = configuration;
        }

        public async Task<AuthenticateResponse?> Authenticate(AuthenticateRequest model)
        {
            var user = await db.tbl_UserForJWT.SingleOrDefaultAsync(x => x.UserName == model.UserName && x.Password == model.Password);

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = await generateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        public async Task<IEnumerable<UserModel>> GetAll()
        {
            return await db.tbl_UserForJWT.Where(x => x.IsActive == true).ToListAsync();
        }

        public async Task<UserModel?> GetById(int id)
        {
            return await db.tbl_UserForJWT.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<UserModel?> AddAndUpdateUser(UserModel userObj)
        {
            bool isSuccess = false;
            if (userObj.Id > 0)
            {
                var obj = await db.tbl_UserForJWT.FirstOrDefaultAsync(c => c.Id == userObj.Id);
                if (obj != null)
                {
                    // obj.Address = userObj.Address;
                    obj.FirstName = userObj.FirstName;
                    obj.LastName = userObj.LastName;
                    db.tbl_UserForJWT.Update(obj);
                    isSuccess = await db.SaveChangesAsync() > 0;
                }
            }
            else
            {
                await db.tbl_UserForJWT.AddAsync(userObj);
                isSuccess = await db.SaveChangesAsync() > 0;
            }

            return isSuccess ? userObj : null;
        }
        // helper methods
        private async Task<string> generateJwtToken(UserModel user)
        {
            //Generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = await Task.Run(() =>
            {

                var IssuerSigningKeyval = _configuration.GetValue<string>("JWT:Secret");
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(IssuerSigningKeyval)), SecurityAlgorithms.HmacSha256Signature)
                };
                return tokenHandler.CreateToken(tokenDescriptor);
            });

            return tokenHandler.WriteToken(token);
        }

    }
}
