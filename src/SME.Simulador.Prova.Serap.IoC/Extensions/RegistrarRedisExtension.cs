using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using SME.Simulador.Prova.Serap.Dominio;
using StackExchange.Redis;

namespace SME.Simulador.Prova.Serap.IoC;

internal static class RegistrarRedisExtension
{
    internal static void RegistrarRedis(this IServiceCollection services)
    {
        var serviceProvider = services.BuildServiceProvider();
        var redisOptions = serviceProvider.GetRequiredService<IOptions<RedisOptions>>().Value;
        
        var redisConfigurationOptions = new ConfigurationOptions
        {
            Proxy = redisOptions.Proxy,
            SyncTimeout = redisOptions.SyncTimeout,
            EndPoints = { redisOptions.EndPoint }
        };        
        
        var muxer = ConnectionMultiplexer.Connect(redisConfigurationOptions);
        services.TryAddSingleton<IConnectionMultiplexer>(muxer);
    }
}