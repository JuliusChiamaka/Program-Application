using ProgramApplication.DTOs;

namespace ProgramApplication.Services
{
    public interface IQuestionService
    {
        Task<IEnumerable<CustomQuestionDto>> GetAllQuestionsAsync();
        Task<CustomQuestionDto> GetQuestionByIdAsync(Guid id);
        Task<CustomQuestionDto> AddQuestionAsync(CustomQuestionDto questionDto);
        Task UpdateQuestionAsync(CustomQuestionDto questionDto);
        Task DeleteQuestionAsync(Guid id);

    }
}
