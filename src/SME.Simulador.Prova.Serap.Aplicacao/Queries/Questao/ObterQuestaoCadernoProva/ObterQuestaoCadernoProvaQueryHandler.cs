using MediatR;
using SME.Simulador.Prova.Serap.Dados;
using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.Aplicacao
{
    public class ObterQuestaoCadernoProvaQueryHandler : IRequestHandler<ObterQuestaoCadernoProvaQuery, QuestaoSerapDto>
    {
        private readonly IRepositorioQuestao repositorioQuestao;

        public ObterQuestaoCadernoProvaQueryHandler(IRepositorioQuestao repositorioQuestao)
        {
            this.repositorioQuestao = repositorioQuestao ?? throw new ArgumentNullException(nameof(repositorioQuestao));
        }

        public async Task<QuestaoSerapDto> Handle(ObterQuestaoCadernoProvaQuery request, CancellationToken cancellationToken)
        {
            return await repositorioQuestao.ObterQuestaoCadernoProva(request.QuestaoId, request.ProvaId, request.Caderno);
        }
    }
}
