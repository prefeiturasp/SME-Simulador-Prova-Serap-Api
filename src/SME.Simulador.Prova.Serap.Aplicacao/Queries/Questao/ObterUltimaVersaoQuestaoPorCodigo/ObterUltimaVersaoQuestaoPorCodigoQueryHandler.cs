using MediatR;
using SME.Simulador.Prova.Serap.Dados;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class ObterUltimaVersaoQuestaoPorCodigoQueryHandler : IRequestHandler<ObterUltimaVersaoQuestaoPorCodigoQuery, int>
{
    private readonly IRepositorioQuestao repositorioQuestao;

    public ObterUltimaVersaoQuestaoPorCodigoQueryHandler(IRepositorioQuestao repositorioQuestao)
    {
        this.repositorioQuestao = repositorioQuestao ?? throw new ArgumentNullException(nameof(repositorioQuestao));
    }

    public async Task<int> Handle(ObterUltimaVersaoQuestaoPorCodigoQuery request, CancellationToken cancellationToken)
    {
        return await repositorioQuestao.ObterUltimaVersaoDaQuestaoPorCodigo(request.CodigoItem);
    }
}