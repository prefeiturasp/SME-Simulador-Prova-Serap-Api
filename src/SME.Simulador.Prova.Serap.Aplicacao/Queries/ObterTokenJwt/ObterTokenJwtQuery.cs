using MediatR;
using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class ObterTokenJwtQuery : IRequest<(string, DateTime)>
{
    public ObterTokenJwtQuery(AutenticacaoUsuarioDto autenticacaoUsuario)
    {
        AutenticacaoUsuario = autenticacaoUsuario;
    }

    public AutenticacaoUsuarioDto AutenticacaoUsuario { get; }
}