using System.Threading.Tasks;
using Application.DTOs.Dashboard;

namespace Application.Interfaces
{
    public interface IDashboardService
    {
        Task<DashboardStatsDTO> GetDashboardStatsAsync();
        Task<IEnumerable<DepartmentStatsDTO>> GetDepartmentStatisticsAsync();
        Task<string> ProcessNaturalLanguageQueryAsync(string query);
    }
}