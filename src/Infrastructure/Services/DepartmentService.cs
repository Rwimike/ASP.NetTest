using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.DTOs.Departments;
using Infrastructure.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly ApplicationDbContext _context;
        
        public DepartmentService(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<List<DepartmentDTO>> GetAllDepartmentsAsync()
        {
            return await _context.Departments
                .Select(d => new DepartmentDTO 
                { 
                    Id = d.Id, 
                    Name = d.Name 
                })
                .ToListAsync();
        }
    }
}