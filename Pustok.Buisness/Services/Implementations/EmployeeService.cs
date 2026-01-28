using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pustok.Buisness.Exceptions;
using Pustok.Buisness.Services.Abstractions;
using Pustok.Core.Entities;
using Pustok.DataAccess.Repositories;
using Pustok.DataAccess.Repositories.Abstractions;

namespace Pustok.Buisness.Services.Implementations
{
    internal class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;
        private readonly IProfessionRepository _professionRepository;
        private readonly IMapper _mapper;
        private readonly ICloudinaryService _cloudinaryService;

        public EmployeeService(IEmployeeRepository repository, IMapper mapper, ICloudinaryService cloudinaryService, IProfessionRepository professionRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _cloudinaryService = cloudinaryService;
            _professionRepository = professionRepository;
        }

        public async Task<ResultDto> CreateAsync(EmployeeCreateDto dto)
        {
            var isExistProfession = await _professionRepository.AnyAsync(x => x.Id == dto.ProfessionId);

            if (!isExistProfession)
                throw new NotFoundException("Doesn't find profession id");

            var employee = _mapper.Map<Employee>(dto);

            var imagePath = await _cloudinaryService.FileUploadAsync(dto.Image);
            employee.ImagePath = imagePath;

            await _repository.AddAsync(employee);
            await _repository.SaveChangeAsync();

            return new ResultDto();
        }

        public async Task<ResultDto> DeleteAsync(Guid id)
        {
            var employee = await _repository.GetByIdAsync(id);

            if (employee is null)
                throw new NotFoundException();

            await _cloudinaryService.FileDeleteAsync(employee.ImagePath);

            _repository.Delete(employee);
            await _repository.SaveChangeAsync();

            return new ResultDto();
        }

        public async Task<ResultDto<List<EmployeeGetDto>>> GetAllAsync()
        {
            var employees = await _repository.GetAll().Include(x=>x.Profession).ToListAsync();

            var dtos = _mapper.Map<List<EmployeeGetDto>>(employees);

            return new()
            {
                Data = dtos,
            };

        }

        public async Task<ResultDto<EmployeeGetDto?>> GetByIdAsync(Guid id)
        {
            var employee = await _repository.GetByIdAsync(id);
            
            if(employee is null)
                throw new NotFoundException();

            var dto = _mapper.Map<EmployeeGetDto>(employee);
            return new()
            {
                Data = dto,
            };

        }

        public async Task<ResultDto> UpdateAsync(EmployeeUpdateDto dto)
        {
            var existItem = await _repository.GetByIdAsync(dto.Id);

            if(existItem is null)
                throw new NotFoundException();

            existItem = _mapper.Map(dto, existItem);

            if(dto.Image is { })
            {
                await _cloudinaryService.FileDeleteAsync(existItem.ImagePath);

                var imagePath = await _cloudinaryService.FileUploadAsync(dto.Image);
                existItem.ImagePath = imagePath;

            }

            _repository.Update(existItem);
            await _repository.SaveChangeAsync();

            return new();
        }
    }
}
