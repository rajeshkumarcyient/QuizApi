using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizAppApi.Data
{
    public class PasswordResetRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ResetId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public string ResetToken { get; set; } = string.Empty;

        [Required]
        public DateTime ExpiresAt { get; set; }
        public User User { get; set; } = null!;
      
    }
}
