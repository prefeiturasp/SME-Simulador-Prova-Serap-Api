using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace SME.Simulador.Prova.Serap.IoC;

internal static class RegistrarCorsExtension
{
    //private const string CorsPolicy = nameof(CorsPolicy);
    
    internal static void RegistrarCors(this IServiceCollection services)
    {
        services.AddCors();
        /*
        services.AddCors(options =>
        {
            options.AddPolicy(CorsPolicy,
                builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
        });
        */        
    }

    internal static void UtilizarCors(this WebApplication app)
    {
        app.UseCors(cors => cors
            .SetIsOriginAllowed(_ => true)
            //.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());
    }
}