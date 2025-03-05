
using QuizAppApi.Data;

namespace QuizAppApi.Repositories
{
    public interface IQuizRepository
    {
        Task<IEnumerable<Quiz>> GetQuizzesAsync();
        Task<Quiz> GetQuizByIdAsync(int id);
        Task AddQuizAsync(Quiz quiz);
        Task UpdateQuizAsync(Quiz quiz);
        Task DeleteQuizAsync(int id);
    }
}
