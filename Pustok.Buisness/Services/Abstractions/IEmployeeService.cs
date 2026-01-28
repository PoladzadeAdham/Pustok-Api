
namespace Pustok.Buisness.Services.Abstractions
{
    public interface IEmployeeService
    {
        Task<ResultDto> CreateAsync(EmployeeCreateDto dto);    
        Task<ResultDto> UpdateAsync(EmployeeUpdateDto dto);
        Task<ResultDto> DeleteAsync(Guid id);
        Task<ResultDto<EmployeeGetDto?>> GetByIdAsync(Guid id);
        Task<ResultDto<List<EmployeeGetDto>>> GetAllAsync();
    }
}
