using Domain.Entities;

namespace Infrastructure.Interfaces;

public interface IEducationLevelRepository
{
    Task<List<EducationLevel>> GetAllAsync();
}