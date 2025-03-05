using QuizAppApi.Data;

namespace QuizAppApi.Services
{
    public interface IUserService
    {
        Task<User> GetUserAsync(string email);
        Task<bool> RegisterUserAsync(User user);
    }
}
