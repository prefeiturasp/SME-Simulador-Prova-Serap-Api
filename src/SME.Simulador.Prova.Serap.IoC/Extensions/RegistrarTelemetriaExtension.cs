using Elastic.Apm.AspNetCore;
using Elastic.Apm.DiagnosticSource;
using Elastic.Apm.SqlClient;
using Elastic.Apm.StackExchange.Redis;
using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SME.Simulador.Prova.Serap.Dados;
using SME.Simulador.Prova.Serap.Dominio;
using SME.Simulador.Prova.Serap.Infra;
using StackExchange.Redis;

namespace SME.Simulador.Prova.Serap.IoC;

internal static class RegistrarTelemetriaExtension
{
    internal static void RegistrarTelemetria(this WebApplicationBuilder builder)
    {
        builder.Services.AddApplicationInsightsTelemetry(builder.Configuration);        
    }

    internal static void UtilizarElasticApm(this WebApplication app)
    {
        var telemetriaOptions = app.Services.GetRequiredService<IOptions<TelemetriaOptions>>().Value;

        if (telemetriaOptions is not { Apm: true }) 
            return;
        
        app.UseElasticApm(app.Configuration,
            new SqlClientDiagnosticSubscriber(),
            new HttpDiagnosticsSubscriber());

        var muxer = app.Services.GetService<IConnectionMultiplexer>();
        muxer.UseElasticApm();
    }

    internal static void UtilizarTelemetria(this WebApplication app)
    {
        var telemetriaOptions = app.Services.GetRequiredService<IOptions<TelemetriaOptions>>();
        var valueTelemetriaOptions = telemetriaOptions.Value;

        if (valueTelemetriaOptions is not { Apm: true }) 
            return;
        
        var clientTelemetry = app.Services.GetService<TelemetryClient>();

        if (clientTelemetry == null)
            return;

        var servicoTelemetria = new ServicoTelemetria(clientTelemetry, telemetriaOptions);
        DapperInterceptor.Init(servicoTelemetria);
    }
}