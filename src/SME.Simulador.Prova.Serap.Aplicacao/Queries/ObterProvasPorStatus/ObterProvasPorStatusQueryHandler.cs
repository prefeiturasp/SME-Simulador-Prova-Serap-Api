using MediatR;
using SME.Simulador.Prova.Serap.Dados;
using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class ObterProvasPorStatusQueryHandler : IRequestHandler<ObterProvasPorStatusQuery, IEnumerable<ProvaDto>>
{
    private readonly IRepositorioProva repositorioProva;

    public ObterProvasPorStatusQueryHandler(IRepositorioProva repositorioProva)
    {
        this.repositorioProva = repositorioProva ?? throw new ArgumentNullException(nameof(repositorioProva));
    }

    public async Task<IEnumerable<ProvaDto>> Handle(ObterProvasPorStatusQuery request, CancellationToken cancellationToken)
    {
        return await repositorioProva.ObterProvasPorStatusAsync(request.Status);
    }
}