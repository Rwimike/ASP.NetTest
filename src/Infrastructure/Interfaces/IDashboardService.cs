using System.Threading.Tasks;
using Infrastructure.DTOs.Dashboard;

namespace Infrastructure.Interfaces
{
    public interface IDashboardService
    {
        Task<DashboardStatsDTO> GetDashboardStatsAsync();
        Task<string> ProcessQueryAsync(string query);
    }
}