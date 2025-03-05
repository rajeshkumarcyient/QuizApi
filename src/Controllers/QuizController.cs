using Microsoft.AspNetCore.Mvc;
using QuizAppApi.Data;
using QuizAppApi.Services;

namespace QuizAppApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly IQuizService _quizService;

        public QuizController(IQuizService quizService)
        {
            _quizService = quizService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllQuizzes()
        {
            var quizzes = await _quizService.GetQuizzesAsync();
            return Ok(quizzes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuiz(int id)
        {
            var quiz = await _quizService.GetQuizByIdAsync(id);
            if (quiz == null)
                return NotFound();
            return Ok(quiz);
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuiz([FromBody] Quiz quiz)
        {
            await _quizService.AddQuizAsync(quiz);
            return CreatedAtAction(nameof(GetQuiz), new { id = quiz.QuizId }, quiz);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuiz(int id, [FromBody] Quiz quiz)
        {
            if (id != quiz.QuizId)
                return BadRequest();

            await _quizService.UpdateQuizAsync(quiz);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuiz(int id)
        {
            await _quizService.DeleteQuizAsync(id);
            return NoContent();
        }
    }
}
