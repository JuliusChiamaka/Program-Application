using AutoMapper;
using ProgramApplication.Data.Repositories;
using ProgramApplication.DTOs;
using ProgramApplication.Models;
using ProgramApplication.Services;

namespace ProgrammeApplication.Services
{
    public class ProgrammeService : IProgrammeService
    {
        private readonly IRepository<Programme> _ProgrammeRepository;
        private readonly IMapper _mapper;

        public ProgrammeService(IRepository<Programme> ProgrammeRepository, IMapper mapper)
        {
            _ProgrammeRepository = ProgrammeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProgrammeDto>> GetAllProgramsAsync()
        {
            var Programmes = await _ProgrammeRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProgrammeDto>>(Programmes);
        }

        public async Task<ProgrammeDto> GetProgramByIdAsync(Guid id)
        {
            var Programme = await _ProgrammeRepository.GetByIdAsync(id);
            return _mapper.Map<ProgrammeDto>(Programme);
        }

        public async Task<ProgrammeDto> AddProgramAsync(ProgrammeDto ProgrammeDto)
        {
            var Programme = _mapper.Map<Programme>(ProgrammeDto);
            Programme.Id = Guid.NewGuid();
            await _ProgrammeRepository.AddAsync(Programme);
            return _mapper.Map<ProgrammeDto>(Programme);
        }

        public async Task UpdateProgramAsync(ProgrammeDto ProgrammeDto)
        {
            var Programme = _mapper.Map<Programme>(ProgrammeDto);
            await _ProgrammeRepository.UpdateAsync(Programme);
        }

        public async Task DeleteProgramAsync(Guid id)
        {
            await _ProgrammeRepository.DeleteAsync(id);
        }

        
    }
}
