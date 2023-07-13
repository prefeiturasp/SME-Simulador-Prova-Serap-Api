using SME.Simulador.Prova.Serap.Dados.Interfaces;
using SME.Simulador.Prova.Serap.Dominio;
using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.Dados;

public class RepositorioAlternativa : RepositorioGestaoAvaliacaoBase<Alternativa>, IRepositorioAlternativa
{
    private readonly GestaoAvaliacaoContexto gestaoAvaliacaoContexto;

    public RepositorioAlternativa(GestaoAvaliacaoContexto gestaoAvaliacaoContexto) : base(gestaoAvaliacaoContexto)
    {
        this.gestaoAvaliacaoContexto = gestaoAvaliacaoContexto ?? throw new ArgumentNullException(nameof(gestaoAvaliacaoContexto));
    }
    public async Task<IEnumerable<AlternativaDto>> ObterAlternativasPorQuestaoIdAsync(long questaoId)
    {
        const string query = @"SELECT 
                                    A.Id,
                                    A.Item_Id as QuestaoId,
                                    A.Numeration as Numeracao,
                                    A.Description as Descricao,
                                    A.[Order] as Ordem,
                                    A.Correct as Correta
                                FROM  Alternative A with (NOLOCK)
                                WHERE A.Item_Id = @questaoId;";

        return await gestaoAvaliacaoContexto.Conexao.QueryAsync<AlternativaDto>(query, new { questaoId },
            transaction: gestaoAvaliacaoContexto.Transacao);
    }
}