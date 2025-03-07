using QuizAppApi.DTO;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuizAppApi.Data
{
    public class User
    {
        [Key]  // Marks UserId as Primary Key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  // Auto-increment
        public int UserId { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }
        
        [Required]
        [EmailAddress]
        [MaxLength(255)]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        public string Role { get; set; } = "User";

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Quiz> Quizzes { get; set; }
        public ICollection<QuizAttempt> QuizAttempts { get; set; }
    }
}
