using MediatR;

namespace SME.Simulador.Prova.Serap.Aplicacao
{
    public class IncluirQuestaoGradeCurricularCommand : IRequest<long>
    {
        public IncluirQuestaoGradeCurricularCommand(Dominio.QuestaoGradeCurricular questaoGradeCurricular)
        {
            QuestaoGradeCurricular = questaoGradeCurricular;
        }
        public Dominio.QuestaoGradeCurricular QuestaoGradeCurricular { get; set; }
    }
}

