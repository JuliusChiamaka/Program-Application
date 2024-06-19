using ProgramApplication.DTOs;

namespace ProgramApplication.Services
{
    public interface IProgrammeService
    {
        Task<IEnumerable<ProgrammeDto>> GetAllProgramsAsync();
        Task<ProgrammeDto> GetProgramByIdAsync(Guid id);
        Task<ProgrammeDto> AddProgramAsync(ProgrammeDto programDto);
        Task UpdateProgramAsync(ProgrammeDto programDto);
        Task DeleteProgramAsync(Guid id);
    }
}
