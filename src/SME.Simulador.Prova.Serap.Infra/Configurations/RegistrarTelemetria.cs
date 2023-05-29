using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SME.Simulador.Prova.Serap.Dominio;

namespace SME.Simulador.Prova.Serap.Infra;

public static class RegistrarTelemetria
{
    private static void RegistrarEnvironmentVariables(WebApplicationBuilder builder)
    {
        builder.Services.AddOptions<TelemetriaOptions>()
            .Bind(builder.Configuration.GetSection(TelemetriaOptions.Secao));

        builder.Services.AddSingleton<TelemetriaOptions>();        
    }
    
    public static void ConfigurarTelemetria(this WebApplicationBuilder builder)
    {
        RegistrarEnvironmentVariables(builder);
        builder.Services.AddApplicationInsightsTelemetry(builder.Configuration);
        builder.Services.AddScoped<IServicoTelemetria, ServicoTelemetria>();
    }
}