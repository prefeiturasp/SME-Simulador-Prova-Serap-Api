namespace SME.Simulador.Prova.Serap.Infra;

public class QuestaoResumoDto : DtoBase
{
    public long Id { get; set; }
    public string TextoBase { get; set; } = string.Empty;
    public string Enunciado { get; set; } = string.Empty;
    public string Caderno { get; set; } = string.Empty;
    public int Ordem { get; set; }
    public long IdProva { get; set; }
    public string DescricaoProva { get; set; } = string.Empty;
    public long? QuestaoAnteriorId { get; set; }
    public long? ProximaQuestaoId { get; set; }
}