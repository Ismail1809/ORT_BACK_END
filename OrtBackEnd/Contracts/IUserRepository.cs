using Microsoft.EntityFrameworkCore;
using OrtBackEnd.Models;

namespace OrtBackEnd.Contracts
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetById(int id);
        Task<User> AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(int Id);

    }
}
