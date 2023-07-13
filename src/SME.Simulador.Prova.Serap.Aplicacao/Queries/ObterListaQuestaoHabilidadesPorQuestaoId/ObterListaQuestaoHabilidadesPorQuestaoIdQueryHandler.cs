using MediatR;
using SME.Simulador.Prova.Serap.Dados.Interfaces;
using SME.Simulador.Prova.Serap.Dominio;

namespace SME.Simulador.Prova.Serap.Aplicacao
{
    public class ObterListaQuestaoHabilidadesPorQuestaoIdQueryHandler : IRequestHandler<ObterListaQuestaoHabilidadesPorQuestaoIdQuery, IEnumerable<QuestaoHabilidade>>
    {
        private readonly IRepositorioQuestaoHabilidade repositorioQuestaoHabilidade;
        public ObterListaQuestaoHabilidadesPorQuestaoIdQueryHandler(IRepositorioQuestaoHabilidade repositorioQuestaoHabilidade)
        {
            this.repositorioQuestaoHabilidade = repositorioQuestaoHabilidade ?? throw new ArgumentNullException(nameof(repositorioQuestaoHabilidade));
        }
        public async Task<IEnumerable<QuestaoHabilidade>> Handle(ObterListaQuestaoHabilidadesPorQuestaoIdQuery request, CancellationToken cancellationToken)
        {
            return await repositorioQuestaoHabilidade.ObterListaQuestoesHabilidades(request.QuestaoId);
        }
    }
}