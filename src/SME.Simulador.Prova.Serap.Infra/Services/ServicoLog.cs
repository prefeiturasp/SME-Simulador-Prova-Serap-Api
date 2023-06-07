using System.Text;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SME.Simulador.Prova.Serap.Dominio;

namespace SME.Simulador.Prova.Serap.Infra;

public class ServicoLog : IServicoLog
{
    private readonly ILogger<ServicoLog> logger;
    private readonly IServicoTelemetria servicoTelemetria;
    private readonly IConexaoRabbitLog conexaoRabbitLog;

    public ServicoLog(ILogger<ServicoLog> logger, IServicoTelemetria servicoTelemetria,
        IConexaoRabbitLog conexaoRabbitLog)
    {
        this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        this.servicoTelemetria = servicoTelemetria ?? throw new ArgumentNullException(nameof(servicoTelemetria));
        this.conexaoRabbitLog = conexaoRabbitLog ?? throw new ArgumentNullException(nameof(conexaoRabbitLog));
    }

    public void Registrar(Exception ex)
    {
        var logMensagem = new LogMensagemDto("Exception --- ", LogNivel.Critico, ex.Message, rastreamento: ex.StackTrace);
        Registrar(logMensagem);
    }

    public void Registrar(string mensagem, Exception ex)
    {
         var logMensagem = new LogMensagemDto(mensagem, LogNivel.Critico, ex.Message, rastreamento: ex.StackTrace);
         Registrar(logMensagem);
    }

    public void Registrar(LogNivel nivel, string erro, string observacoes, string stackTrace)
    {
        var logMensagem = new LogMensagemDto(erro, nivel, observacoes, rastreamento: stackTrace);
        Registrar(logMensagem);
    }

    public void Registrar(LogMensagemDto logMensagem)
    {
        var mensagem = JsonConvert.SerializeObject(logMensagem, new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore
        });

        var body = Encoding.UTF8.GetBytes(mensagem);
        
        servicoTelemetria.Registrar(() => PublicarMensagem(body), "RabbitMQ", "Salvar Log Via Rabbit",
            RotasRabbit.RotaLogs);
    }

    public Task PublicarMensagem(byte[] body)
    {
        try
        {
            var channel = conexaoRabbitLog.Get();

            try
            {
                var props = channel.CreateBasicProperties();
                props.Persistent = true;
                channel.BasicPublish(ExchangeRabbit.Logs, RotasRabbit.RotaLogs, true, props, body);
            }
            finally
            {
                conexaoRabbitLog.Return(channel);
            }
        }
        catch (Exception e)
        {
            logger.LogError("Erro: {Message}", e.Message);
        }

        return Task.CompletedTask;        
    }
}