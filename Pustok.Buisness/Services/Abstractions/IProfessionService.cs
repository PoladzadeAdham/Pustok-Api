using Pustok.Buisness.Dtos.ProfessionDtos;
using Pustok.Core.Entities;

namespace Pustok.Buisness.Services.Abstractions
{
    public interface IProfessionService
    {
        Task CreateAsync(ProfessionCreateDto dto);
        Task<List<ProfessionGetDto>> GetAllAsync();
        Task UpdateAsync(ProfessionUpdateDto dto);
        Task DeleteAsync(Guid id);
        Task<ProfessionGetDto?> GetById(Guid id); 

    }
}
