using Finanzas.Interfaces.Reposritory;

namespace Finanzas.Repository.DI
{
    public static class RegisterRepositories
    {
        public static IServiceCollection RegisterRepository(this IServiceCollection services)
        {
            services.AddScoped<IGastosRepository, GastosRepository>();
            services.AddScoped<ITipoGastosReporitory, TipoGastosRepository>();
            services.AddScoped<IMetodoPagoReporitory, MetodoPagoRepository>();
            services.AddScoped<IPrestamosRepository, PrestamosRepository>();
            return services;
        }
    }
}
