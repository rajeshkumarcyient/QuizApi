﻿namespace QuizAppApi.DTO
{
    public class UserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }  // If needed for login/registration
        public string Role { get; set; }
    }
}
