using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quiz.Host.Model;
using Quiz.Model;

namespace Quiz.Host.Controllers;

[ApiController]
[Route("/api/quiz")]
public class QuizApiController(QuizDbContext quizContext) : ControllerBase
{
    [HttpGet("all")]
    public async Task<QuizInfo[]> GetQuizzes()
    {
        return await quizContext.Quizzes.ToArrayAsync();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetQuiz(long id)
    {
        var quiz = await quizContext.Quizzes
            .Include(quiz => quiz.Questions)
            .FirstOrDefaultAsync(quiz => quiz.Id == id);

        return quiz is null ? NotFound() : Ok(quiz);
    }

    [HttpGet("answer/{quizId}")]
    public async Task<IActionResult> GetQuizAnswer(long quizId)
    {
        var answer = await quizContext.QuizCorrectAnswers
            .Where(ans => ans.QuizId == quizId)
            .Include(quizAnswers => quizAnswers.AnswersMap)
            .FirstOrDefaultAsync();
        
        return answer is null ? NotFound() : Ok(answer);
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateQuiz([FromBody] QuizInfo quiz)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        quizContext.Quizzes.Add(quiz);
        await quizContext.SaveChangesAsync();
        return Ok();
    }
}