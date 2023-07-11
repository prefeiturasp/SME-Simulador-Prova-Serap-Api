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
        AddOptions<ConnectionStringsOptions>(builder, SecoesOptions.ConnectionStrings);
    }

    private static void AddTelemetria(WebApplicationBuilder builder)
    {
        AddOptions<TelemetriaOptions>(builder, SecoesOptions.Telemetria);
    }

    private static void AddJwtOptions(WebApplicationBuilder builder)
    {
        AddOptions<JwtOptions>(builder, SecoesOptions.JwtOptions);
    }

    private static void AddElasticApmOptions(WebApplicationBuilder builder)
    {
        AddOptions<ElasticApmOptions>(builder, SecoesOptions.ElasticApm);
    }

    private static void AddRedisOptions(WebApplicationBuilder builder)
    {
        AddOptions<RedisOptions>(builder, SecoesOptions.RedisOptions);
    }

    private static void AddRabbitLogOptions(WebApplicationBuilder builder)
    {
        AddOptions<RabbitLogOptions>(builder, SecoesOptions.RabbitLog);
    }

    private static void AddAutenticacao(WebApplicationBuilder builder)
    {
        AddOptions<AutenticacaoOptions>(builder, SecoesOptions.Autenticacao);
    }

    private static void AddClientApi(WebApplicationBuilder builder)
    {
        AddOptions<ClientApiOptions>(builder, SecoesOptions.ClientApi);        
    }
    
    internal static void RegistrarEnvironmentVariables(this WebApplicationBuilder builder)
    {
        AddConnectionString(builder);
        AddTelemetria(builder);
        AddJwtOptions(builder);
        AddElasticApmOptions(builder);
        AddRedisOptions(builder);
        AddRabbitLogOptions(builder);
        AddAutenticacao(builder);
        AddClientApi(builder);
    }
}