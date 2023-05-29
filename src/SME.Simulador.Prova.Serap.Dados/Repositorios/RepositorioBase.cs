using System.Data;
using Dommel;
using SME.Simulador.Prova.Serap.Dominio;

namespace SME.Simulador.Prova.Serap.Dados;

public class RepositorioBase<TEntidadeBase> : IRepositorioBase<TEntidadeBase> where TEntidadeBase : EntidadeBase
{
    private readonly GestaoAvaliacaoContext gestaoAvaliacaoContext;

    public RepositorioBase(GestaoAvaliacaoContext gestaoAvaliacaoContext)
    {
        this.gestaoAvaliacaoContext = gestaoAvaliacaoContext ?? throw new ArgumentNullException(nameof(gestaoAvaliacaoContext));
    }

    protected IDbConnection ObterConexao()
    {
        return gestaoAvaliacaoContext.Conexao;
    }

    public virtual async Task<TEntidadeBase> ObterPorIdAsync(long id)
    {
        return await gestaoAvaliacaoContext.Conexao.GetAsync<TEntidadeBase>(id);
    }

    public virtual async Task<IEnumerable<TEntidadeBase>> ObterTudoAsync()
    {
        return await gestaoAvaliacaoContext.Conexao.GetAllAsync<TEntidadeBase>();
    }

    public virtual async Task<long> SalvarAsync(TEntidadeBase entidade)
    {
        if (entidade.Id > 0)
            await gestaoAvaliacaoContext.Conexao.UpdateAsync(entidade);
        else
            entidade.Id = (long)await gestaoAvaliacaoContext.Conexao.InsertAsync(entidade);

        return entidade.Id;
    }

    public virtual async Task<long> UpdateAsync(TEntidadeBase entidade)
    {
        await gestaoAvaliacaoContext.Conexao.UpdateAsync(entidade);
        return entidade.Id;
    }

    public virtual async Task<long> IncluirAsync(TEntidadeBase entidade)
    {
        entidade.Id = (long)await gestaoAvaliacaoContext.Conexao.InsertAsync(entidade);
        return entidade.Id;
    }

    public virtual async Task<bool> RemoverFisicamenteAsync(TEntidadeBase entidade)
    {
        return await gestaoAvaliacaoContext.Conexao.DeleteAsync(entidade);
    }
}