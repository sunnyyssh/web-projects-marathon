using System.ComponentModel.DataAnnotations;

namespace Quiz.Model;

public class QuizInfo
{
    public long Id { get; set; }
    
    public required string Name { get; set; }
    
    public QuizCorrectAnswers? CorrectAnswers { get; set; }
    
    [CollectionMinSize<QuestionInfo>(1)]
    public List<QuestionInfo> Questions { get; set; } = new();
}