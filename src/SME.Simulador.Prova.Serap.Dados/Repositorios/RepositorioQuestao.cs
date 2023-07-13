using SME.Simulador.Prova.Serap.Dominio;
using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.Dados;

public class RepositorioQuestao : RepositorioGestaoAvaliacaoBase<Questao>, IRepositorioQuestao
{
	private readonly GestaoAvaliacaoContexto gestaoAvaliacaoContexto;

	public RepositorioQuestao(GestaoAvaliacaoContexto gestaoAvaliacaoContexto) : base(gestaoAvaliacaoContexto)
    {
		this.gestaoAvaliacaoContexto = gestaoAvaliacaoContexto ?? throw new ArgumentNullException(nameof(gestaoAvaliacaoContexto));
	}

	public async Task<QuestaoSerapDto> ObterQuestaoCadernoProvaAsync(long questaoId, long cadernoId)
	{
		const string query = @" with questoes as (
			                            SELECT distinct I.id, B.Description as Caderno,
			                                    (DENSE_RANK() OVER(ORDER BY CASE WHEN (t.KnowledgeAreaBlock = 1) THEN ISNULL(Bka.[Order], 0) END, bi.[Order]) - 1) AS Ordem,
			                                    I.[Statement] as Enunciado ,bt.Description  as TextoBase, T.Id as ProvaId,
			                                    case 
	            				                    when IT.QuantityAlternative > 0 then 1 else 2
				                                end TipoItem,
			                                    IT.QuantityAlternative as QuantidadeAlternativas
			                                    FROM Item I WITH (NOLOCK)
			                                    INNER JOIN BlockItem BI WITH (NOLOCK) ON BI.Item_Id = I.Id
			                                    INNER JOIN ItemType IT  WITH (NOLOCK) ON I.ItemType_Id = IT.Id  
			                                    INNER JOIN Block B WITH (NOLOCK) ON B.Id = BI.Block_Id            
			                                    INNER JOIN Test T WITH (NOLOCK) ON T.Id = B.[Test_Id] 
			                                    INNER JOIN BaseText bt  on bt.Id = I.BaseText_Id       
			                                     LEFT JOIN BlockKnowledgeArea Bka WITH (NOLOCK) ON Bka.KnowledgeArea_Id = I.KnowledgeArea_Id AND B.Id = Bka.Block_Id
			                                WHERE B.Id = @cadernoId                                  
			                                  and BI.State = 1)

			                            select q.Id, q.Caderno, q.Ordem, q.Enunciado, q.TextoBase, q.ProvaId, q.TipoItem, q.QuantidadeAlternativas,
												anterior.Id as QuestaoAnteriorId,
												proxima.Id as ProximaQuestaoId
												from questoes q
												left join (select distinct Id, Ordem from questoes) anterior on anterior.Ordem = q.Ordem - 1
												left join (select distinct Id, Ordem from questoes) proxima on proxima.Ordem = q.Ordem + 1
												where q.Id = @questaoId
												order by q.Ordem;";

		return await gestaoAvaliacaoContexto.Conexao.QueryFirstOrDefaultAsync<QuestaoSerapDto>(query,
			new { questaoId, cadernoId }, transaction: gestaoAvaliacaoContexto.Transacao);
	}

	public async Task<IEnumerable<QuestaoResumoDto>> ObterQuestoesResumoPorCadernoIdAsync(long cadernoId)
	{
		const string query = @"with questoes as (
		                            SELECT distinct I.id, 
                            			bt.Description as TextoBase, 
                            			I.[Statement] as Enunciado, 
                            			B.Description as Caderno,
			                            (DENSE_RANK() OVER(ORDER BY CASE WHEN (t.KnowledgeAreaBlock = 1) THEN ISNULL(Bka.[Order], 0) END, bi.[Order]) - 1) AS Ordem,
										T.Id as IdProva,
										T.Description as DescricaoProva
		                            FROM Item I WITH (NOLOCK)
			                            INNER JOIN BlockItem BI WITH (NOLOCK) ON BI.Item_Id = I.Id
		                                INNER JOIN ItemType IT  WITH (NOLOCK) ON I.ItemType_Id = IT.Id  
		                                INNER JOIN Block B WITH (NOLOCK) ON B.Id = BI.Block_Id            
		                                INNER JOIN Test T WITH (NOLOCK) ON T.Id = B.[Test_Id] 
		                                INNER JOIN BaseText bt  on bt.Id = I.BaseText_Id       
		                                 LEFT JOIN BlockKnowledgeArea Bka WITH (NOLOCK) ON Bka.KnowledgeArea_Id = I.KnowledgeArea_Id AND B.Id = Bka.Block_Id
		                            WHERE B.Id = @cadernoId                                  
		                              and BI.State = 1)
		                            select q.Id, 
                            			q.TextoBase, 
                            			q.Enunciado, 
                            			q.Caderno, 
                            			q.Ordem, 
										q.IdProva,
										q.DescricaoProva,
										anterior.Id as QuestaoAnteriorId,
										proxima.Id as ProximaQuestaoId
									from questoes q
										left join (select distinct Id, Ordem from questoes) anterior on anterior.Ordem = q.Ordem - 1
										left join (select distinct Id, Ordem from questoes) proxima on proxima.Ordem = q.Ordem + 1
									order by q.Ordem;";

		return await gestaoAvaliacaoContexto.Conexao.QueryAsync<QuestaoResumoDto>(query, new { cadernoId },
			transaction: gestaoAvaliacaoContexto.Transacao);
	}
}