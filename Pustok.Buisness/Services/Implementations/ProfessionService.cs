using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pustok.Buisness.Dtos.ProfessionDtos;
using Pustok.Buisness.Exceptions;
using Pustok.Buisness.Services.Abstractions;
using Pustok.Core.Entities;
using Pustok.DataAccess.Repositories.Abstractions;

namespace Pustok.Buisness.Services.Implementations
{
    public class ProfessionService : IProfessionService
    {
        private readonly IMapper _mapper;
        private readonly IProfessionRepository _repository;
        private readonly ICloudinaryService _cloudinaryService;

        public ProfessionService(IMapper mapper, IProfessionRepository repository, ICloudinaryService cloudinaryService)
        {
            _mapper = mapper;
            _repository = repository;
            _cloudinaryService = cloudinaryService;
        }

        public async Task CreateAsync(ProfessionCreateDto dto)
        {
            var profession = _mapper.Map<Profession>(dto);

            await _repository.AddAsync(profession);

            await _repository.SaveChangeAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var profession = await _repository.GetByIdAsync(id);

            if (profession is null)
                throw new NotFoundException();

            _repository.Delete(profession);
            await _repository.SaveChangeAsync();

        }

        public async Task<List<ProfessionGetDto>> GetAllAsync()
        {
            var professions = await _repository.GetAll().ToListAsync();

            var dtos = _mapper.Map<List<ProfessionGetDto>>(professions);

            return dtos;

        }

        public async Task<ProfessionGetDto?> GetById(Guid id)
        {
            var profession = await _repository.GetByIdAsync(id);

            if(profession is null)
                throw new NotFoundException();

            var dto = _mapper.Map<ProfessionGetDto>(profession);

            return dto;

        }

        public async Task UpdateAsync(ProfessionUpdateDto dto)
        {
            var profession = await _repository.GetByIdAsync(dto.Id);

            if (profession is null)
                throw new NotFoundException();

            _mapper.Map(dto, profession);

            _repository.Update(profession);
            await _repository.SaveChangeAsync();

        }
    }
}
