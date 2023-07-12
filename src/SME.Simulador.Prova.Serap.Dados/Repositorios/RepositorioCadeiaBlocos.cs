using SME.Simulador.Prova.Serap.Dados.Interfaces;
using SME.Simulador.Prova.Serap.Dominio;
using SME.Simulador.Prova.Serap.Infra.Dtos;

namespace SME.Simulador.Prova.Serap.Dados.Repositorios
{
    public class RepositorioCadeiaBlocos : IRepositorioCadeiaBlocos
    {
        private readonly GestaoAvaliacaoContexto gestaoAvaliacaoContexto;

        public RepositorioCadeiaBlocos(GestaoAvaliacaoContexto gestaoAvaliacaoContexto)
        {
            this.gestaoAvaliacaoContexto = gestaoAvaliacaoContexto ?? throw new ArgumentNullException(nameof(gestaoAvaliacaoContexto));
        }

        public async Task<CadeiaBlocoQuestaoDto> ObterBlocoIdPorItemEhProvaId(long provaId, long itemId)
        {
            const string query = @"SELECT BCI.Id
                                          BCI.BlockChain_Id as CadeiaBlocoId,
                                          BCI.Item_Id  as QuestaoId,
                                          BCI.Order as Ordem,
                                          BCI.CreateDate as DataCriacao,
                                          BCI.UpdateDate as DataAtualizacao
					                FROM BlockChainItem BCI WITH (NOLOCK) 
					                INNER JOIN BlockChain BC WITH (NOLOCK) ON BC.Id = BCI.BlockChain_Id
					                WHERE BCI.Item_Id = @itemId
					                 AND BC.Test_id =  @provaId
						             AND BCI.State = @state
						             AND BC.State = @state  ";

            return await gestaoAvaliacaoContexto.Conexao.QueryFirstOrDefaultAsync<CadeiaBlocoQuestaoDto>(query,
                new
                {
                    provaId,
                    itemId,
                    state = (int)LegadoState.Ativo
                }, transaction: gestaoAvaliacaoContexto.Transacao);
        }
    }
}
