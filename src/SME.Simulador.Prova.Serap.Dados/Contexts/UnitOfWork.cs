using System.Data;
using SME.Simulador.Prova.Serap.Dominio;

namespace SME.Simulador.Prova.Serap.Dados;

public class UnitOfWork : IUnitOfWork
{
    private readonly GestaoAvaliacaoContext gestaoAvaliacaoContext;

    public UnitOfWork(GestaoAvaliacaoContext gestaoAvaliacaoContext)
    {
        this.gestaoAvaliacaoContext = gestaoAvaliacaoContext ?? throw new ArgumentNullException(nameof(gestaoAvaliacaoContext));
    }

    public void Dispose()
    {
        gestaoAvaliacaoContext.Transacao?.Dispose();
        GC.SuppressFinalize(this);
    }

    public void BeginTransaction()
    {
        gestaoAvaliacaoContext.Transacao = gestaoAvaliacaoContext.Conexao.BeginTransaction();
    }

    public void Commit()
    {
        gestaoAvaliacaoContext.Transacao?.Commit();
        Dispose();
    }

    public void Rollback()
    {
        gestaoAvaliacaoContext.Transacao?.Rollback();
        Dispose();
    }
}