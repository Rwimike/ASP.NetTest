using Infrastructure.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly ApplicationDbContext _context;

    public EmployeeRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Employee?> GetByDocumentAsync(string document)
    {
        return await _context.Employees
            .Include(e => e.Position)
            .Include(e => e.Status)
            .Include(e => e.EducationLevel)
            .Include(e => e.Department)
            .FirstOrDefaultAsync(e => e.Document == document);
    }

    public async Task<List<Employee>> GetAllAsync()
    {
        return await _context.Employees
            .Include(e => e.Position)
            .Include(e => e.Status)
            .Include(e => e.EducationLevel)
            .Include(e => e.Department)
            .ToListAsync();
    }

    public async Task AddAsync(Employee employee)
    {
        _context.Employees.Add(employee);
        await _context.SaveChangesAsync();
    }

    public async Task<int> GetTotalCountAsync()
    {
        return await _context.Employees.CountAsync();
    }

    public async Task<int> GetCountByStatusAsync(string status)
    {
        return await _context.Employees
            .CountAsync(e => e.Status.Name == status);
    }
}