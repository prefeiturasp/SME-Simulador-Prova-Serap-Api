using Microsoft.Extensions.ObjectPool;
using RabbitMQ.Client;
using SME.Simulador.Prova.Serap.Dominio;

namespace SME.Simulador.Prova.Serap.Infra;

public abstract class ConexaoRabbit : IConexaoRabbit
{
    private readonly ObjectPool<IModel> pool;

    protected ConexaoRabbit(ConfiguracaoRabbit configuracaoRabbit, ObjectPoolProvider poolProvider)
    {
        if (configuracaoRabbit == null)
            throw new ArgumentNullException(nameof(configuracaoRabbit));

        if (poolProvider == null)
            throw new ArgumentNullException(nameof(poolProvider));
        
        var policy = new RabbitModelPooledObjectPolicy(configuracaoRabbit);
        pool = poolProvider.Create(policy);
    }

    public IModel Get() => pool.Get();
    
    public void Return(IModel conexao) => pool.Return(conexao);
}