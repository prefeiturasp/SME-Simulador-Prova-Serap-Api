namespace SME.Simulador.Prova.Serap.Infra;

public class FiltroProvasParaSeremSincronizadasDto : DtoBase
{
    public FiltroProvasParaSeremSincronizadasDto(long questaoId, DateTime ultimaAtualizacao)
    {
        QuestaoId = questaoId;
        UltimaAtualizacao = ultimaAtualizacao;
    }

    public long QuestaoId { get; }
    public DateTime UltimaAtualizacao { get; }
}