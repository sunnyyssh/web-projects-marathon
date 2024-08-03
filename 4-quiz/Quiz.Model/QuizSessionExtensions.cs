namespace Quiz.Model;

public static class QuizSessionExtensions
{
    public static void GiveAnswer(this QuizSession session, QuestionInfo question, int answerIndex)
    {
        if (session.Quiz.Questions.All(q => q.Id != question.Id))
        {
            throw new InvalidOperationException("No such question in a quiz");
        }
        session.ChosenOptions[question.Id] = answerIndex;
    }

    public static bool IsAnswerGiven(this QuizSession session, QuestionInfo question)
    {
        return session.ChosenOptions.ContainsKey(question.Id);
    }
    
    public static QuizResult CalculateResult(this QuizSession session, QuizCorrectAnswers correctAnswers)
    {
         int answersCorrect = 0;
         int answersGiven = 0;
         foreach (var correctAnswer in correctAnswers.AnswersMap)
         {
             if (!session.ChosenOptions.TryGetValue(correctAnswer.QuestionId, out int? given)) 
                 continue;
             
             answersGiven++;
             if (given == correctAnswer.AnswerIndex)
             {
                 answersCorrect++;
             }
         }

         return new QuizResult
         {
             AnswersCorrect = answersCorrect,
             AnswersGiven = answersGiven,
             QuestionsCount = session.Quiz.Questions.Count
         };
    }
}