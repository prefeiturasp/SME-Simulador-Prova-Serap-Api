using MediatR;
using SME.Simulador.Prova.Serap.Dados;
using SME.Simulador.Prova.Serap.Infra.Dtos;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class ObterCadeiaBlocoQuestaoPorItemEProvaIdQueryHandler : IRequestHandler<ObterCadeiaBlocoQuestaoPorItemEProvaIdQuery, CadeiaBlocoQuestaoDto?>
{
    private readonly IRepositorioCadeiaBlocos repositorioCadeiaBlocos;
    public ObterCadeiaBlocoQuestaoPorItemEProvaIdQueryHandler(IRepositorioCadeiaBlocos repositorioCadeiaBlocos)
    {
        this.repositorioCadeiaBlocos = repositorioCadeiaBlocos ?? throw new ArgumentNullException(nameof(repositorioCadeiaBlocos));
    }
    
    public async Task<CadeiaBlocoQuestaoDto?> Handle(ObterCadeiaBlocoQuestaoPorItemEProvaIdQuery request, CancellationToken cancellationToken)
    {
        return await repositorioCadeiaBlocos.ObterBlocoIdPorItemEProvaId(request.ProvaId, request.ItemId);
    }
}