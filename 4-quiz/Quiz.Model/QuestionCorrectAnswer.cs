namespace Quiz.Model;

public class QuestionCorrectAnswer
{
    public long Id { get; set; }
    
    public required long QuestionId { get; init; }
    
    public QuestionInfo? QuestionInfo { get; set; }
    
    public required long AnswerIndex { get; init; }
}