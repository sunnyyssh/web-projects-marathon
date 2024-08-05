namespace Quiz.Model;

public class QuizCorrectAnswers
{
    public int Id { get; set; }
    
    public long QuizId { get; set; }
    
    public QuizInfo? Quiz { get; set; }

    [CollectionMinSize<QuestionCorrectAnswer>(1)]
    public List<QuestionCorrectAnswer> AnswersMap { get; set; } = new();
}