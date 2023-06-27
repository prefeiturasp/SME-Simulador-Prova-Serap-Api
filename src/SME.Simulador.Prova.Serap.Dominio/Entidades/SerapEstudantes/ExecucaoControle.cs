namespace SME.Simulador.Prova.Serap.Dominio;

public class ExecucaoControle : EntidadeBase
{
    public ExecucaoControleTipo ExecucaoTipo { get; set; }
    public DateTime UltimaExecucao { get; set; }
}