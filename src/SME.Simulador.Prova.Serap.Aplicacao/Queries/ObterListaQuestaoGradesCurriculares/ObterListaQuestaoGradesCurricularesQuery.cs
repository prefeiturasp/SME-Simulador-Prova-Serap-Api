using MediatR;
using SME.Simulador.Prova.Serap.Dominio;

namespace SME.Simulador.Prova.Serap.Aplicacao
{ 
    public class ObterListaQuestaoGradesCurricularesQuery : IRequest<IEnumerable<QuestaoGradeCurricular>>
    {
        public ObterListaQuestaoGradesCurricularesQuery(long questaoId)
        {
            QuestaoId = questaoId;
        }
        public long QuestaoId { get; }
    }
}