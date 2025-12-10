using Domain.Entities;
namespace Infrastructure.Interfaces;
public interface IEmployeeRepository
{
    Task<Employee?> GetByDocumentAsync(string document);
    Task<List<Employee>> GetAllAsync();
    Task AddAsync(Employee employee);
    Task<int> GetTotalCountAsync();
    Task<int> GetCountByStatusAsync(string status);
    Task UpdateAsync(Employee employee);
    Task<bool> SaveChangesAsync();
}