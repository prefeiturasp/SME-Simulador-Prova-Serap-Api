using SME.Simulador.Prova.Serap.Dominio;

namespace SME.Simulador.Prova.Serap.Dados;

public sealed class UnitOfWorkBaseGestaoAvaliacao : UnitOfWorkBaseBase<GestaoAvaliacaoContexto>, IUnitOfWorkBaseGestaoAvaliacao
{
    public UnitOfWorkBaseGestaoAvaliacao(GestaoAvaliacaoContexto contexto) : base(contexto)
    {
    }
}