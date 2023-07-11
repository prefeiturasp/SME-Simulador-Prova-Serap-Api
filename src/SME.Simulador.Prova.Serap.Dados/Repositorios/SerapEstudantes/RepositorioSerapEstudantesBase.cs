using SME.Simulador.Prova.Serap.Dominio;

namespace SME.Simulador.Prova.Serap.Dados;

public class RepositorioSerapEstudantesBase<TEntidadeBase> : RepositorioBase<TEntidadeBase, SerapEstudantesContexto> 
    where TEntidadeBase : EntidadeBase
{
    protected RepositorioSerapEstudantesBase(SerapEstudantesContexto contexto) : base(contexto)
    {
    }
}