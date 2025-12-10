using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeService _service;
    
    public EmployeesController(IEmployeeService service)
    {
        _service = service;
    }
    
    [HttpGet("me")]
    public async Task<IActionResult> GetMe()
    {
        // En producción, obtener del token JWT
        // Para examen: usar header "X-Employee-Document"
        var doc = Request.Headers["X-Employee-Document"].ToString();
        
        if (string.IsNullOrEmpty(doc))
            return Unauthorized();
            
        var employee = await _service.GetEmployeeAsync(doc);
        return Ok(employee);
    }
    
    [HttpGet("me/pdf")]
    public async Task<IActionResult> GetMyPdf()
    {
        var doc = Request.Headers["X-Employee-Document"].ToString();
        
        // PDF simple para examen
        var html = $"<h1>Hoja de Vida</h1><p>Documento: {doc}</p>";
        var bytes = System.Text.Encoding.UTF8.GetBytes(html);
        
        return File(bytes, "text/html", "hoja-vida.html");
    }
}