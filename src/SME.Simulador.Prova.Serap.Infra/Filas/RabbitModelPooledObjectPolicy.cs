using Microsoft.Extensions.ObjectPool;
using RabbitMQ.Client;
using SME.Simulador.Prova.Serap.Dominio;

namespace SME.Simulador.Prova.Serap.Infra;

public class RabbitModelPooledObjectPolicy : IPooledObjectPolicy<IModel>
{
    private readonly IConnection conexao;

    public RabbitModelPooledObjectPolicy(ConfiguracaoRabbit configuracaoRabbit)
    {
        if (configuracaoRabbit == null)
            throw new ArgumentNullException(nameof(configuracaoRabbit));

        conexao = ObterConexao(configuracaoRabbit);
    }

    private static IConnection ObterConexao(ConfiguracaoRabbit configuracaoRabbit)
    {
        var factory = new ConnectionFactory
        {
            HostName = configuracaoRabbit.HostName,
            UserName = configuracaoRabbit.UserName,
            Password = configuracaoRabbit.Password,
            VirtualHost = configuracaoRabbit.VirtualHost
        };

        return factory.CreateConnection();
    }

    public IModel Create()
    {
        var channel = conexao.CreateModel();
        channel.ConfirmSelect();
        return channel;
    }

    public bool Return(IModel obj)
    {
        if (obj.IsOpen)
            return true;
        
        obj.Dispose();
        return false;
    }
}