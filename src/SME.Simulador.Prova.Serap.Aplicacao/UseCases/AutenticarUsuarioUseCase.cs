using MediatR;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class AutenticarUsuarioUseCase : AbstractUseCase, IAutenticarUsuarioUseCase
{
    public AutenticarUsuarioUseCase(IMediator mediator) : base(mediator)
    {
    }    
    
    public async Task<string> ExecutarAsync(string request)
    {
        var usuario = await mediator.Send(new ObterUsuarioSerapCoreSsoPorLoginQuery(request));
        Console.WriteLine(usuario.ToString());
        return "teste";
    }
}