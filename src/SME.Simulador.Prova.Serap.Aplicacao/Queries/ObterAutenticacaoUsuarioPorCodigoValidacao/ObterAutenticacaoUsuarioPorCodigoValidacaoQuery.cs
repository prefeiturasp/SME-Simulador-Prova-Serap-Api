using MediatR;
using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class ObterAutenticacaoUsuarioPorCodigoValidacaoQuery : IRequest<AutenticacaoUsuarioDto>
{
    public ObterAutenticacaoUsuarioPorCodigoValidacaoQuery(string codigo)
    {
        Codigo = codigo;
    }

    public string Codigo { get; }
}