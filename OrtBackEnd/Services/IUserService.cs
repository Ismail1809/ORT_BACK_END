using OrtBackEnd.Controllers.RequestsAndResponses.UserExchanges;
namespace OrtBackEnd.Services
{
    public interface IUserService
    {
        string Login(UserLoginRequest user);
        Task<UserResponse> RegisterAsync(UserRegisterRequest user);
    }
}
