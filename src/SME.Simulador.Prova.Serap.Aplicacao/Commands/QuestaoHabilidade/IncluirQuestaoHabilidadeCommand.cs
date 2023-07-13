using MediatR;

namespace SME.Simulador.Prova.Serap.Aplicacao
{
    public class IncluirQuestaoHabilidadeCommand : IRequest<long>
    {
        public IncluirQuestaoHabilidadeCommand(Dominio.QuestaoHabilidade questaoHabilidade)
        {
            QuestaoHabilidade = questaoHabilidade;
        }
        public Dominio.QuestaoHabilidade QuestaoHabilidade { get; set; }
    }
}

