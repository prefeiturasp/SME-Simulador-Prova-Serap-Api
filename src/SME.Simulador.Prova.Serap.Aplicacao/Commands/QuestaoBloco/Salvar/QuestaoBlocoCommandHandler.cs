using MediatR;
using SME.Simulador.Prova.Serap.Dados;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class QuestaoBlocoCommandHandler : IRequestHandler<QuestaoBlocoCommand, long>
{
    private readonly IRepositorioBlocoQuestao repositorioBlocoItems;

    public QuestaoBlocoCommandHandler(IRepositorioBlocoQuestao repositorioBlocoItems)
    {
        this.repositorioBlocoItems = repositorioBlocoItems;
    }

    public async Task<long> Handle(QuestaoBlocoCommand request, CancellationToken cancellationToken)
    {
        return await repositorioBlocoItems.SalvarAsync(request.QuestaoBloco);
    }
}