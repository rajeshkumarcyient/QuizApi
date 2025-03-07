using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizAppApi.Data;
using QuizAppApi.DTO;
using QuizAppApi.Services;

namespace QuizAppApi.Controllers
{
    [Authorize(Roles = "Admin")]
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
        public async Task<IActionResult> CreateQuiz([FromBody] QuizDto quizDto)
        {
            Quiz quiz = new Quiz()
            {
               Title = quizDto.Title,
               Description = quizDto.Description,
               DurationMinutes = quizDto.DurationMinutes,
               CreatedAt = quizDto.CreatedAt,
               CreatedBy = quizDto.CreatedBy
            };

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
