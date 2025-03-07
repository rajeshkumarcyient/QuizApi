using QuizAppApi.Data;
using QuizAppApi.DTO;

namespace QuizAppApi.Services
{
    public interface IUserService
    {
        Task<User> GetUserAsync(string email);
        Task<bool> RegisterUserAsync(UserDTO user);
    }
}
