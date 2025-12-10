using System.ComponentModel.DataAnnotations;

public class UpdateEmployeeDTO
{
    [StringLength(100)]
    public string? FirstNames { get; set; }
    
    [StringLength(100)]
    public string? LastNames { get; set; }
    
    public DateTime? DateOfBirth { get; set; }
    
    [StringLength(200)]
    public string? Address { get; set; }
    
    [StringLength(20)]
    public string? PhoneNumber { get; set; }
    
    [EmailAddress]
    [StringLength(100)]
    public string? Email { get; set; }
    
    public int? PositionId { get; set; }
    
    [Range(0, double.MaxValue)]
    public decimal? Salary { get; set; }
    
    public int? StatusId { get; set; }
    
    public int? EducationLevelId { get; set; }
    
    [StringLength(500)]
    public string? ProfessionalProfile { get; set; }
    
    public int? DepartmentId { get; set; }
}