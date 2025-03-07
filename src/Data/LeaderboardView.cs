using System.ComponentModel.DataAnnotations.Schema;

namespace QuizAppApi.Data
{
    [NotMapped]
    public class LeaderboardView
    {
        public int UserId { get; set; }
        public int QuizId { get; set; }
        public string UserName { get; set; }
        public string QuizTitle { get; set; }
        public int Score { get; set; }
        public int TotalQuestions { get; set; }
        public int CorrectAnswers { get; set; }
        public int Rank { get; set; }
    }

}
