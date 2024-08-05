using Quiz.Model;

namespace Quiz.Client.Model;

public interface IQuizClient
{
    Task<QuizInfo[]> GetAllQuizzesAsync();

    Task<QuizInfo?> GetQuizAsync(long id);

    Task<QuizCorrectAnswers?> GetCorrectAnswersAsync(long quizId);

    Task<bool> CreateQuizAsync(QuizInfo quiz);
}