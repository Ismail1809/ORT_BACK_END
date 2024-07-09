using Microsoft.EntityFrameworkCore;
using OrtBackEnd.Contracts;
using OrtBackEnd.Models;

namespace OrtBackEnd.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly DatabaseContext.DatabaseContext _context;

        public QuestionRepository(DatabaseContext.DatabaseContext context)
        {
            _context = context;
        }

        //public async Task<IEnumerable<Question>> GetAllAsync()
        //{
        //    return await _context.Questions.ToListAsync();
        //}

        public async Task<Question> GetById(int id)
        {
            return await _context.Questions.FindAsync(id);
        }

        public async Task<List<Question>> GetByTestId(int testId)
        {
            return await _context.Questions.Where(x => x.TestId == testId).ToListAsync();
        }

        public async Task<Question> AddAsync(Question question)
        {
            await _context.Questions.AddAsync(question);
            await _context.SaveChangesAsync();
            return question;

        }

        public async Task UpdateAsync(Question updateQuestion)
        {

            if (updateQuestion != null)
            {
                _context.Questions.Entry(updateQuestion).State = EntityState.Modified;
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Question question = await _context.Questions.FindAsync(id);

            if (question != null)
            {
                //This will mark the Entity State as Deleted
                _context.Questions.Remove(question);
            }

            await _context.SaveChangesAsync();
        }
    }
}
