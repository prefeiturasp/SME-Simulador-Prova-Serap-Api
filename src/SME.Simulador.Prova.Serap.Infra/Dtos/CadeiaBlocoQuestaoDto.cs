namespace SME.Simulador.Prova.Serap.Infra;

public class CadeiaBlocoQuestaoDto
{
    public long Id { get; set; }
    public long CadeiaBlocoId { get; set; }
    public long QuestaoId { get; set; }
    public int Ordem { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime DataAtualizacao { get; set; }
}