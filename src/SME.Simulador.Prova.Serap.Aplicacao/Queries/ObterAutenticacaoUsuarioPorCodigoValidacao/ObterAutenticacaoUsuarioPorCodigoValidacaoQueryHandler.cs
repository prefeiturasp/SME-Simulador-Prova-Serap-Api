using MediatR;
using SME.Simulador.Prova.Serap.Dados;
using SME.Simulador.Prova.Serap.Dominio;
using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class ObterAutenticacaoUsuarioPorCodigoValidacaoQueryHandler : IRequestHandler<ObterAutenticacaoUsuarioPorCodigoValidacaoQuery, AutenticacaoUsuarioDto>
{
    private readonly IRepositorioCache repositorioCache;

    public ObterAutenticacaoUsuarioPorCodigoValidacaoQueryHandler(IRepositorioCache repositorioCache)
    {
        this.repositorioCache = repositorioCache ?? throw new ArgumentNullException(nameof(repositorioCache));
    }

    public async Task<AutenticacaoUsuarioDto> Handle(ObterAutenticacaoUsuarioPorCodigoValidacaoQuery request, CancellationToken cancellationToken)
    {
        var chave = string.Format(ChavesCache.CodigoAutenticacaoSimulador, request.Codigo);

        var retorno = await repositorioCache.ObterRedisAsync<AutenticacaoUsuarioDto>(chave);

        if (retorno == null)
            throw new NaoAutorizadoException("Não foram encontrados os dados do usuário de autenticação.");
        
        await repositorioCache.RemoverRedisAsync(chave);
        return retorno;
    }
}