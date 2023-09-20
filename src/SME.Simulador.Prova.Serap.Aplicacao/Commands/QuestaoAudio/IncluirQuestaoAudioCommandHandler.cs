using MediatR;
using SME.Simulador.Prova.Serap.Dados;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class IncluirQuestaoAudioCommandHandler : IRequestHandler<IncluirQuestaoAudioCommand, long>
{
    private readonly IRepositorioQuestaoAudio repositorioQuestaoAudio;

    public IncluirQuestaoAudioCommandHandler(IRepositorioQuestaoAudio repositorioQuestaoAudio)
    {
        this.repositorioQuestaoAudio = repositorioQuestaoAudio;
    }

    public async Task<long> Handle(IncluirQuestaoAudioCommand request, CancellationToken cancellationToken)
    {
        return await repositorioQuestaoAudio.SalvarAsync(request.QuestaoAudio);
    }
}