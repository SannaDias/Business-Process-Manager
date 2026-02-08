using Microsoft.EntityFrameworkCore;
using ProcessManager.Domain.Entities;

namespace ProcessManager.Infrastructure.Data;

public class ProcessManagerDbContext : DbContext
{
    public DbSet<Area> Areas => Set<Area>();
    public DbSet<Process> Processes => Set<Process>();

    public ProcessManagerDbContext(DbContextOptions<ProcessManagerDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProcessManagerDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
