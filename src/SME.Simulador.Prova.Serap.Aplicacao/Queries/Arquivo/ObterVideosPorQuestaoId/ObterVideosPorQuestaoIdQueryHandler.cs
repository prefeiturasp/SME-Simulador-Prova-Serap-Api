using MediatR;
using SME.Simulador.Prova.Serap.Dados;
using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class ObterVideosPorQuestaoIdQueryHandler : IRequestHandler<ObterVideosPorQuestaoIdQuery, IEnumerable<VideoDto>>
{
    private readonly IRepositorioArquivo repositorioArquivo;

    public ObterVideosPorQuestaoIdQueryHandler(IRepositorioArquivo repositorioArquivo)
    {
        this.repositorioArquivo = repositorioArquivo ?? throw new ArgumentNullException(nameof(repositorioArquivo));
    }

    public async Task<IEnumerable<VideoDto>> Handle(ObterVideosPorQuestaoIdQuery request, CancellationToken cancellationToken)
    {
        return await repositorioArquivo.ObterVideosPorQuestaoId(request.QuestaoId);
    }
}