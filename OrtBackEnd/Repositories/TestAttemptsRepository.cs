using Microsoft.EntityFrameworkCore;
using OrtBackEnd.Contracts;
using OrtBackEnd.Models;
using OrtBackEnd.DbContent;

namespace OrtBackEnd.Repositories
{
    public class TestAttemptsRepository : ITestAttemptsRepository
    {
        private readonly DatabaseContext _context;

        public TestAttemptsRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TestAttempt>> GetByUserId(int userId)
        {
            return await _context.TestAttempts.Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task<TestAttempt> GetById(int id)
        {
            return await _context.TestAttempts.FindAsync(id);
        }

        public async Task<TestAttempt> AddAsync(TestAttempt attempt)
        {
            await _context.TestAttempts.AddAsync(attempt);
            await _context.SaveChangesAsync();
            return attempt;

        }

        public async Task UpdateAsync(TestAttempt updateAttempt)
        {

            if (updateAttempt != null)
            {
                _context.TestAttempts.Entry(updateAttempt).State = EntityState.Modified;
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            TestAttempt attempt = await _context.TestAttempts.FindAsync(id);

            if (attempt != null)
            {
                //This will mark the Entity State as Deleted
                _context.TestAttempts.Remove(attempt);
            }

            await _context.SaveChangesAsync();
        }
    }
}
