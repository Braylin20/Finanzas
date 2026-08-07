using Finanzas.Data.Dal;
using Microsoft.EntityFrameworkCore;

namespace Finanzas.Data.DI;

public static class DbContextRegister
{
    public static IServiceCollection RegisterDbContextFactory(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<Contexto>(options =>
            options.UseNpgsql(connectionString));
        return services;
    }
}
