namespace Pustok.Buisness.Dtos;

public class EmployeeGetDto
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public decimal Salary { get; set; }
    public string ImagePath { get; set; } = string.Empty;
    public string ProfessionName { get; set; } = string.Empty;
}



