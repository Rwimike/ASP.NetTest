using Domain.Entities;

namespace Infrastructure.Interfaces;

public interface IStatusRepository
{
    Task<List<Status>> GetAllAsync();
}