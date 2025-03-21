﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuizAppApi.Data;

#nullable disable

namespace QuizAppApi.Migrations
{
    [DbContext(typeof(QuizDbContext))]
    partial class QuizDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("QuizAppApi.Data.PasswordResetRequest", b =>
                {
                    b.Property<int>("ResetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("ExpiresAt")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsUsed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("ResetToken")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ResetId");

                    b.HasIndex("UserId");

                    b.ToTable("PasswordResetRequests");
                });

            modelBuilder.Entity("QuizAppApi.Data.Question", b =>
                {
                    b.Property<int>("QuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("QuestionText")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("QuestionType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("QuizId")
                        .HasColumnType("int");

                    b.HasKey("QuestionId");

                    b.HasIndex("QuizId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("QuizAppApi.Data.QuestionOption", b =>
                {
                    b.Property<int>("OptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("OptionText")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.HasKey("OptionId");

                    b.HasIndex("QuestionId");

                    b.ToTable("QuestionOptions");
                });

            modelBuilder.Entity("QuizAppApi.Data.Quiz", b =>
                {
                    b.Property<int>("QuizId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<int>("DurationMinutes")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("QuizId");

                    b.HasIndex("CreatedBy");

                    b.ToTable("Quizzes");
                });

            modelBuilder.Entity("QuizAppApi.Data.QuizAttempt", b =>
                {
                    b.Property<int>("AttemptId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("AttemptedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("CorrectAnswers")
                        .HasColumnType("int");

                    b.Property<int>("QuizId")
                        .HasColumnType("int");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<int>("TotalQuestions")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("AttemptId");

                    b.HasIndex("QuizId");

                    b.HasIndex("UserId");

                    b.ToTable("QuizAttempts");
                });

            modelBuilder.Entity("QuizAppApi.Data.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("UserId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("QuizAppApi.Data.UserResponse", b =>
                {
                    b.Property<int>("ResponseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AttemptId")
                        .HasColumnType("int");

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<int?>("SelectedOptionId")
                        .HasColumnType("int");

                    b.Property<string>("UserAnswerText")
                        .HasColumnType("longtext");

                    b.HasKey("ResponseId");

                    b.HasIndex("AttemptId");

                    b.HasIndex("QuestionId");

                    b.HasIndex("SelectedOptionId");

                    b.ToTable("UserResponses");
                });

            modelBuilder.Entity("QuizAppApi.Data.PasswordResetRequest", b =>
                {
                    b.HasOne("QuizAppApi.Data.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("QuizAppApi.Data.Question", b =>
                {
                    b.HasOne("QuizAppApi.Data.Quiz", "Quiz")
                        .WithMany("Questions")
                        .HasForeignKey("QuizId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Quiz");
                });

            modelBuilder.Entity("QuizAppApi.Data.QuestionOption", b =>
                {
                    b.HasOne("QuizAppApi.Data.Question", "Question")
                        .WithMany("Options")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("QuizAppApi.Data.Quiz", b =>
                {
                    b.HasOne("QuizAppApi.Data.User", "User")
                        .WithMany("Quizzes")
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("QuizAppApi.Data.QuizAttempt", b =>
                {
                    b.HasOne("QuizAppApi.Data.Quiz", "Quiz")
                        .WithMany("QuizAttempts")
                        .HasForeignKey("QuizId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuizAppApi.Data.User", "User")
                        .WithMany("QuizAttempts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Quiz");

                    b.Navigation("User");
                });

            modelBuilder.Entity("QuizAppApi.Data.UserResponse", b =>
                {
                    b.HasOne("QuizAppApi.Data.QuizAttempt", "QuizAttempt")
                        .WithMany("UserResponses")
                        .HasForeignKey("AttemptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuizAppApi.Data.Question", "Question")
                        .WithMany("UserResponses")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuizAppApi.Data.QuestionOption", "SelectedOption")
                        .WithMany()
                        .HasForeignKey("SelectedOptionId");

                    b.Navigation("Question");

                    b.Navigation("QuizAttempt");

                    b.Navigation("SelectedOption");
                });

            modelBuilder.Entity("QuizAppApi.Data.Question", b =>
                {
                    b.Navigation("Options");

                    b.Navigation("UserResponses");
                });

            modelBuilder.Entity("QuizAppApi.Data.Quiz", b =>
                {
                    b.Navigation("Questions");

                    b.Navigation("QuizAttempts");
                });

            modelBuilder.Entity("QuizAppApi.Data.QuizAttempt", b =>
                {
                    b.Navigation("UserResponses");
                });

            modelBuilder.Entity("QuizAppApi.Data.User", b =>
                {
                    b.Navigation("QuizAttempts");

                    b.Navigation("Quizzes");
                });
#pragma warning restore 612, 618
        }
    }
}
