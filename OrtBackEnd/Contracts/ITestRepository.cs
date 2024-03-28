using Microsoft.EntityFrameworkCore;
using OrtBackEnd.Controllers.RequestsAndResponses.TestAttemptsExchanges;
using OrtBackEnd.Models;

namespace OrtBackEnd.Contracts
{
    public interface ITestRepository
    {
        Task<IEnumerable<Test>> GetAllAsync();
        Task<Test> GetById(int id);
        Task<List<TestAttemptResultResponse>> GetResult(int id);
        Task<Test> AddAsync(Test user);
        Task UpdateAsync(Test test);
        Task DeleteAsync(int Id);
        Task<Test> GetRandomTest();
    }
}
