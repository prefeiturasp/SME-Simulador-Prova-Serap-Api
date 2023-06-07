using MediatR;
using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class GerarCodigoValidacaoAutenticacaoCommand : IRequest<AutenticacaoValidarDto>
{
    public GerarCodigoValidacaoAutenticacaoCommand(AutenticacaoUsuarioDto autenticacaoUsuario)
    {
        AutenticacaoUsuario = autenticacaoUsuario;
    }
    
    public AutenticacaoUsuarioDto AutenticacaoUsuario { get; }
}