using SME.Simulador.Prova.Serap.Dados.Interfaces;
using SME.Simulador.Prova.Serap.Dominio;
using SME.Simulador.Prova.Serap.Infra;
using SME.Simulador.Prova.Serap.Infra.Dtos;

namespace SME.Simulador.Prova.Serap.Dados.Repositorios
{
    public class RepositorioBlocoQuestao : RepositorioGestaoAvaliacaoBase<QuestaoBloco>, IRepositorioBlocoQuestao
    {
        private readonly GestaoAvaliacaoContexto gestaoAvaliacaoContexto;

        public RepositorioBlocoQuestao(GestaoAvaliacaoContexto gestaoAvaliacaoContexto) : base(gestaoAvaliacaoContexto)
        {
            this.gestaoAvaliacaoContexto = gestaoAvaliacaoContexto ?? throw new ArgumentNullException(nameof(gestaoAvaliacaoContexto));
        }

        public async Task<BlocoItemDto> ObterBlocoIdPorItemEhProvaId(long provaId, long itemId)
        {
            const string query = @"SELECT  [Block_Id] as BlocoId
                                                     ,BI.[Item_Id] as ItemId
                                                     ,BI.[Id]
                                                     ,BI.[Order] as Ordem
                                                     ,BI.[CreateDate] as DataCriacao
                                                 FROM [GestaoAvaliacao].[dbo].[BlockItem] as BI
                                                   INNER JOIN Block B WITH (NOLOCK) ON B.Id = BI.Block_Id
                                                   WHERE B.Test_id = @provaId 
                                                     AND BI.Item_Id = @itemId
                                                     AND  BI.State = @state";

            return await gestaoAvaliacaoContexto.Conexao.QueryFirstOrDefaultAsync<BlocoItemDto>(query,
                new
                {
                    provaId,
                    itemId,
                    state = (int)LegadoState.Ativo
                }, transaction: gestaoAvaliacaoContexto.Transacao);
        }
    }
}
