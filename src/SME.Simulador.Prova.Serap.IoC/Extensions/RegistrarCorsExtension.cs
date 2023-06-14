using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace SME.Simulador.Prova.Serap.IoC;

internal static class RegistrarCorsExtension
{
    internal static void RegistrarCors(this IServiceCollection services)
    {
        services.AddCors();
    }

    internal static void UtilizarCors(this WebApplication app)
    {
        app.UseCors(builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());        
    }
}