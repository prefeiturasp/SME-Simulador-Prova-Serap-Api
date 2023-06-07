using Microsoft.Extensions.ObjectPool;
using SME.Simulador.Prova.Serap.Dominio;

namespace SME.Simulador.Prova.Serap.Infra;

public class ConexaoRabbitLog : ConexaoRabbit, IConexaoRabbitLog
{
    public ConexaoRabbitLog(ConfiguracaoRabbit configuracaoRabbit, ObjectPoolProvider poolProvider) : base(configuracaoRabbit, poolProvider)
    {
    }
}