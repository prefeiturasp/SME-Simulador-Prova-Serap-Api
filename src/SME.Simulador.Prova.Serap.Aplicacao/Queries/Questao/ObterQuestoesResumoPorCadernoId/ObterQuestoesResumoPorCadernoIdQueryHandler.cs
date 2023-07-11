using MediatR;
using SME.Simulador.Prova.Serap.Dados;
using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class ObterQuestoesResumoPorCadernoIdQueryHandler : IRequestHandler<ObterQuestoesResumoPorCadernoIdQuery, IEnumerable<QuestaoResumoDto>>
{
    private readonly IRepositorioQuestao repositorioQuestao;

    public ObterQuestoesResumoPorCadernoIdQueryHandler(IRepositorioQuestao repositorioQuestao)
    {
        this.repositorioQuestao = repositorioQuestao ?? throw new ArgumentNullException(nameof(repositorioQuestao));
    }

    public async Task<IEnumerable<QuestaoResumoDto>> Handle(ObterQuestoesResumoPorCadernoIdQuery request, CancellationToken cancellationToken)
    {
        return await repositorioQuestao.ObterQuestoesResumoPorCadernoIdAsync(request.CadernoId);
    }
}