using Infrastructure.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly ApplicationDbContext _context;
    public DepartmentRepository(ApplicationDbContext context) => _context = context;

    public async Task<Department?> GetByIdAsync(int id) 
        => await _context.Departments.Include(d => d.Employees).FirstOrDefaultAsync(d => d.Id == id);

    public async Task<List<Department>> GetAllAsync() 
        => await _context.Departments.Include(d => d.Employees).ToListAsync();

    public async Task AddAsync(Department department)
    {
        _context.Departments.Add(department);
        await _context.SaveChangesAsync();
    }
}