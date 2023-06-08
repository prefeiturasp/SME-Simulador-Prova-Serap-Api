using MediatR;
using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class ObterQuestoesResumoPorCadernoIdUseCase : AbstractUseCase, IObterQuestoesResumoPorCadernoIdUseCase
{
    public ObterQuestoesResumoPorCadernoIdUseCase(IMediator mediator) : base(mediator)
    {
    }    
    
    public async Task<IEnumerable<QuestaoResumoDto>> ExecutarAsync(long request)
    {
        return await mediator.Send(new ObterQuestoesResumoPorCadernoIdQuery(request));
    }
}