namespace SME.Simulador.Prova.Serap.Infra;

public class QuestaoSerapDto : DtoBase
{
    public long Id { get; set; }
    public int Ordem { get; set; }
    public string TextoBase { get; set; } = string.Empty;
    public string Enunciado { get; set; } = string.Empty;
    public string Caderno { get; set; } = string.Empty;
    public int TipoItem { get; set; }
    public int QuantidadeAlternativas { get; set; }
    public long? QuestaoAnteriorId { get; set; }
    public long? ProximaQuestaoId { get; set; }
    public long ProvaId { get; set; }
}