namespace Pustok.Buisness.Dtos;

public class EmployeeGetDto
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public decimal Salary { get; set; }
    public string ImagePath { get; set; } = string.Empty;
    public string ProfessionName { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; }
    public string CreatedBy { get; set; } = string.Empty;
    public DateTime? UpdatedDate { get; set; }
    public string? UpdatedBy { get; set; } = string.Empty;
    public DateTime? DeletedDate { get; set; }
    public string? DeletedBy { get; set; } = string.Empty;
    public bool IsDeleted { get; set; } = false;
}



