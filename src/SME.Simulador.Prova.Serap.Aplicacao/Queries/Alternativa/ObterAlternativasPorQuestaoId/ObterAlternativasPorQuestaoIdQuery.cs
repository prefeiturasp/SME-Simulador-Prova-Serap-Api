using MediatR;
using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class ObterAlternativasPorQuestaoIdQuery : IRequest<IEnumerable<AlternativaDto>>
{
    public ObterAlternativasPorQuestaoIdQuery(long questaoId)
    {
        QuestaoId = questaoId;
    }

    public long QuestaoId { get; }
}