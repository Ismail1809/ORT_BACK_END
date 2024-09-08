using OrtBackEnd.Controllers.RequestsAndResponses.UserExchanges;
using OrtBackEnd.Models;
namespace OrtBackEnd.Services
{
    public interface IUserService
    {
        string Login(UserLoginRequest user);
        Task<UserResponse> RegisterAsync(UserRegisterRequest user);
        Task<User> GetUser(int id);
        Task<IEnumerable<User>> GetUsers();
        Task UpdateAsync(User existingUser);
        Task DeleteAsync(int id);
    }
}
