using MediatR;
using SME.Simulador.Prova.Serap.Dados;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class IncluirQuestaoArquivoCommandHandler : IRequestHandler<IncluirQuestaoArquivoCommand, long>
{
    private readonly IRepositorioQuestaoArquivo repositorioQuestaoArquivo;

    public IncluirQuestaoArquivoCommandHandler(IRepositorioQuestaoArquivo repositorioQuestaoArquivo)
    {
        this.repositorioQuestaoArquivo = repositorioQuestaoArquivo;
    }

    public async Task<long> Handle(IncluirQuestaoArquivoCommand request, CancellationToken cancellationToken)
    {
        return await repositorioQuestaoArquivo.SalvarAsync(request.QuestaoArquivo);
    }
}