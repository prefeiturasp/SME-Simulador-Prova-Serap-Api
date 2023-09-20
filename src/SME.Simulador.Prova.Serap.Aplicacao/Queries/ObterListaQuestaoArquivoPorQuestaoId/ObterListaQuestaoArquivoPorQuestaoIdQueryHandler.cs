using MediatR;
using SME.Simulador.Prova.Serap.Dados;
using SME.Simulador.Prova.Serap.Dominio;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class ObterListaQuestaoArquivoPorQuestaoIdQueryHandler : IRequestHandler<ObterListaQuestaoArquivoPorQuestaoIdQuery, IEnumerable<QuestaoArquivo>>
{
    private readonly IRepositorioQuestaoArquivo repositorioQuestaoArquivo;
    
    public ObterListaQuestaoArquivoPorQuestaoIdQueryHandler(IRepositorioQuestaoArquivo repositorioQuestaoArquivo)
    {
        this.repositorioQuestaoArquivo = repositorioQuestaoArquivo ?? throw new ArgumentNullException(nameof(repositorioQuestaoArquivo));
    }
    
    public async Task<IEnumerable<QuestaoArquivo>> Handle(ObterListaQuestaoArquivoPorQuestaoIdQuery request, CancellationToken cancellationToken)
    {
        return await repositorioQuestaoArquivo.ObterListaQuestaoArquivos(request.QuestaoId);
    }
}