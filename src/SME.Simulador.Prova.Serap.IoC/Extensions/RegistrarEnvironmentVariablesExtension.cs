using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SME.Simulador.Prova.Serap.Dominio;

namespace SME.Simulador.Prova.Serap.IoC;

internal static class RegistrarEnvironmentVariablesExtension
{
    private static void AddOptions<TOptions>(WebApplicationBuilder builder, string secao) where TOptions : class
    {
        builder.Services.AddOptions<TOptions>()
            .Bind(builder.Configuration.GetSection(secao));

        builder.Services.AddSingleton<TOptions>();        
    }
    
    private static void AddConnectionString(WebApplicationBuilder builder)
    {
        AddOptions<ConnectionStringsOptions>(builder, ConnectionStringsOptions.Secao);
    }

    private static void AddTelemetria(WebApplicationBuilder builder)
    {
        AddOptions<TelemetriaOptions>(builder, TelemetriaOptions.Secao);
    }

    private static void AddJwtOptions(WebApplicationBuilder builder)
    {
        AddOptions<JwtOptions>(builder, JwtOptions.Secao);
    }

    private static void AddElasticApmOptions(WebApplicationBuilder builder)
    {
        AddOptions<ElasticApmOptions>(builder, ElasticApmOptions.Secao);
    }

    private static void AddRedisOptions(WebApplicationBuilder builder)
    {
        AddOptions<RedisOptions>(builder, RedisOptions.Secao);
    }
    
    internal static void RegistrarEnvironmentVariables(this WebApplicationBuilder builder)
    {
        AddConnectionString(builder);
        AddTelemetria(builder);
        AddJwtOptions(builder);
        AddElasticApmOptions(builder);
        AddRedisOptions(builder);
    }
}