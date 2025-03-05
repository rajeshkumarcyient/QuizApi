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
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; } = string.Empty; 
        
        [Required]
        [EmailAddress]
        [MaxLength(255)]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        [Required]
        public string Role { get; set; } = "User";

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public ICollection<Quiz> Quizzes { get; set; } = new List<Quiz>();
        public ICollection<QuizAttempt> QuizAttempts { get; set; } = new List<QuizAttempt>();
    }
}
