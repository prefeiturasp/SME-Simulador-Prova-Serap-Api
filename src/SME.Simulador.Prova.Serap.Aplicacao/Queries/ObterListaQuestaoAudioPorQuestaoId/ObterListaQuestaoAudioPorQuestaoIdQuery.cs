using MediatR;
using SME.Simulador.Prova.Serap.Dominio;

namespace SME.Simulador.Prova.Serap.Aplicacao.Queries.ObterListaQuestaoAudioPorQuestaoId
{
    public class ObterListaQuestaoAudioPorQuestaoIdQuery : IRequest<IEnumerable<QuestaoAudio>>
    {
        public ObterListaQuestaoAudioPorQuestaoIdQuery(long questaoId)
        {
            QuestaoId = questaoId;
        }
        public long QuestaoId { get; }
    }
}