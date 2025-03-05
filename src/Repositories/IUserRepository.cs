using QuizAppApi.Data;

namespace QuizAppApi.Repositories
{
    public interface IUserRepository
    {
            Task<User> GetUserByEmailAsync(string email);
            Task AddUserAsync(User user);

    }
}
