using MediatR;
using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class RevalidarTokenUseCase : AbstractUseCase, IRevalidarTokenUseCase
{
    public RevalidarTokenUseCase(IMediator mediator) : base(mediator)
    {
    }
    
    public async Task<UsuarioAutenticadoDto> ExecutarAsync(RevalidarTokenDto request)
    {
        var usuarioAutenticacao = await mediator.Send(new ObterAutenticacaoUsuarioPorTokenQuery(request.Token));
        var token = await mediator.Send(new ObterTokenJwtQuery(usuarioAutenticacao));

        return new UsuarioAutenticadoDto(token.Item1, token.Item2)
        {
            UltimoLogin = UtilDataHora.ObterDataHoraAtualBrasiliaUtc()
        };
    }
}