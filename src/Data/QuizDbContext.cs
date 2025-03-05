using Microsoft.EntityFrameworkCore;
using QuizAppApi.DTO;

namespace QuizAppApi.Data
{
    public class QuizDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionOption> QuestionOptions { get; set; }
        public DbSet<QuizAttempt> QuizAttempts { get; set; }
        public DbSet<UserResponse> UserResponses { get; set; }
        public DbSet<PasswordResetRequest> PasswordResetRequests { get; set; }

        public QuizDbContext(DbContextOptions<QuizDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
              .HasIndex(u => u.Email)
              .IsUnique();

            modelBuilder.Entity<QuizAttempt>()
                .HasIndex(qa => qa.UserId);

            modelBuilder.Entity<UserResponse>()
                .HasIndex(ur => ur.AttemptId);

        }
    }
}
