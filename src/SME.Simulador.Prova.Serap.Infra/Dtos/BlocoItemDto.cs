namespace SME.Simulador.Prova.Serap.Infra;

public class BlocoItemDto
{
    public long Id { get; set; }
    public long BlocoId { get; set; }
    public long ItemId { get; set; }
    public int Ordem { get; set; }
    public DateTime DataCriacao { get; set; }
}