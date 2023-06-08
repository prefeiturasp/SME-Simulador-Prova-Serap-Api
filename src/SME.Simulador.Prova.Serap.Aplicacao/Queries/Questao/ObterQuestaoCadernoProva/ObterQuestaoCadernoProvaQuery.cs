using MediatR;
using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.Aplicacao
{
    public class ObterQuestaoCadernoProvaQuery : IRequest<QuestaoSerapDto>
    {
        public ObterQuestaoCadernoProvaQuery(long questaoId, long provaId, string? caderno)
        {
            QuestaoId = questaoId;
            ProvaId = provaId;
            Caderno = caderno;
        }

        public long QuestaoId { get; set; }
        public long ProvaId { get; set; }
        public string? Caderno { get; set; }
    }
}
