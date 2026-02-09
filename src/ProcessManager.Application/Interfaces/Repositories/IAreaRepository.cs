using ProcessManager.Domain.Entities;

namespace ProcessManager.Application.Interfaces.Repositories;

public interface IAreaRepository
{
    Task AddAsync(Area area);
    Task<Area?> GetByIdAsync(Guid id);

    Task<List<Area>> GetAllAsync();
}
