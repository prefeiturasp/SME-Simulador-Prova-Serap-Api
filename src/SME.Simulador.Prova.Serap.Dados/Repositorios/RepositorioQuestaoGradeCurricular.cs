using SME.Simulador.Prova.Serap.Dados.Interfaces;
using SME.Simulador.Prova.Serap.Dominio;

namespace SME.Simulador.Prova.Serap.Dados.Repositorios
{
    public class RepositorioQuestaoGradeCurricular : RepositorioGestaoAvaliacaoBase<QuestaoGradeCurricular>, IRepositorioQuestaoGradeCurricular
    {
        private readonly GestaoAvaliacaoContexto gestaoAvaliacaoContexto;

        public RepositorioQuestaoGradeCurricular(GestaoAvaliacaoContexto gestaoAvaliacaoContexto) : base(gestaoAvaliacaoContexto)
        {
            this.gestaoAvaliacaoContexto = gestaoAvaliacaoContexto ?? throw new ArgumentNullException(nameof(gestaoAvaliacaoContexto));
        }

        public async Task<IEnumerable<QuestaoGradeCurricular>> ObterListaQuestaoGradesCurriculares(long questaoId)
        {
            const string query = @"SELECT  [Id] 
                                          ,[CreateDate] as DataCriacao
                                          ,[UpdateDate] as DataAtualizacao
                                          ,[State] as Situacao
                                          ,[Item_Id] as QuestaoId
                                          ,[TypeCurriculumGradeId] as  TipoGradeCurricular
                                          FROM [GestaoAvaliacao].[dbo].[ItemCurriculumGrade]
                                     WHERE Item_id = @questaoId
                                       AND State = @state";

            return await gestaoAvaliacaoContexto.Conexao.QueryAsync<QuestaoGradeCurricular>(query,
                new
                {
                    questaoId,
                    state = (int)LegadoState.Ativo
                }, transaction: gestaoAvaliacaoContexto.Transacao);
        }
    }
}
