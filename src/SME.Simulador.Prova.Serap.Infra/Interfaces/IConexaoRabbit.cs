using RabbitMQ.Client;

namespace SME.Simulador.Prova.Serap.Infra;

public interface IConexaoRabbit
{
    IModel Get();
    void Return(IModel conexao);
}