using Infrastructure.DTOs.Employees;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Web.Controllers;

[Authorize(Roles = "Admin")]
public class EmployeesController : Controller
{
    private readonly IEmployeeService _employeeService;
    private readonly IDepartmentService _departmentService;

    
    public EmployeesController(
        IEmployeeService employeeService,
        IDepartmentService departmentService)
    {
        _employeeService = employeeService;
        _departmentService = departmentService;
    }
    
    // GET: Employees/Index (Lista)
    public async Task<IActionResult> Index()
    {
        var employees = await _employeeService.GetAllEmployeesAsync();
        return View(employees);
    }
    
    // GET: Employees/Create
    public async Task<IActionResult> Create()
    {
        await LoadViewData();
        return View();
    }
    
    // POST: Employees/Create
    [HttpPost]
    public async Task<IActionResult> Create(CreateEmployeeDTO dto)
    {
        if (ModelState.IsValid)
        {
            await _employeeService.CreateEmployeeAsync(dto);
            return RedirectToAction(nameof(Index));
        }
        
        await LoadViewData();
        return View(dto);
    }
    
    // GET: Employees/Edit/{document}
    public async Task<IActionResult> Edit(string document)
    {
        var employee = await _employeeService.GetEmployeeAsync(document);
        if (employee == null) return NotFound();
        
        await LoadViewData();
        return View(employee);
    }
    
    // POST: Employees/Edit/{document}
    [HttpPost]
    public async Task<IActionResult> Edit(string document, UpdateEmployeeDTO dto)
    {
        if (ModelState.IsValid)
        {
            await _employeeService.UpdateEmployeeAsync(document, dto);
            return RedirectToAction(nameof(Index));
        }
        
        await LoadViewData();
        return View(dto);
    }
    
    // GET: Employees/Delete/{document}
    public async Task<IActionResult> Delete(string document)
    {
        var employee = await _employeeService.GetEmployeeAsync(document);
        if (employee == null) return NotFound();
        
        return View(employee);
    }
    
    // POST: Employees/Delete/{document}
    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(string document)
    {
        await _employeeService.DeleteEmployeeAsync(document);
        return RedirectToAction(nameof(Index));
    }
    
    // Cargar datos para dropdowns
    private async Task LoadViewData()
    {
        ViewBag.Departments = await _departmentService.GetAllDepartmentsAsync();
    }
}