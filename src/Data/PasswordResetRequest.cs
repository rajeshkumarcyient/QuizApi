using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizAppApi.Data
{
    public class PasswordResetRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ResetId { get; set; }

        [Required, ForeignKey("User")]
        public int UserId { get; set; }

        [Required, MaxLength(255)]
        public string ResetToken { get; set; } = string.Empty;

        [Required]
        public DateTime ExpiresAt { get; set; }

        [Required]
        public bool IsUsed { get; set; } = false;

        public User User { get; set; } = null!;
    }
}
