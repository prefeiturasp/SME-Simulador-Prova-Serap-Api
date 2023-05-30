using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SME.Simulador.Prova.Serap.Dados;
using SME.Simulador.Prova.Serap.Dominio;

namespace SME.Simulador.Prova.Serap.IoC;

internal static class RegistrarContextosExtension
{
    internal static void RegistrarContextos(this IServiceCollection services)
    {
        services.TryAddScoped<GestaoAvaliacaoContext>();
        services.TryAddTransient<IUnitOfWork, UnitOfWork>();
        services.TryAddSingleton<IActionContextAccessor, ActionContextAccessor>();        
    }
}