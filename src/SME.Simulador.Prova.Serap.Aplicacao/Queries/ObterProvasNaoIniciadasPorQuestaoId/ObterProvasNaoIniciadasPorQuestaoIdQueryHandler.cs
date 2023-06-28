using MediatR;
using SME.Simulador.Prova.Serap.Dados;
using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class ObterProvasNaoIniciadasPorQuestaoIdQueryHandler : IRequestHandler<ObterProvasNaoIniciadasPorQuestaoIdQuery, IEnumerable<ProvaLegadoDto>>
{
    private readonly IRepositorioProvaLegado repositorioProvaLegado;

    public ObterProvasNaoIniciadasPorQuestaoIdQueryHandler(IRepositorioProvaLegado repositorioProvaLegado)
    {
        this.repositorioProvaLegado = repositorioProvaLegado ?? throw new ArgumentNullException(nameof(repositorioProvaLegado));
    }

    public async Task<IEnumerable<ProvaLegadoDto>> Handle(ObterProvasNaoIniciadasPorQuestaoIdQuery request, CancellationToken cancellationToken)
    {
        return await repositorioProvaLegado.ObterProvasNaoIniciadasPorQuestaoIdAsync(request.QuestaoId);
    }
}