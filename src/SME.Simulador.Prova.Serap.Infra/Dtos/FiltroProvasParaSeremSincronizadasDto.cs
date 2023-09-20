namespace SME.Simulador.Prova.Serap.Infra;

public class FiltroProvasParaSeremSincronizadasDto : DtoBase
{
    public FiltroProvasParaSeremSincronizadasDto(string questaoCodigo, DateTime ultimaAtualizacao)
    {
        QuestaoCodigo = questaoCodigo;
        UltimaAtualizacao = ultimaAtualizacao;
    }

    public string QuestaoCodigo { get; }
    public DateTime UltimaAtualizacao { get; }
}