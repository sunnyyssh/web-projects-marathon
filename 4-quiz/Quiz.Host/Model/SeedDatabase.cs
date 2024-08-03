using Quiz.Model;

namespace Quiz.Host.Model;

public static class SeedDatabase
{
    public static QuizDbContext AddMarmaladeDemoQuiz(this QuizDbContext context)
    {
        if (context.Quizzes.Any())
        {
            return context;
        }

        var question = new QuestionInfo
        {
            Question = "The best marmalade",
            Options = new[] { "Haribo", "Bonpari" },
        };

        var correctAnswer = new QuestionCorrectAnswer
        {
            QuestionInfo = question,
            AnswerIndex = 1
        };

        var quiz = new QuizInfo
        {
            Name = "Marmalade history",
            Questions = new List<QuestionInfo> { question },
            CorrectAnswers = new QuizCorrectAnswers
            {
                AnswersMap = new List<QuestionCorrectAnswer> { correctAnswer }
            }
        };

        context.Quizzes.Add(quiz);
        context.SaveChanges();
        
        return context;
    }
}