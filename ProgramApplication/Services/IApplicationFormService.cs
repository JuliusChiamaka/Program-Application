using ProgramApplication.DTOs;

namespace ProgramApplication.Services
{
    public interface IApplicationFormService
    {
        Task<IEnumerable<ApplicationFormDto>> GetAllApplicationFormsAsync();
        Task<ApplicationFormDto> GetApplicationFormByIdAsync(Guid id);
        Task<ApplicationFormDto> AddApplicationFormAsync(ApplicationFormDto formDto);
        Task UpdateApplicationFormAsync(ApplicationFormDto formDto);
        Task DeleteApplicationFormAsync(Guid id);
    }
}
