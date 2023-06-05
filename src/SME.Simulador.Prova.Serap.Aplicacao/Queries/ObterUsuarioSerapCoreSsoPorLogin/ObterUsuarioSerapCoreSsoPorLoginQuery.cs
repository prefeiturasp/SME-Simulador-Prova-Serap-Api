using MediatR;
using SME.Simulador.Prova.Serap.Dominio;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class ObterUsuarioSerapCoreSsoPorLoginQuery : IRequest<UsuarioSerapCoreSso>
{
    public ObterUsuarioSerapCoreSsoPorLoginQuery(string login)
    {
        Login = login;
    }

    public string Login { get; }
}