namespace Quiz.Model;

public class QuizResult
{
    public required int AnswersCorrect { get; init; }

    public required int AnswersGiven { get; init; }
    
    public required int QuestionsCount { get; init; }
}