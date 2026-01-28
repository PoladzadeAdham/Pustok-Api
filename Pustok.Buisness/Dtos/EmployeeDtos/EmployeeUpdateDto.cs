using Microsoft.AspNetCore.Http;

namespace Pustok.Buisness.Dtos;

public class EmployeeUpdateDto
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public decimal Salary { get; set; }
    public IFormFile? Image { get; set; }
    public Guid ProfessionId { get; set; } 
}



