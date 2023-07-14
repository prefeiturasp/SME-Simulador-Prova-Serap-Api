using MediatR;

namespace SME.Simulador.Prova.Serap.Aplicacao
{
    public class DesabilitarUltimaVersaoQuestaoPorCodigoCommand : IRequest<int>
    {
        public DesabilitarUltimaVersaoQuestaoPorCodigoCommand(string codigoQuestao)
        {
            CodigoQuestao = codigoQuestao;
        }
        public string CodigoQuestao { get; set; }
    }
}