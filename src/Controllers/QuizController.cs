using AutoMapper;
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
        private readonly IMapper _mapper;

        public QuizController(IQuizService quizService, IMapper mapper)
        {
            _quizService = quizService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllQuizzes()
        {
            var quizzes = await _quizService.GetQuizzesAsync();

            var quizDtoList = _mapper.Map<List<QuizDto>>(quizzes);

            return Ok(quizDtoList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuiz(int id)
        {
            var quiz = await _quizService.GetQuizByIdAsync(id);
            if (quiz == null)
                return NotFound();
            var quizDto = _mapper.Map<QuizDto>(quiz);
            return Ok(quizDto);
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
        public async Task<IActionResult> UpdateQuiz(int id, [FromBody] QuizDto quizDto)
        {
            if (id == 0)
                return BadRequest();

            Quiz quiz = new()
            {
                QuizId = id,
                Title = quizDto.Title,
                Description = quizDto.Description,
                DurationMinutes = quizDto.DurationMinutes,
                CreatedBy = quizDto.CreatedBy
            };

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
