namespace Quiz.Model;

public class QuizInfo
{
    public long Id { get; set; }
    
    public required string Name { get; set; }
    
    public IReadOnlyList<QuestionInfo> Questions { get; set; } = Array.Empty<QuestionInfo>();
}