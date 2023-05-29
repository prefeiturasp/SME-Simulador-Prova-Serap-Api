using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using SME.Simulador.Prova.Serap.Dominio;

namespace SME.Simulador.Prova.Serap.Dados;

public static class RegistrarDataAccess
{
    private static void RegistrarEnvironmentVariables(WebApplicationBuilder builder)
    {
        builder.Services.AddOptions<ConnectionStringsOptions>()
            .Bind(builder.Configuration.GetSection(ConnectionStringsOptions.Secao));

        builder.Services.AddSingleton<ConnectionStringsOptions>();        
    }
    
    private static void RegistrarContexto(IServiceCollection services)
    {
        services.AddScoped<GestaoAvaliacaoContext>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();        
    }
    
    public static void ConfigurarDataAccess(this WebApplicationBuilder builder)
    {
        RegistrarEnvironmentVariables(builder);
        RegistrarContexto(builder.Services);
    }
}