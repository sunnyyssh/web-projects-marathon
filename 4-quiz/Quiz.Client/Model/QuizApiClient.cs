using System.Net.Http.Json;
using Quiz.Model;

namespace Quiz.Client.Model;

public class QuizApiClient(HttpClient httpClient) : IQuizClient
{
    public async Task<QuizInfo[]> GetAllQuizzesAsync()
    {
        return await httpClient.GetFromJsonAsync<QuizInfo[]>("api/quiz/all") ?? Array.Empty<QuizInfo>();
    }

    public async Task<QuizInfo?> GetQuizAsync(long id)
    {
        return await httpClient.GetFromJsonAsync<QuizInfo>($"api/quiz/{id}");
    }

    public async Task<QuizCorrectAnswers?> GetCorrectAnswersAsync(long quizId)
    {
        return await httpClient.GetFromJsonAsync<QuizCorrectAnswers?>($"api/quiz/answer/{quizId}");
    }

    public async Task<bool> CreateQuizAsync(QuizInfo quiz)
    {
        var result = await httpClient.PostAsJsonAsync("api/quiz/create", quiz);
        return result.IsSuccessStatusCode;
    }
}