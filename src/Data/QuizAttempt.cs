using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizAppApi.Data
{
    public class QuizAttempt
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AttemptId { get; set; }

        [Required, ForeignKey("User")]
        public int UserId { get; set; }

        [Required, ForeignKey("Quiz")]
        public int QuizId { get; set; }

        [Required]
        public int Score { get; set; } = 0;

        [Required]
        public int TotalQuestions { get; set; }

        [Required]
        public int CorrectAnswers { get; set; } = 0;

        public DateTime AttemptedAt { get; set; } = DateTime.UtcNow;

        public User User { get; set; } = null!;
        public Quiz Quiz { get; set; } = null!;
        public ICollection<UserResponse> UserResponses { get; set; } = new List<UserResponse>();
        
    }
}
