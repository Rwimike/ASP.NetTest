using Domain.Entities;

namespace Infrastructure.Interfaces;

public interface IDepartmentRepository
{
    Task<Department?> GetByIdAsync(int id);
    Task<List<Department>> GetAllAsync();
    Task AddAsync(Department department);
}