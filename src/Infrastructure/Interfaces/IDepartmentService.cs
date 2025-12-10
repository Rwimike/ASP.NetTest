using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.DTOs.Departments;

namespace Infrastructure.Interfaces
{
    public interface IDepartmentService
    {
        Task<List<DepartmentDTO>> GetAllDepartmentsAsync();
    }
}