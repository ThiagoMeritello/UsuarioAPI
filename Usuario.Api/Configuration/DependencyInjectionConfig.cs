using Microsoft.Extensions.DependencyInjection;
using Usuario.Business.Interfaces;
using Usuario.Business.Notificacoes;
using Usuario.Business.Services;
using Usuario.Data.Context;
using Usuario.Data.Repository;

namespace Usuario.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MeuDbContext>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IUsuarioService, UsuarioService>();


            return services;
        }
    }
}
