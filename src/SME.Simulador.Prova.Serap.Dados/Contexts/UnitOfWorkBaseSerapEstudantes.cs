using SME.Simulador.Prova.Serap.Dominio;

namespace SME.Simulador.Prova.Serap.Dados;

public sealed class UnitOfWorkBaseSerapEstudantes : UnitOfWorkBaseBase<SerapEstudantesContexto>, IUnitOfWorkBaseSerapEstudantes
{
    public UnitOfWorkBaseSerapEstudantes(SerapEstudantesContexto contexto) : base(contexto)
    {
    }
}