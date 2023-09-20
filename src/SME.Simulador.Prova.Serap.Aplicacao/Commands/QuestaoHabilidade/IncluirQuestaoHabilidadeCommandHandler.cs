using MediatR;
using SME.Simulador.Prova.Serap.Dados;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class IncluirQuestaoHabilidadeCommandHandler : IRequestHandler<IncluirQuestaoHabilidadeCommand, long>
{
    private readonly IRepositorioQuestaoHabilidade repositorioQuestaoHabilidade;

    public IncluirQuestaoHabilidadeCommandHandler(IRepositorioQuestaoHabilidade repositorioQuestaoHabilidade)
    {
        this.repositorioQuestaoHabilidade = repositorioQuestaoHabilidade;
    }

    public async Task<long> Handle(IncluirQuestaoHabilidadeCommand request, CancellationToken cancellationToken)
    {
        return await repositorioQuestaoHabilidade.SalvarAsync(request.QuestaoHabilidade);
    }
}