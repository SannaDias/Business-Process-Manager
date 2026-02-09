using Microsoft.EntityFrameworkCore;
using ProcessManager.Application.Interfaces.Repositories;
using ProcessManager.Domain.Entities;
using ProcessManager.Infrastructure.Data;

namespace ProcessManager.Infrastructure.Repositories;

public class AreaRepository : IAreaRepository
{
    private readonly ProcessManagerDbContext _context;

    public AreaRepository(ProcessManagerDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Area area)
    {
        await _context.Areas.AddAsync(area);
        await _context.SaveChangesAsync();
    }

    public async Task<Area?> GetByIdAsync(Guid id)
    {
        return await _context.Areas
            .Include(a => a.Processes)
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<List<Area>> GetAllAsync()
    {
        return await _context.Areas.ToListAsync();
    }
}
