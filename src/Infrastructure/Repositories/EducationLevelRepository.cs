using Infrastructure.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class EducationLevelRepository : IEducationLevelRepository
{
    private readonly ApplicationDbContext _context;
    public EducationLevelRepository(ApplicationDbContext context) => _context = context;
    
    public async Task<List<EducationLevel>> GetAllAsync() 
        => await _context.EducationalLevels.Include(e => e.Employees).ToListAsync();
}