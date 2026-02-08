using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProcessManager.Application.Interfaces.Repositories;
using ProcessManager.Infrastructure.Data;
using ProcessManager.Infrastructure.Repositories;

namespace ProcessManager.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ProcessManagerDbContext>(options =>
            options.UseSqlite(
                configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IAreaRepository, AreaRepository>();
        services.AddScoped<IProcessRepository, ProcessRepository>();

        return services;
    }
}
