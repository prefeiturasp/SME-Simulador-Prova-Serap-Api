using MediatR;
using SME.Simulador.Prova.Serap.Aplicacao.Queries.ObterListaQuestaoAudioPorQuestaoId;
using SME.Simulador.Prova.Serap.Dados.Interfaces;
using SME.Simulador.Prova.Serap.Dominio;

namespace SME.Simulador.Prova.Serap.Aplicacao
{
    public class ObterListaQuestaoAudioPorQuestaoIdQueryHandler : IRequestHandler<ObterListaQuestaoAudioPorQuestaoIdQuery, IEnumerable<QuestaoAudio>>
    {
        private readonly IRepositorioQuestaoAudio repositorioQuestaoAudio;
        public ObterListaQuestaoAudioPorQuestaoIdQueryHandler(IRepositorioQuestaoAudio repositorioQuestaoAudio)
        {
            this.repositorioQuestaoAudio = repositorioQuestaoAudio ?? throw new ArgumentNullException(nameof(repositorioQuestaoAudio));
        }
        public async Task<IEnumerable<QuestaoAudio>> Handle(ObterListaQuestaoAudioPorQuestaoIdQuery request, CancellationToken cancellationToken)
        {
            return await repositorioQuestaoAudio.ObterListaQuestaoAudio(request.QuestaoId);
        }

        
    }
}