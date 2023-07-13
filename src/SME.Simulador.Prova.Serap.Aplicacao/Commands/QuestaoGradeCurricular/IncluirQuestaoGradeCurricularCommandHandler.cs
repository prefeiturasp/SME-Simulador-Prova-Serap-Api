using MediatR;
using SME.Simulador.Prova.Serap.Dados.Interfaces;

namespace SME.Simulador.Prova.Serap.Aplicacao.Commands.QuestaoGradeCurricular
{
    public class IncluirQuestaoGradeCurricularCommandHandler : IRequestHandler<IncluirQuestaoGradeCurricularCommand, long>
    {
        private readonly IRepositorioQuestaoGradeCurricular repositorioQuestaoGradeCurricular;

        public IncluirQuestaoGradeCurricularCommandHandler(IRepositorioQuestaoGradeCurricular repositorioQuestaoGradeCurricular)
        {
            this.repositorioQuestaoGradeCurricular = repositorioQuestaoGradeCurricular;
        }

        public async Task<long> Handle(IncluirQuestaoGradeCurricularCommand request, CancellationToken cancellationToken)
        {
            return await repositorioQuestaoGradeCurricular.SalvarAsync(request.QuestaoGradeCurricular);
        }
    }
}
