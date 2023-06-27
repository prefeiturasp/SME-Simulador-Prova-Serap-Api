using Dapper;
using SME.Simulador.Prova.Serap.Dominio;
using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.Dados;

public class RepositorioProva : IRepositorioProva
{
    private readonly SerapEstudantesContexto serapEstudantesContexto;

    public RepositorioProva(SerapEstudantesContexto serapEstudantesContexto)
    {
        this.serapEstudantesContexto = serapEstudantesContexto ?? throw new ArgumentNullException(nameof(serapEstudantesContexto));
    }

    public async Task<bool> EhProvaIniciadaAsync(long provaLegadoId)
    {
        const string query = @"select pa.id as provaAlunoId
                                from prova p
                                inner join prova_aluno pa on p.id = pa.prova_id
                                where pa.status = @status
                                and p.prova_legado_id = @provaLegadoId
                                and (p.tempo_execucao > 0 or (p.tempo_execucao = 0 and NOW()::timestamp > p.fim))
                                order by p.id,pa.aluno_ra
                                limit 1";

        var provaAlunoId = await serapEstudantesContexto.Conexao.QuerySingleOrDefaultAsync<long>(query,
            new { status = (int)ProvaStatus.Iniciado, provaLegadoId },
            transaction: serapEstudantesContexto.Transacao);

        return provaAlunoId > 0;
    }

    public async Task<IEnumerable<ProvaDto>> ObterProvasPorStatusAsync(ProvaStatus status)
    {
        const string query = @"select distinct p.id,
                                    p.prova_legado_id as provalegadoid
                                from prova p
                                inner join prova_aluno pa on p.id = pa.prova_id
                                where (p.tempo_execucao > 0 or (p.tempo_execucao = 0 and NOW()::timestamp > p.fim))
                                and pa.status = @status";

        return await serapEstudantesContexto.Conexao.QueryAsync<ProvaDto>(query,
            new { status }, transaction: serapEstudantesContexto.Transacao);
    }
}