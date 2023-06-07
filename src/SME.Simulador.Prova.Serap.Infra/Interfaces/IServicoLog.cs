using SME.Simulador.Prova.Serap.Dominio;

namespace SME.Simulador.Prova.Serap.Infra;

public interface IServicoLog
{
    void Registrar(Exception ex);
    void Registrar(string mensagem, Exception ex);
    void Registrar(LogNivel nivel, string erro, string observacoes, string stackTrace);
    void Registrar(LogMensagemDto logMensagem);
    Task PublicarMensagem(byte[] body);
}