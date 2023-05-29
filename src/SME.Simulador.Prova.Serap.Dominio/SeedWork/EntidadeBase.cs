using MessagePack;

namespace SME.Simulador.Prova.Serap.Dominio;

[MessagePackObject(keyAsPropertyName: true)]
public abstract class EntidadeBase
{
    public long Id { get; set; }
}