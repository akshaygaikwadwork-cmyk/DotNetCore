using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TokenBasedAuth.Data;
using TokenBasedAuth.Model;

namespace TokenBasedAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly ApplicationDbContext _context;
        public readonly IConfiguration _configuration;

        public UserController(ApplicationDbContext _context, IConfiguration _configuration)
        {
            this._context = _context;
            this._configuration = _configuration;

        }

        [Authorize]
        [HttpGet("UserId")]
        public IActionResult GetUserById(int Id)
        {
            Users? user = _context.users.Where(u=>u.UserId == Id).FirstOrDefault();
            return Ok(user);
        }


        [HttpPost]
        public IActionResult Login(TokenUser user)
        {
            Users data = _context.users.Where(u => u.UserEmail == user.UserEmail).FirstOrDefault();

            if (data == null)
            {
                return Unauthorized("Invalid credentials");
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, data.UserEmail),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(2),
                signingCredentials: creds
            );

            var tokenData = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(new
            {
                Token = tokenData,
                User = data
            });
        }
    }
}
