using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Departments;
public class DepartmentDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public int EmployeeCount { get; set; }
}

public class CreateDepartmentDTO
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;
    
    [StringLength(500)]
    public string? Description { get; set; }
}