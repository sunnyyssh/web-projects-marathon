using Microsoft.EntityFrameworkCore;
using Quiz.Model;

namespace Quiz.Host.Model;

public class QuizDbContext(DbContextOptions<QuizDbContext> options) : DbContext(options)
{
    public DbSet<QuestionInfo> Questions => Set<QuestionInfo>();

    public DbSet<QuizInfo> Quizzes => Set<QuizInfo>();

    public DbSet<QuestionCorrectAnswer> QuestionCorrectAnswers => Set<QuestionCorrectAnswer>();

    public DbSet<QuizCorrectAnswers> QuizCorrectAnswers => Set<QuizCorrectAnswers>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<QuizInfo>()
            .HasMany<QuestionInfo>(nameof(QuizInfo.Questions));

        modelBuilder.Entity<QuizCorrectAnswers>()
            .HasMany<QuestionCorrectAnswer>(nameof(Quiz.Model.QuizCorrectAnswers.AnswersMap));

        modelBuilder.Entity<QuizCorrectAnswers>()
            .HasOne<QuizInfo>(a => a.Quiz)
            .WithOne(q => q.CorrectAnswers)
            .HasForeignKey<QuizCorrectAnswers>(a => a.QuizId);
        
        modelBuilder.Entity<QuestionCorrectAnswer>()
            .HasOne<QuestionInfo>(a => a.QuestionInfo)
            .WithOne(q => q.CorrectAnswer)
            .HasForeignKey<QuestionCorrectAnswer>(a => a.QuestionId);
    }
}