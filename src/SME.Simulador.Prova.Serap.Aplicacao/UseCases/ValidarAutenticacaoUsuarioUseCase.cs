using MediatR;
using SME.Simulador.Prova.Serap.Dominio;
using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class ValidarAutenticacaoUsuarioUseCase : AbstractUseCase, IValidarAutenticacaoUsuarioUseCase
{
    public ValidarAutenticacaoUsuarioUseCase(IMediator mediator) : base(mediator)
    {
    }
    
    public async Task<UsuarioAutenticadoDto> ExecutarAsync(ValidarAutenticacaoUsuarioDto request)
    {
        var usuario = await mediator.Send(new ObterAutenticacaoUsuarioPorCodigoValidacaoQuery(request.Codigo));

        if (usuario == null)
            throw new NaoAutorizadoException("Usuário não autorizado.");

        var token = await mediator.Send(new ObterTokenJwtQuery(usuario));

        return new UsuarioAutenticadoDto(token.Item1, token.Item2)
        {
            UltimoLogin = UtilDataHora.ObterDataHoraAtualBrasiliaUtc(),
            PermiteEditarItem = Perfis.PermiteEditarItem(usuario.Perfil)
        };
    }
}