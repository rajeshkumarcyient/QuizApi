using Microsoft.EntityFrameworkCore;
using QuizAppApi.Data;

namespace QuizAppApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly QuizDbContext _context;

        public UserRepository(QuizDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}
