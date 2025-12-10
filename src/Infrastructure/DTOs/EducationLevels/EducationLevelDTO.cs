namespace Infrastructure.DTOs.EducationLevels;

public class EducationLevelDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public int EmployeeCount { get; set; }
}