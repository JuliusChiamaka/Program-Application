using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgramApplication.DTOs;
using ProgramApplication.Services;

namespace ProgramApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationFormController : ControllerBase
    {
        private readonly IApplicationFormService _applicationFormService;

        public ApplicationFormController(IApplicationFormService applicationFormService)
        {
            _applicationFormService = applicationFormService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllApplicationForms()
        {
            var forms = await _applicationFormService.GetAllApplicationFormsAsync();
            return Ok(forms);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetApplicationFormById(Guid id)
        {
            var form = await _applicationFormService.GetApplicationFormByIdAsync(id);
            if (form == null)
                return NotFound();

            return Ok(form);
        }

        [HttpPost]
        public async Task<IActionResult> AddApplicationForm([FromBody] ApplicationFormDto formDto)
        {
            await _applicationFormService.AddApplicationFormAsync(formDto);
            return CreatedAtAction(nameof(GetApplicationFormById), formDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateApplicationForm(Guid id, [FromBody] ApplicationFormDto formDto)
        {
            var form = await _applicationFormService.GetApplicationFormByIdAsync(id);
            if (form == null)
                return NotFound();

            await _applicationFormService.UpdateApplicationFormAsync(formDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApplicationForm(Guid id)
        {
            var form = await _applicationFormService.GetApplicationFormByIdAsync(id);
            if (form == null)
                return NotFound();

            await _applicationFormService.DeleteApplicationFormAsync(id);
            return NoContent();
        }
    }
}
