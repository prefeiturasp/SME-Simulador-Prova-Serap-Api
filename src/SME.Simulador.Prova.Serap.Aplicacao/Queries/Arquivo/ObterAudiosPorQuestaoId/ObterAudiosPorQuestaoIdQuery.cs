using MediatR;
using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.Aplicacao
{
    public class ObterAudiosPorQuestaoIdQuery : IRequest<IEnumerable<ArquivoDto>>
    {

        public ObterAudiosPorQuestaoIdQuery(long questaoId)
        {
            QuestaoId = questaoId;
        }

        public long QuestaoId { get; set; }

    }
}
