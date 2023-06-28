using MediatR;
using SME.Simulador.Prova.Serap.Dados;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class ObterEhProvaIniciadaQueryHandler : IRequestHandler<ObterEhProvaIniciadaQuery, bool>
{
    private readonly IRepositorioProvaLegado repositorioProvaLegado;

    public ObterEhProvaIniciadaQueryHandler(IRepositorioProvaLegado repositorioProvaLegado)
    {
        this.repositorioProvaLegado = repositorioProvaLegado ?? throw new ArgumentNullException(nameof(repositorioProvaLegado));
    }

    public async Task<bool> Handle(ObterEhProvaIniciadaQuery request, CancellationToken cancellationToken)
    {
        return await repositorioProvaLegado.EhProvaIniciadaAsync(request.ProvaId);
    }
}