using StackExchange.Redis;

namespace SME.Simulador.Prova.Serap.Dominio;

public class RedisOptions
{
    public string EndPoint { get; set; } = string.Empty;
    public Proxy Proxy { get; set; }
    public int SyncTimeout { get; set; } = 5000;
}