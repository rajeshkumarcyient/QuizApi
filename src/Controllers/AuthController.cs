﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using QuizAppApi.Data;
using QuizAppApi.DTO;
using QuizAppApi.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace QuizAppApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IUserService _userService;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AuthController(IUserService userService, IPasswordHasher<User> passwordHasher,IConfiguration config)
        {
           _userService = userService;
           _passwordHasher = passwordHasher;
           _config = config;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userService.GetUserAsync(login.Email);
            if (user == null || _passwordHasher.VerifyHashedPassword(null, user.PasswordHash, login.Password) != PasswordVerificationResult.Success)
            {
                return Unauthorized(new { message = "Invalid email or password" });
            }

            var token = GenerateJwtToken(user.UserId, user.Email, user.Role);
            return Ok(new { token });

        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserDTO user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userService.RegisterUserAsync(user);
            if (!result)
            {
                return BadRequest(new { message = "Email already exists" });
            }

            return Ok(new { message = "User registered successfully" });
        }
       
        private string GenerateJwtToken(int userId, string username, string userRole)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["Jwt:Key"]);

            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, username),
                new(ClaimTypes.NameIdentifier, userId.ToString()),
                new(ClaimTypes.Role, userRole) 
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }

    public class LoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }

    }
}

