using Domain.Entities;

namespace Infrastructure.Interfaces;

public interface IPositionRepository
{
    Task<List<Position>> GetAllAsync();
}