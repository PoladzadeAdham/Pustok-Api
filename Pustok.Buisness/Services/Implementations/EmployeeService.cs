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
        private readonly IMapper _mapper;
        private readonly ICloudinaryService _cloudinaryService;

        public EmployeeService(IEmployeeRepository repository, IMapper mapper, ICloudinaryService cloudinaryService)
        {
            _repository = repository;
            _mapper = mapper;
            _cloudinaryService = cloudinaryService;
        }

        public async Task CreateAsync(EmployeeCreateDto dto)
        {
            var employee = _mapper.Map<Employee>(dto);

            var imagePath = await _cloudinaryService.FileUploadAsync(dto.Image);
            employee.ImagePath = imagePath;

            await _repository.AddAsync(employee);
            await _repository.SaveChangeAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var employee = await _repository.GetByIdAsync(id);

            if (employee is null)
                throw new NotFoundException();

            await _cloudinaryService.FileDeleteAsync(employee.ImagePath);

            _repository.Delete(employee);
            await _repository.SaveChangeAsync();
        }

        public async Task<List<EmployeeGetDto>> GetAllAsync()
        {
            var employees = await _repository.GetAll().Include(x=>x.Profession).ToListAsync();

            var dtos = _mapper.Map<List<EmployeeGetDto>>(employees);

            return dtos;

        }

        public async Task<EmployeeGetDto?> GetByIdAsync(Guid id)
        {
            var employee = await _repository.GetByIdAsync(id);
            
            if(employee is null)
                throw new NotFoundException();

            var dto = _mapper.Map<EmployeeGetDto>(employee);
            return dto;

        }

        public async Task UpdateAsync(EmployeeUpdateDto dto)
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

        }
    }
}
