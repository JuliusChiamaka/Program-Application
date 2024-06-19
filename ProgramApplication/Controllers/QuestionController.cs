using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgramApplication.DTOs;
using ProgramApplication.Services;

namespace ProgramApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllQuestions()
        {
            var questions = await _questionService.GetAllQuestionsAsync();
            return Ok(questions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestionById(Guid id)
        {
            var question = await _questionService.GetQuestionByIdAsync(id);
            if (question == null)
                return NotFound();

            return Ok(question);
        }

        [HttpPost]
        public async Task<IActionResult> AddQuestion([FromBody] CustomQuestionDto questionDto)
        {
            await _questionService.AddQuestionAsync(questionDto);
            return CreatedAtAction(nameof(GetQuestionById), questionDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuestion(Guid id, [FromBody] CustomQuestionDto questionDto)
        {
            var question = await _questionService.GetQuestionByIdAsync(id);
            if (question == null)
                return NotFound();

            await _questionService.UpdateQuestionAsync(questionDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(Guid id)
        {
            var question = await _questionService.GetQuestionByIdAsync(id);
            if (question == null)
                return NotFound();

            await _questionService.DeleteQuestionAsync(id);
            return NoContent();
        }
    }
}
