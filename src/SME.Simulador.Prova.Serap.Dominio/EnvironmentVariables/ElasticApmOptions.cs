namespace SME.Simulador.Prova.Serap.Dominio;

public class ElasticApmOptions
{
    public const string Secao = "ElasticApm";
    public string? TransactionSampleRate { get; set; }
    public string? ServerUrl { get; set; }
    public string? Environment { get; set; }
}