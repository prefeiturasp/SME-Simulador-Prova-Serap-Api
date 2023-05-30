using Microsoft.AspNetCore.Builder;
using Prometheus;

namespace SME.Simulador.Prova.Serap.IoC;

internal static class RegistrarMetricasExtension
{
    internal static void UtilizarMetricas(this WebApplication app)
    {
        app.UseMetricServer();
        app.UseHttpMetrics();
    }
}