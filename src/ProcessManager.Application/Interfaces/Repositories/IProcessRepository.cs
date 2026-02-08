using ProcessManager.Domain.Entities;

namespace ProcessManager.Application.Interfaces.Repositories;

public interface IProcessRepository
{
    Task AddAsync(Process process);
    Task UpdateAsync(Process process);
    Task RemoveAsync(Process process);

    Task<Process?> GetByIdAsync(Guid id);

    Task<Process?> GetByIdWithChildrenAsync(Guid id);

    Task<List<Process>> GetByAreaIdAsync(Guid areaId);
}
