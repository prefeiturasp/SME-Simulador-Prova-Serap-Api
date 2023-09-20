using MediatR;
using SME.Simulador.Prova.Serap.Dados;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class IncluirTextoBaseCommandHandler : IRequestHandler<IncluirTextoBaseCommand, long>
{
    private readonly IRepositorioTextoBase repositorioTextoBase;

    public IncluirTextoBaseCommandHandler(IRepositorioTextoBase repositorioTextoBase)
    {
        this.repositorioTextoBase = repositorioTextoBase;
    }

    public async Task<long> Handle(IncluirTextoBaseCommand request, CancellationToken cancellationToken)
    {
        return await repositorioTextoBase.SalvarAsync(request.TextoBase);
    }
}