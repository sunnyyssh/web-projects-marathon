using System.ComponentModel.DataAnnotations;

namespace Quiz.Model;

public class QuestionInfo
{
    public long Id { get; init; }

    public string Question { get; init; } = string.Empty;
    
    public QuestionCorrectAnswer? CorrectAnswer { get; set; }
    
    [CollectionMinSize<string>(2)]
    public IReadOnlyList<string> Options { get; set; } = Array.Empty<string>();
}