
namespace Pustok.Buisness.Services.Abstractions
{
    public interface IEmployeeService
    {
        Task CreateAsync(EmployeeCreateDto dto);    
        Task UpdateAsync(EmployeeUpdateDto dto);
        Task DeleteAsync(Guid id);
        Task<EmployeeGetDto?> GetByIdAsync(Guid id);
        Task<List<EmployeeGetDto>> GetAllAsync();
    }
}
