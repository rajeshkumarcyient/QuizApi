using Microsoft.AspNetCore.Identity;
using QuizAppApi.Data;
using QuizAppApi.DTO;
using QuizAppApi.Repositories;

namespace QuizAppApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;

        public UserService(IUserRepository userRepository, IPasswordHasher<User> passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<User> GetUserAsync(string email)
        {
            return await _userRepository.GetUserByEmailAsync(email);
        }

        public async Task<bool> RegisterUserAsync(UserDTO user)
        {
            var existingUser = await _userRepository.GetUserByEmailAsync(user.Email);
            if (existingUser != null)
            {
                return false; // Email already exists
            }

            var newUser = new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PasswordHash = _passwordHasher.HashPassword(null, user.PasswordHash), // Hashing password
                Role = user.Role,
                CreatedAt = DateTime.Now
            };

            await _userRepository.AddUserAsync(newUser);
            return true;
        }

    }
}
