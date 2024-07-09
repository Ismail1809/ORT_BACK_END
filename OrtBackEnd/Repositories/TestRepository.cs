using Microsoft.EntityFrameworkCore;
using OrtBackEnd.Contracts;
using OrtBackEnd.Controllers.RequestsAndResponses.TestAttemptsExchanges;
using OrtBackEnd.DatabaseContext;
using OrtBackEnd.Models;

namespace OrtBackEnd.Repositories
{
    public class TestRepository: ITestRepository
    {
        private readonly DatabaseContext.DatabaseContext _context;

        public TestRepository(DatabaseContext.DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Test>> GetAllAsync()
        {
            return await _context.Tests.ToListAsync();
        }

        public async Task<Test> GetById(int id)
        {
            if (id == null)
            {
                return null;
            }

            return await _context.Tests.FindAsync(id);
        }

        public async Task<List<TestAttemptResultResponse>> GetResult(int id)
        {
            if (id == null)
            {
                return null;
            }

            return await _context.TestAttempts.Where(x => x.TestId == id).Select(scores => new TestAttemptResultResponse{ Score = scores.Score, UserId = scores.UserId}).ToListAsync();
        }

        public async Task<Test> AddAsync(Test test)
        {
            await _context.Tests.AddAsync(test);
            await _context.SaveChangesAsync();
            return test;
        }

        public async Task UpdateAsync(Test test)
        {
            if (test != null)
            {
                _context.Tests.Entry(test).State = EntityState.Modified;
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Test test = await _context.Tests.FindAsync(id);

            if (test != null)
            {
                //This will mark the Entity State as Deleted
                _context.Tests.Remove(test);
            }

            await _context.SaveChangesAsync();
        }


        public async Task<Test> GetRandomTest()
        {
            if (_context.Tests.Count() == 0)
            {
                return null;
            }
            

            return _context.Tests.OrderBy(x => Guid.NewGuid()).First(); 
        }
    }
}
