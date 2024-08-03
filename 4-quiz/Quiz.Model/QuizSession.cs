namespace Quiz.Model;

public class QuizSession
{
    public required QuizInfo Quiz { get; init; }

    public IDictionary<long, int?> ChosenOptions { get; } = new Dictionary<long, int?>();
}