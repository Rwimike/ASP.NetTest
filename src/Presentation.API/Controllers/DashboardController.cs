using Microsoft.AspNetCore.Mvc;

namespace Presentation.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DashboardController : ControllerBase
{
    private readonly IDashboardService _service;
    
    public DashboardController(IDashboardService service)
    {
        _service = service;
    }
    
    [HttpGet("stats")]
    public async Task<IActionResult> GetStats()
    {
        var stats = await _service.GetDashboardStatsAsync();
        return Ok(stats);
    }
    
    [HttpPost("query")]
    public async Task<IActionResult> ProcessQuery([FromBody] string query)
    {
        var result = await _service.ProcessQueryAsync(query);
        return Ok(new { answer = result });
    }
}