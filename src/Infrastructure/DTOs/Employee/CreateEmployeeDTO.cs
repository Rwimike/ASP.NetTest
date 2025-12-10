using System.ComponentModel.DataAnnotations;

namespace Infrastructure.DTOs.Employees;

public class CreateEmployeeDTO
{
    // Campos REQUERIDOS para ambos casos
    [Required] public string Document { get; set; } = string.Empty;
    [Required] public string FirstNames { get; set; } = string.Empty;
    [Required] public string LastNames { get; set; } = string.Empty;
    [Required] public string Email { get; set; } = string.Empty;
    [Required] public string PhoneNumber { get; set; } = string.Empty;
    [Required] public int DepartmentId { get; set; }
    
    // Campos OPCIONALES (admin los llena después)
    public DateTime? DateOfBirth { get; set; }
    public string? Address { get; set; }
    public int? PositionId { get; set; }
    public decimal? Salary { get; set; }
    public DateTime? HireDate { get; set; }
    public int? StatusId { get; set; }
    public int? EducationLevelId { get; set; }
    public string? ProfessionalProfile { get; set; }
}