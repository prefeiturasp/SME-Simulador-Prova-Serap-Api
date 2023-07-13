using MediatR;
using SME.Simulador.Prova.Serap.Dominio;

namespace SME.Simulador.Prova.Serap.Aplicacao
{
    public class ObterListaQuestaoArquivoPorQuestaoIdQuery : IRequest<IEnumerable<QuestaoArquivo>>
    {
        public ObterListaQuestaoArquivoPorQuestaoIdQuery(long questaoId)
        {
            QuestaoId = questaoId;
        }
        public long QuestaoId { get; }
    }
}