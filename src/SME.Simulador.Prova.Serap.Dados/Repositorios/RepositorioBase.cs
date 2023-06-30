using System.Data;
using Dommel;
using SME.Simulador.Prova.Serap.Dominio;

namespace SME.Simulador.Prova.Serap.Dados;

public class RepositorioBase<TEntidadeBase, TContexto> : IRepositorioBase<TEntidadeBase> 
    where TEntidadeBase : EntidadeBase
    where TContexto : ContextoBase
{
    private readonly TContexto contexto;

    protected RepositorioBase(TContexto contexto)
    {
        this.contexto = contexto ?? throw new ArgumentNullException(nameof(contexto));
    }

    protected IDbConnection ObterConexao()
    {
        return contexto.Conexao;
    }

    protected IDbTransaction? ObterTransacao()
    {
        return contexto.Transacao;
    }

    public virtual async Task<TEntidadeBase> ObterPorIdAsync(long id)
    {
        return await contexto.Conexao.GetAsync<TEntidadeBase>(id);
    }

    public virtual async Task<IEnumerable<TEntidadeBase>> ObterTudoAsync()
    {
        return await contexto.Conexao.GetAllAsync<TEntidadeBase>();
    }

    public virtual async Task<long> SalvarAsync(TEntidadeBase entidade)
    {
        if (entidade.Id > 0)
            await contexto.Conexao.UpdateAsync(entidade);
        else
            entidade.Id = (long)await contexto.Conexao.InsertAsync(entidade);

        return entidade.Id;
    }

    public virtual async Task<long> UpdateAsync(TEntidadeBase entidade)
    {
        await contexto.Conexao.UpdateAsync(entidade);
        return entidade.Id;
    }

    public virtual async Task<long> IncluirAsync(TEntidadeBase entidade)
    {
        entidade.Id = (long)await contexto.Conexao.InsertAsync(entidade);
        return entidade.Id;
    }

    public virtual async Task<bool> RemoverFisicamenteAsync(TEntidadeBase entidade)
    {
        return await contexto.Conexao.DeleteAsync(entidade);
    }
}