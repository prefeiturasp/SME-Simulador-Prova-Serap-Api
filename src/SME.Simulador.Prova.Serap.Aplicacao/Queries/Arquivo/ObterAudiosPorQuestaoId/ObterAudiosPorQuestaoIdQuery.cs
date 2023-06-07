using MediatR;
using SME.Simulador.Prova.Serap.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
