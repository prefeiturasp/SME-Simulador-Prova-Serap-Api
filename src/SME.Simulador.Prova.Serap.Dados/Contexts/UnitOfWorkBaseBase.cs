using SME.Simulador.Prova.Serap.Dominio;

namespace SME.Simulador.Prova.Serap.Dados;

public abstract class UnitOfWorkBaseBase<TContexto> :  IUnitOfWorkBase where TContexto : ContextoBase
{
    private readonly TContexto contexto;

    protected UnitOfWorkBaseBase(TContexto contexto)
    {
        this.contexto = contexto ?? throw new ArgumentNullException(nameof(contexto));
    }

    public void Dispose()
    {
        contexto.Transacao?.Dispose();
        GC.SuppressFinalize(this);
    }

    public void BeginTransaction()
    {
        contexto.Transacao = contexto.Conexao?.BeginTransaction();
    }

    public void Commit()
    {
        contexto.Transacao?.Commit();
        Dispose();
    }

    public void Rollback()
    {
        contexto.Transacao?.Rollback();
        Dispose();
    }
}