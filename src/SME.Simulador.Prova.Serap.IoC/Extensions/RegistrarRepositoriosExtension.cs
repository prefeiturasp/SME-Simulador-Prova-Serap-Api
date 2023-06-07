using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SME.Simulador.Prova.Serap.Dados;

namespace SME.Simulador.Prova.Serap.IoC;

internal static class RegistrarRepositoriosExtension
{
    internal static void RegistrarRepositorios(this IServiceCollection services)
    {
        services.TryAddScoped<IRepositorioCache, RepositorioCache>();
        services.TryAddScoped<IRepositorioUsuarioSerapCoreSso, RepositorioUsuarioSerapCoreSso>();
    }
}