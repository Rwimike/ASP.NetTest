using Application.DTOs.Employees;
using Application.Interfaces;
using Domain.Entities;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _repo;
    
    public EmployeeService(IEmployeeRepository repo)
    {
        _repo = repo;
    }
    
    public async Task<EmployeeDTO> CreateEmployeeAsync(CreateEmployeeDTO dto)
    {
        
        var employee = new Employee
        {
            Document = dto.Document,
            FirstNames = dto.FirstNames,
            LastNames = dto.LastNames,
            Email = dto.Email,
            PhoneNumber = dto.PhoneNumber,
            DepartmentId = dto.DepartmentId,
            
            // Valores por defecto para autoregistro
            DateOfBirth = dto.DateOfBirth ?? DateTime.Now.AddYears(-25),
            Address = dto.Address ?? "Por definir",
            PositionId = dto.PositionId ?? 1, // ID de posición por defecto (ej: "Sin asignar")
            Salary = dto.Salary ?? 0,
            HireDate = dto.HireDate ?? DateTime.Now,
            StatusId = dto.StatusId ?? 1, // ID de estado por defecto (ej: "Pendiente")
            EducationLevelId = dto.EducationLevelId ?? 1, // ID educación por defecto
            ProfessionalProfile = dto.ProfessionalProfile ?? string.Empty
        };
        
        await _repo.AddAsync(employee);
        
        // Retornar DTO básico
        return new EmployeeDTO
        {
            Document = employee.Document,
            FirstNames = employee.FirstNames,
            LastNames = employee.LastNames,
            Email = employee.Email
        };
    }
    
    // Métodos restantes simples...
    public async Task<int> GetTotalEmployeesAsync() 
        => await _repo.GetTotalCountAsync();
        
    public async Task<int> GetEmployeesByStatusAsync(string status) 
        => await _repo.GetCountByStatusAsync(status);
}