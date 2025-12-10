public class EmployeeDTO
{
    public string Document { get; set; } = string.Empty;
    public string FirstNames { get; set; } = string.Empty;
    public string LastNames { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public string Address { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    
    // Position
    public int PositionId { get; set; }
    public string PositionName { get; set; } = string.Empty;
    
    public decimal Salary { get; set; }
    public DateTime HireDate { get; set; }
    
    // Status
    public int StatusId { get; set; }
    public string StatusName { get; set; } = string.Empty;
    
    // Education
    public int EducationLevelId { get; set; }
    public string EducationLevelName { get; set; } = string.Empty;
    
    public string ProfessionalProfile { get; set; } = string.Empty;
    
    // Department
    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; } = string.Empty;
    
    // Auditing
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}