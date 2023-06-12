namespace SME.Simulador.Prova.Serap.Infra.Dtos;

public class AlternativaDto : DtoBase
{
    public long Id { get; set; }
    public long QuestaoId { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public int Ordem { get; set; }
    public string Numeracao { get; set; } = string.Empty;
}