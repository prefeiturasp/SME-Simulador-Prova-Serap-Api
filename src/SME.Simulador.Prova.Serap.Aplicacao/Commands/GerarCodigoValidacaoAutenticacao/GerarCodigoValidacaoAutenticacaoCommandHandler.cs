using MediatR;
using SME.Simulador.Prova.Serap.Dados;
using SME.Simulador.Prova.Serap.Dominio;
using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class GerarCodigoValidacaoAutenticacaoCommandHandler : IRequestHandler<GerarCodigoValidacaoAutenticacaoCommand, AutenticacaoValidarDto>
{
    private readonly IRepositorioCache repositorioCache;

    public GerarCodigoValidacaoAutenticacaoCommandHandler(IRepositorioCache repositorioCache)
    {
        this.repositorioCache = repositorioCache ?? throw new ArgumentNullException(nameof(repositorioCache));
    }

    public async Task<AutenticacaoValidarDto> Handle(GerarCodigoValidacaoAutenticacaoCommand request, CancellationToken cancellationToken)
    {
        var codigo = Guid.NewGuid();
        
        var autenticacaoUsuario = new AutenticacaoUsuarioDto(request.AutenticacaoUsuario.Login,
            request.AutenticacaoUsuario.Nome, request.AutenticacaoUsuario.Perfil);

        await repositorioCache.SalvarRedisAsync(string.Format(CacheChave.CodigoAutenticacaoSimulador, codigo),
            autenticacaoUsuario, 5);
        
        return new AutenticacaoValidarDto(codigo.ToString());
    }
}