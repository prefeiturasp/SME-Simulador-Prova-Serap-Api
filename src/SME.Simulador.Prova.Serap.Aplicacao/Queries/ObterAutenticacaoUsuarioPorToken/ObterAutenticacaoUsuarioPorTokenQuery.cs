using MediatR;
using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class ObterAutenticacaoUsuarioPorTokenQuery : IRequest<AutenticacaoUsuarioDto>
{
    public ObterAutenticacaoUsuarioPorTokenQuery(string token)
    {
        Token = token;
    }

    public string Token { get; }
}