using MediatR;
using SME.Simulador.Prova.Serap.Dominio;

namespace SME.Simulador.Prova.Serap.Aplicacao
{
    public class ObterListaQuestaoHabilidadesPorQuestaoIdQuery : IRequest<IEnumerable<QuestaoHabilidade>>
    {
        public ObterListaQuestaoHabilidadesPorQuestaoIdQuery(long questaoId)
        {
            QuestaoId = questaoId;
        }
        public long QuestaoId { get; }
    }
}