using MediatR;
using SME.Simulador.Prova.Serap.Dados;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class CadeiaBlocoQuestaoCommandHandler : IRequestHandler<CadeiaBlocoQuestaoCommand, long>
{
    private readonly IRepositorioCadeiaBlocos repositorioCadeiaBloco;

    public CadeiaBlocoQuestaoCommandHandler(IRepositorioCadeiaBlocos repositorioCadeiaBloco)
    {
        this.repositorioCadeiaBloco = repositorioCadeiaBloco;
    }

    public async Task<long> Handle(CadeiaBlocoQuestaoCommand request, CancellationToken cancellationToken)
    {
        return await repositorioCadeiaBloco.SalvarAsync(request.CadeiaBlocoQuestao) ;
    }
}