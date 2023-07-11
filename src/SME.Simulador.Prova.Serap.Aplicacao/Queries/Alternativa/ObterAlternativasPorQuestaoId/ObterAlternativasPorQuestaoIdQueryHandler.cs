using MediatR;
using SME.Simulador.Prova.Serap.Dados;
using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class ObterAlternativasPorQuestaoIdQueryHandler : IRequestHandler<ObterAlternativasPorQuestaoIdQuery, IEnumerable<AlternativaDto>>
{
    private readonly IRepositorioAlternativa repositorioAlternativa;

    public ObterAlternativasPorQuestaoIdQueryHandler(IRepositorioAlternativa repositorioAlternativa)
    {
        this.repositorioAlternativa = repositorioAlternativa ?? throw new ArgumentNullException(nameof(repositorioAlternativa));
    }

    public async Task<IEnumerable<AlternativaDto>> Handle(ObterAlternativasPorQuestaoIdQuery request, CancellationToken cancellationToken)
    {
        return await repositorioAlternativa.ObterAlternativasPorQuestaoIdAsync(request.QuestaoId);
    }
}