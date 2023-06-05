using MediatR;
using SME.Simulador.Prova.Serap.Dados;
using SME.Simulador.Prova.Serap.Dominio;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class ObterUsuarioSerapCoreSsoPorLoginQueryHandler : IRequestHandler<ObterUsuarioSerapCoreSsoPorLoginQuery, UsuarioSerapCoreSso>
{
    private readonly IRepositorioUsuarioSerapCoreSso repositorioUsuarioSerapCoreSso;

    public ObterUsuarioSerapCoreSsoPorLoginQueryHandler(IRepositorioUsuarioSerapCoreSso repositorioUsuarioSerapCoreSso)
    {
        this.repositorioUsuarioSerapCoreSso = repositorioUsuarioSerapCoreSso ?? throw new ArgumentNullException(nameof(repositorioUsuarioSerapCoreSso));
    }

    public async Task<UsuarioSerapCoreSso> Handle(ObterUsuarioSerapCoreSsoPorLoginQuery request, CancellationToken cancellationToken)
    {
        return await repositorioUsuarioSerapCoreSso.ObterPorLoginAsync(request.Login);
    }
}