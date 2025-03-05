using Microsoft.EntityFrameworkCore;
using QuizAppApi.Data;
using QuizAppApi.DTO;

namespace QuizAppApi.Repositories
{
    public class QuizRepository : IQuizRepository
    {
        private readonly QuizDbContext _context;

        public QuizRepository(QuizDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Quiz>> GetQuizzesAsync()
        {
            return await _context.Quizzes.ToListAsync();
        }

        public async Task<Quiz> GetQuizByIdAsync(int id)
        {
            return await _context.Quizzes.FindAsync(id);
        }

        public async Task AddQuizAsync(Quiz quiz)
        {
            _context.Quizzes.Add(quiz);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateQuizAsync(Quiz quiz)
        {
            _context.Quizzes.Update(quiz);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteQuizAsync(int id)
        {
            var quiz = await _context.Quizzes.FindAsync(id);
            if (quiz != null)
            {
                _context.Quizzes.Remove(quiz);
                await _context.SaveChangesAsync();
            }
        }
    }
}
