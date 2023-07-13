using MediatR;
using SME.Simulador.Prova.Serap.Dominio;
using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.Aplicacao
{
    public class CadeiaBlocoQuestaoCommand : IRequest<long>
    {
        public CadeiaBlocoQuestaoCommand(CadeiaBlocoQuestao cadeiaBlocoQuestao)
        {
            CadeiaBlocoQuestao = cadeiaBlocoQuestao;
        }
        public CadeiaBlocoQuestao CadeiaBlocoQuestao { get; }
    }
}