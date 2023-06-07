using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.ObjectPool;
using Microsoft.Extensions.Options;
using SME.Simulador.Prova.Serap.Dominio;

namespace SME.Simulador.Prova.Serap.Infra;

public static class RegistrarRabbit
{
    public static void Registrar(IServiceCollection services)
    {
        services.TryAddSingleton<IConexaoRabbitLog>(serviceProvider =>
        {
            var rabbitLogOptions = serviceProvider.GetService<IOptions<RabbitLogOptions>>();

            if (rabbitLogOptions == null)
            {
                throw new ArgumentNullException(nameof(rabbitLogOptions),
                    "A configuração para o log do Rabbit MQ deve ser informada.");
            }

            var defaultObjectPoolProvider = serviceProvider.GetService<IOptions<DefaultObjectPoolProvider>>();

            if (defaultObjectPoolProvider == null)
            {
                throw new ArgumentNullException(nameof(defaultObjectPoolProvider),
                    "O Pool Provider deve ser informado.");
            }

            var options = rabbitLogOptions.Value;
            var provider = defaultObjectPoolProvider.Value;

            return new ConexaoRabbitLog(options, provider);
        });
    }
}