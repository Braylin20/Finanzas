using Finanzas.Data.Dal;
using Microsoft.EntityFrameworkCore;

namespace Finanzas.Data.DI;

public static class DbContextRegister
{
    public static IServiceCollection RegisterDbContextFactory(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("ConStr");

        services.AddDbContext<Contexto>(options =>
            options.UseSqlite(connectionString)
        );

        return services;
    }
}
