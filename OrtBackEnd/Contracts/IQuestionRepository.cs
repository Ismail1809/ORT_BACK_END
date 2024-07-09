using OrtBackEnd.Models;

namespace OrtBackEnd.Contracts
{
    public interface IQuestionRepository
    {
        //Task<IEnumerable<Question>> GetAllAsync();
        Task<List<Question>> GetByTestId(int testId);
        Task<Question> GetById(int id);
        Task<Question> AddAsync(Question question);
        Task UpdateAsync(Question question);
        Task DeleteAsync(int id);
    }
}
