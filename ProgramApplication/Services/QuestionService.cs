using AutoMapper;
using ProgramApplication.Data.Repositories;
using ProgramApplication.DTOs;
using ProgramApplication.Models;

namespace ProgramApplication.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IRepository<CustomQuestion> _questionRepository;
        private readonly IMapper _mapper;

        public QuestionService(IRepository<CustomQuestion> questionRepository, IMapper mapper)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomQuestionDto>> GetAllQuestionsAsync()
        {
            var questions = await _questionRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CustomQuestionDto>>(questions);
        }

        public async Task<CustomQuestionDto> GetQuestionByIdAsync(Guid id)
        {
            var question = await _questionRepository.GetByIdAsync(id);
            return _mapper.Map<CustomQuestionDto>(question);
        }

        public async Task<CustomQuestionDto> AddQuestionAsync(CustomQuestionDto questionDto)
        {
            var question = _mapper.Map<CustomQuestion>(questionDto);
            question.Id = Guid.NewGuid();
            await _questionRepository.AddAsync(question);
            return _mapper.Map<CustomQuestionDto>(question);
        }

        public async Task UpdateQuestionAsync(CustomQuestionDto questionDto)
        {
            var question = _mapper.Map<CustomQuestion>(questionDto);
            await _questionRepository.UpdateAsync(question);
        }

        public async Task DeleteQuestionAsync(Guid id)
        {
            await _questionRepository.DeleteAsync(id);
        }
    }
}
