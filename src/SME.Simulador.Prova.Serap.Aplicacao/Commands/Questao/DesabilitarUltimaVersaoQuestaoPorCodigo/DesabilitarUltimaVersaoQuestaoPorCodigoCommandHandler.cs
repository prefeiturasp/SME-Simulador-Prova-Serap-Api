using MediatR;
using SME.Simulador.Prova.Serap.Dados;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class DesabilitarUltimaVersaoQuestaoPorCodigoCommandHandler : IRequestHandler<DesabilitarUltimaVersaoQuestaoPorCodigoCommand, int>
{
    private readonly IRepositorioQuestao repositorioQuestao;

    public DesabilitarUltimaVersaoQuestaoPorCodigoCommandHandler(IRepositorioQuestao repositorioQuestao)
    {
        this.repositorioQuestao = repositorioQuestao;
    }

    public async Task<int> Handle(DesabilitarUltimaVersaoQuestaoPorCodigoCommand request, CancellationToken cancellationToken)
    {
        return await repositorioQuestao.DesabilitaUltimaVersaoQuestao(request.CodigoQuestao);
    }
}