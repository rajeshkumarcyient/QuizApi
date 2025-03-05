using QuizAppApi.Data;
using QuizAppApi.DTO;
using QuizAppApi.Repositories;

namespace QuizAppApi.Services
{
    public class QuizService : IQuizService
    {
        private readonly IQuizRepository _repository;

        public QuizService(IQuizRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Quiz>> GetQuizzesAsync() => _repository.GetQuizzesAsync();

        public Task<Quiz> GetQuizByIdAsync(int id) => _repository.GetQuizByIdAsync(id);

        public Task AddQuizAsync(Quiz quiz) => _repository.AddQuizAsync(quiz);

        public Task UpdateQuizAsync(Quiz quiz) => _repository.UpdateQuizAsync(quiz);

        public Task DeleteQuizAsync(int id) => _repository.DeleteQuizAsync(id);
    }
}
