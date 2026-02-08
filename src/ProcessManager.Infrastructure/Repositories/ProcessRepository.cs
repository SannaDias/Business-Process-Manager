using Microsoft.EntityFrameworkCore;
using ProcessManager.Application.Interfaces.Repositories;
using ProcessManager.Domain.Entities;
using ProcessManager.Infrastructure.Data;

namespace ProcessManager.Infrastructure.Repositories;

public class ProcessRepository : IProcessRepository
{
    private readonly ProcessManagerDbContext _context;

    public ProcessRepository(ProcessManagerDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Process process)
    {
        await _context.Processes.AddAsync(process);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Process process)
    {
        _context.Processes.Update(process);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveAsync(Process process)
    {
        _context.Processes.Remove(process);
        await _context.SaveChangesAsync();
    }

    public async Task<Process?> GetByIdAsync(Guid id)
    {
        return await _context.Processes.FindAsync(id);
    }

    public async Task<Process?> GetByIdWithChildrenAsync(Guid id)
    {
        return await _context.Processes
            .Include(p => p.SubProcesses)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

   public async Task<List<Process>> GetByAreaIdAsync(Guid areaId)
    {
        return await _context.Processes
            .Where(p => p.AreaId == areaId)
            .Include(p => p.SubProcesses)
            .ToListAsync();
    }
}