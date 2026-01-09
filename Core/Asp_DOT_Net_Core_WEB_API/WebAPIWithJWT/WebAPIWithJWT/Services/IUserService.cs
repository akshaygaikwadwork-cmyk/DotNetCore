using WebAPIWithJWT.Model;

namespace WebAPIWithJWT.Services
{
    public interface IUserService
    {
        Task<AuthenticateResponse?> Authenticate(AuthenticateRequest model);
        Task<IEnumerable<UserModel>> GetAll();
        Task<UserModel?> GetById(int id);
        Task<UserModel?> AddAndUpdateUser(UserModel userObj);
    }
}
