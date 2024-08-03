namespace Quiz.Model;

public class QuestionInfo
{
    public long Id { get; init; }

    public string Question { get; init; } = string.Empty;

    public IReadOnlyList<string> Options { get; set; } = Array.Empty<string>();

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Question);
    }
}