using System.Collections.Generic;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.DTOs.Employees;

namespace Infrastructure.Interfaces
{
    public interface IEmployeeService
    {
        Task<EmployeeDTO> GetEmployeeAsync(string document);
        Task<List<EmployeeDTO>> GetAllEmployeesAsync();
        Task<EmployeeDTO> CreateEmployeeAsync(CreateEmployeeDTO dto);
        Task<bool> UpdateEmployeeAsync(string document, UpdateEmployeeDTO dto);
        Task<bool> DeleteEmployeeAsync(string document);
        Task<int> GetTotalEmployeesAsync();
        Task<int> GetEmployeesByStatusAsync(string statusName);
    }
}