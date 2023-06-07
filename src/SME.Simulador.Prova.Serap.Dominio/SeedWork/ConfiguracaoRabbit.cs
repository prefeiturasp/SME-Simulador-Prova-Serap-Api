namespace SME.Simulador.Prova.Serap.Dominio;

public abstract class ConfiguracaoRabbit
{
    public string HostName { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string VirtualHost { get; set; } = string.Empty;
    public ushort LimiteDeMensagensPorExecucao { get; set; }
}