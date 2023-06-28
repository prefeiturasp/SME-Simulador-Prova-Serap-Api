using Dapper;
using SME.Simulador.Prova.Serap.Dominio;

namespace SME.Simulador.Prova.Serap.Dados;

public class RepositorioProvaLegado : IRepositorioProvaLegado
{
    private readonly GestaoAvaliacaoContexto gestaoAvaliacaoContexto;

    public RepositorioProvaLegado(GestaoAvaliacaoContexto gestaoAvaliacaoContexto)
    {
        this.gestaoAvaliacaoContexto = gestaoAvaliacaoContexto ?? throw new ArgumentNullException(nameof(gestaoAvaliacaoContexto));
    }

    public async Task<bool> EhProvaIniciadaAsync(long provaId)
    {
        const string query = @"select top 1 t.Id
                                from Test t
                                where t.Id = @provaId
                                and t.State = @state
                                and GETDATE() > t.ApplicationStartDate and GETDATE() <= t.ApplicationEndDate
                                order by t.Id";

        var id = await gestaoAvaliacaoContexto.Conexao.QuerySingleOrDefaultAsync<long>(query,
            new { provaId, state = (int)LegadoState.Ativo },
            transaction: gestaoAvaliacaoContexto.Transacao);

        return id > 0;
    }
}