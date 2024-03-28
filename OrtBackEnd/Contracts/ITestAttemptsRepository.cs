using OrtBackEnd.Models;

namespace OrtBackEnd.Contracts
{
    public interface ITestAttemptsRepository
    {
        Task<IEnumerable<TestAttempt>> GetByUserId(int userId);
        Task<TestAttempt> GetById(int id);
        Task<TestAttempt> AddAsync(TestAttempt attempt);
        Task UpdateAsync(TestAttempt attempt);
        Task DeleteAsync(int id);
    }
}
