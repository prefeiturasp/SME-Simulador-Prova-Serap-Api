namespace SME.Simulador.Prova.Serap.Infra;

public class ArquivoDto : DtoBase
{
    public string Caminho { get; set; } = string.Empty;
    public long TamanhoBytes { get; set; }
    public long Id { get; set; }
}