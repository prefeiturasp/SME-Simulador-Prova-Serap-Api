using SME.Simulador.Prova.Serap.Dominio;

namespace SME.Simulador.Prova.Serap.Infra;

public class LogMensagemDto
{
    public LogMensagemDto(string mensagem, LogNivel nivel, string observacao,
        string projeto = "Simulador-Prova-Serap-Api", string? rastreamento = null,
        string? excecaoInterna = null)
    {
        Mensagem = mensagem;
        Nivel = nivel;
        Observacao = observacao;
        Projeto = projeto;
        Rastreamento = rastreamento;
        ExcecaoInterna = excecaoInterna;
        DataHora = UtilDataHora.ObterDataHoraAtualBrasiliaUtc();
    }

    public string Mensagem { get; set; }
    public LogNivel Nivel { get; set; }
    public string Observacao { get; set; }
    public string Projeto { get; set; }
    public string? Rastreamento { get; set; }
    public string? ExcecaoInterna { get; set; }
    public DateTime DataHora { get; set; }    
}