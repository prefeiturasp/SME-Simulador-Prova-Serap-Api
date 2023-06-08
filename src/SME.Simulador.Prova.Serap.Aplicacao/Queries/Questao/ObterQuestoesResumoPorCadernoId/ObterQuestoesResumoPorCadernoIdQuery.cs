using MediatR;
using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class ObterQuestoesResumoPorCadernoIdQuery : IRequest<IEnumerable<QuestaoResumoDto>>
{
    public ObterQuestoesResumoPorCadernoIdQuery(long cadernoId)
    {
        CadernoId = cadernoId;
    }

    public long CadernoId { get; }
}