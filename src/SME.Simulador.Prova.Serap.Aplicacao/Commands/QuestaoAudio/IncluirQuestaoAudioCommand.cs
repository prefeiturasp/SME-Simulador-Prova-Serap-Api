using MediatR;

namespace SME.Simulador.Prova.Serap.Aplicacao
{
    public class IncluirQuestaoAudioCommand : IRequest<long>
    {
        public IncluirQuestaoAudioCommand(Dominio.QuestaoAudio questaoAudio)
        {
            QuestaoAudio = questaoAudio;
        }


        public Dominio.QuestaoAudio QuestaoAudio { get; set; }
    }
}
