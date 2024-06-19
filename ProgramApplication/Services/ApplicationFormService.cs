using AutoMapper;
using ProgramApplication.Data.Repositories;
using ProgramApplication.DTOs;
using ProgramApplication.Models;

namespace ProgramApplication.Services
{
    public class ApplicationFormService : IApplicationFormService
    {
        private readonly IRepository<ApplicationForm> _applicationFormRepository;
        private readonly IMapper _mapper;

        public ApplicationFormService(IRepository<ApplicationForm> applicationFormRepository, IMapper mapper)
        {
            _applicationFormRepository = applicationFormRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ApplicationFormDto>> GetAllApplicationFormsAsync()
        {
            var forms = await _applicationFormRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ApplicationFormDto>>(forms);
        }

        public async Task<ApplicationFormDto> GetApplicationFormByIdAsync(Guid id)
        {
            var form = await _applicationFormRepository.GetByIdAsync(id);
            return _mapper.Map<ApplicationFormDto>(form);
        }

        public async Task<ApplicationFormDto> AddApplicationFormAsync(ApplicationFormDto formDto)
        {
            var form = _mapper.Map<ApplicationForm>(formDto);
            form.Id = Guid.NewGuid();
            form.CustomQuestions.ForEach(q => q.Id = Guid.NewGuid());
            await _applicationFormRepository.AddAsync(form);
            return _mapper.Map<ApplicationFormDto>(form);
        }

        public async Task UpdateApplicationFormAsync(ApplicationFormDto formDto)
        {
            var form = _mapper.Map<ApplicationForm>(formDto);
            await _applicationFormRepository.UpdateAsync(form);
        }

        public async Task DeleteApplicationFormAsync(Guid id)
        {
            await _applicationFormRepository.DeleteAsync(id);
        }
    }
}
