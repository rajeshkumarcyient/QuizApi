using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizAppApi.Data
{
    public class UserResponse
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ResponseId { get; set; }

        [Required]
        public int AttemptId { get; set; }

        [Required]
        public int QuestionId { get; set; }

        public int? SelectedOptionId { get; set; }

        public string? UserAnswerText { get; set; }

        public bool IsCorrect { get; set; } = false;

        public QuizAttempt QuizAttempt { get; set; } = null!;
        public Question Question { get; set; } = null!;
        public QuestionOption? SelectedOption { get; set; }

    }
}
