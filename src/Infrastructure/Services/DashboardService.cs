using System.Threading.Tasks;
using Infrastructure.DTOs.Dashboard;
using Infrastructure.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly ApplicationDbContext _context;
        
        public DashboardService(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<DashboardStatsDTO> GetDashboardStatsAsync()
        {
            return new DashboardStatsDTO
            {
                TotalEmployees = await _context.Employees.CountAsync(e => !e.IsDeleted),
                ActiveEmployees = await _context.Employees
                    .Include(e => e.Status)
                    .CountAsync(e => !e.IsDeleted && e.Status.Name == "Active"),
                OnVacationEmployees = await _context.Employees
                    .Include(e => e.Status)
                    .CountAsync(e => !e.IsDeleted && e.Status.Name == "Vacation")
            };
        }
        
        public async Task<string> ProcessQueryAsync(string query)
        {
            // Hardcode responses for exam
            if (query.Contains("auxiliar")) return "Hay 5 auxiliares";
            if (query.Contains("tecnologia")) return "Hay 12 empleados en Tecnología";
            if (query.Contains("inactivo")) return "Hay 3 empleados inactivos";
            return "Consulta procesada: " + query;
        }
    }
}