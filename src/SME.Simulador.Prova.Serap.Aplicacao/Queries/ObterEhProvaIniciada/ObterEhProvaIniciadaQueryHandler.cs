using MediatR;
using SME.Simulador.Prova.Serap.Dados;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class ObterEhProvaIniciadaQueryHandler : IRequestHandler<ObterEhProvaIniciadaQuery, bool>
{
    private readonly IRepositorioProva repositorioProva;

    public ObterEhProvaIniciadaQueryHandler(IRepositorioProva repositorioProva)
    {
        this.repositorioProva = repositorioProva ?? throw new ArgumentNullException(nameof(repositorioProva));
    }

    public async Task<bool> Handle(ObterEhProvaIniciadaQuery request, CancellationToken cancellationToken)
    {
        return await repositorioProva.EhProvaIniciadaAsync(request.ProvaLegadoId);
    }
}