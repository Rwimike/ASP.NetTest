using Infrastructure.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class PositionRepository : IPositionRepository
{
    private readonly ApplicationDbContext _context;
    public PositionRepository(ApplicationDbContext context) => _context = context;
    
    public async Task<List<Position>> GetAllAsync() 
        => await _context.Positions.Include(p => p.Employees).ToListAsync();
}
