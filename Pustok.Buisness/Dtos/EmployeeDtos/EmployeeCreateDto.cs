using Microsoft.AspNetCore.Http;

namespace Pustok.Buisness.Dtos;

public class EmployeeCreateDto
{
    public string FullName { get; set; } = string.Empty;
    public decimal Salary { get; set; }
    public IFormFile Image { get; set; } = null!;      
    public Guid ProfessionId { get; set; } 
}



