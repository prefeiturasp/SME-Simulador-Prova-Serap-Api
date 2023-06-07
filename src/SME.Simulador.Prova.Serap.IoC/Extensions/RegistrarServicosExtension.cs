using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.IoC;

internal static class RegistrarServicosExtension
{
    internal static void RegistrarServicos(this IServiceCollection services)
    {
        services.TryAddScoped<IServicoTelemetria, ServicoTelemetria>();
        services.TryAddScoped<IServicoLog, ServicoLog>();
    }
}