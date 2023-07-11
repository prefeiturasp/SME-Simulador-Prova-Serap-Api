using SME.Simulador.Prova.Serap.Dominio;

namespace SME.Simulador.Prova.Serap.Dados;

public class RepositorioExecucaoControle : IRepositorioExecucaoControle
{
    private readonly SerapEstudantesContexto serapEstudantesContexto;

    public RepositorioExecucaoControle(SerapEstudantesContexto serapEstudantesContexto)
    {
        this.serapEstudantesContexto = serapEstudantesContexto ?? throw new ArgumentNullException(nameof(serapEstudantesContexto));
    }

    public async Task<ExecucaoControle> ObterUltimaExecucaoPorTipoAsync(ExecucaoControleTipo execucaoControleTipo)
    {
        const string query = @"select Id,
                                    execucao_tipo as ExecucaoTipo,
                                    ultima_execucao as UltimaExecucao
                                from execucao_controle
                                where execucao_tipo = @execucaoControleTipo";

        return await serapEstudantesContexto.Conexao.QueryFirstOrDefaultAsync<ExecucaoControle>(query,
            new { execucaoControleTipo }, transaction: serapEstudantesContexto.Transacao);
    }
}