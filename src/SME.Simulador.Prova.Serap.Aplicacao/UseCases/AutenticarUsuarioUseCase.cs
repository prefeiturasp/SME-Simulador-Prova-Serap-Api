using MediatR;
using Microsoft.Extensions.Options;
using SME.Simulador.Prova.Serap.Dominio;
using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class AutenticarUsuarioUseCase : AbstractUseCase, IAutenticarUsuarioUseCase
{
    private readonly AutenticacaoOptions autenticacaoOptions;
    
    public AutenticarUsuarioUseCase(IMediator mediator, IOptions<AutenticacaoOptions> autenticacaoOptions) : base(mediator)
    {
        this.autenticacaoOptions = autenticacaoOptions.Value ?? throw new ArgumentNullException(nameof(autenticacaoOptions));
    }    
    
    public async Task<AutenticacaoValidarDto> ExecutarAsync(AutenticacaoDto request)
    {
        var usuario = await mediator.Send(new ObterUsuarioSerapCoreSsoPorLoginQuery(request.Login));

        if (usuario == null)
            throw new NaoAutorizadoException("Usuário inválido.");
        
        VerificarChaveApi(request.ChaveApi);
        VerificarPerfilValido(request.Perfil);
        
        Console.WriteLine(usuario.ToString());

        return await mediator.Send(
            new GerarCodigoValidacaoAutenticacaoCommand(new AutenticacaoUsuarioDto(request.Login, usuario.Nome,
                Guid.Parse(request.Perfil))));
    }

    private void VerificarChaveApi(string chaveApi)
    {
        var chaveAutenticacao = Environment.GetEnvironmentVariable("Autenticacao:ChaveSimuladorProvaApi");

        if (string.IsNullOrEmpty(chaveAutenticacao))
            chaveAutenticacao = autenticacaoOptions.ChaveSimuladorProvaApi;
        
        if (chaveAutenticacao == null || chaveApi != chaveAutenticacao)
            throw new NaoAutorizadoException("Chave api inválida");        
    }

    private static void VerificarPerfilValido(string perfil)
    {
        var perfisValidos = new[]
        {
            Perfis.PERFIL_ADMINISTRADOR,
            Perfis.PERFIL_ADMINISTRADOR_SERAP_DRE,
            Perfis.PERFIL_ADMINISTRADOR_NTA,
            Perfis.PERFIL_ADMINISTRADOR_SERAP_UE,
            Perfis.PERFIL_ASSISTENTE_DIRETOR_UE,
            Perfis.PERFIL_COORDENADOR_PEDAGOGICO,
            Perfis.PERFIL_DIRETOR_ESCOLAR,
            Perfis.PERFIL_PROFESSOR,
            Perfis.PERFIL_PROFESSOR_OLD,
            Perfis.PERFIL_ADM_COPED_LEITURA
        };

        var ehGuid = Guid.TryParse(perfil, out var guidPerfil);

        if (!ehGuid || !perfisValidos.Contains(guidPerfil))
            throw new NaoAutorizadoException("Perfil inválido");
    }
}