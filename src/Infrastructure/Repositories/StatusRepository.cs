using Infrastructure.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class StatusRepository : IStatusRepository
{
    private readonly ApplicationDbContext _context;
    public StatusRepository(ApplicationDbContext context) => _context = context;
    
    public async Task<List<Status>> GetAllAsync() 
        => await _context.Statuses.Include(s => s.Employees).ToListAsync();
}
