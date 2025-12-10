using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTOs.Departments;

namespace Application.Interfaces
{
    public interface IDepartmentService
    {
        Task<DepartmentDTO> GetDepartmentByIdAsync(int id);
        Task<IEnumerable<DepartmentDTO>> GetAllDepartmentsAsync();
        Task<DepartmentDTO> CreateDepartmentAsync(CreateDepartmentDTO departmentDto);
        Task<bool> DeleteDepartmentAsync(int id);
        Task<int> GetEmployeeCountByDepartmentAsync(int departmentId);
    }
}