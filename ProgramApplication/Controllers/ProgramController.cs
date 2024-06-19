using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgramApplication.DTOs;
using ProgramApplication.Services;

namespace ProgramApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProgramController : ControllerBase
    {
        private readonly IProgrammeService _programService;

        public ProgramController(IProgrammeService programService)
        {
            _programService = programService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPrograms()
        {
            var programs = await _programService.GetAllProgramsAsync();
            return Ok(programs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProgramById(Guid id)
        {
            var program = await _programService.GetProgramByIdAsync(id);
            if (program == null)
                return NotFound();

            return Ok(program);
        }

        [HttpPost]
        public async Task<IActionResult> AddProgram([FromBody] ProgrammeDto programDto)
        {
            var createdProgram = await _programService.AddProgramAsync(programDto);
            return CreatedAtAction(nameof(GetProgramById), createdProgram);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProgram(Guid id, [FromBody] ProgrammeDto programDto)
        {
            var program = await _programService.GetProgramByIdAsync(id);
            if (program == null)
                return NotFound();

            await _programService.UpdateProgramAsync(programDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProgram(Guid id)
        {
            var program = await _programService.GetProgramByIdAsync(id);
            if (program == null)
                return NotFound();

            await _programService.DeleteProgramAsync(id);
            return NoContent();
        }
    }
}
