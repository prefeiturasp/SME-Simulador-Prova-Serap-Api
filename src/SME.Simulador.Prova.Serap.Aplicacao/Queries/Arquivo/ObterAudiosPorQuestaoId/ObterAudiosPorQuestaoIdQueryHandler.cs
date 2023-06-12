using MediatR;
using SME.Simulador.Prova.Serap.Dados;
using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class ObterAudiosPorQuestaoIdQueryHandler : IRequestHandler<ObterAudiosPorQuestaoIdQuery, IEnumerable<ArquivoDto>>
{
    private readonly IRepositorioArquivo repositorioArquivo;

    public ObterAudiosPorQuestaoIdQueryHandler(IRepositorioArquivo repositorioArquivo)
    {
        this.repositorioArquivo = repositorioArquivo ?? throw new ArgumentNullException(nameof(repositorioArquivo));
    }

    public async Task<IEnumerable<ArquivoDto>> Handle(ObterAudiosPorQuestaoIdQuery request, CancellationToken cancellationToken)
    {
        return await repositorioArquivo.ObterAudiosPorQuestaoId(request.QuestaoId);
    }
}