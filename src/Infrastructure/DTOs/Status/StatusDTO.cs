namespace Infrastructure.DTOs.Status;

public class StatusDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public int EmployeeCount { get; set; }
}