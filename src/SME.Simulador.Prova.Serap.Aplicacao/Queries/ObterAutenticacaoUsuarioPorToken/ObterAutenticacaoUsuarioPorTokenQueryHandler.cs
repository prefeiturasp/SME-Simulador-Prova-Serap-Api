using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MediatR;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SME.Simulador.Prova.Serap.Dominio;
using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class ObterAutenticacaoUsuarioPorTokenQueryHandler : IRequestHandler<ObterAutenticacaoUsuarioPorTokenQuery, AutenticacaoUsuarioDto>
{
    private readonly JwtOptions jwtOptions;

    public ObterAutenticacaoUsuarioPorTokenQueryHandler(IOptions<JwtOptions> jwtOptions)
    {
        this.jwtOptions = jwtOptions.Value ?? throw new ArgumentNullException(nameof(jwtOptions));
    }

    public async Task<AutenticacaoUsuarioDto> Handle(ObterAutenticacaoUsuarioPorTokenQuery request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(jwtOptions.IssuerSigningKey))
        {
            throw new ArgumentNullException(nameof(jwtOptions.IssuerSigningKey),
                "A chave de assinatura para emissão do token não foi encontrada.");
        }        
        
        var key = Encoding.ASCII.GetBytes(jwtOptions.IssuerSigningKey);
        var securityKey = new SymmetricSecurityKey(key);
        
        var validationParameters = new TokenValidationParameters
        {
            IssuerSigningKey = securityKey,
            ValidIssuer = jwtOptions.Issuer,
            ValidAudience = jwtOptions.Audience,
            ValidateIssuerSigningKey = true,
            ValidateAudience = true,
            ValidateLifetime = false
        };

        try
        {
            var validator = new JwtSecurityTokenHandler();
            
            if (!validator.CanReadToken(request.Token))
                throw new NaoAutorizadoException("Token inválido");  
            
            var principal = validator.ValidateToken(request.Token, validationParameters, out _);

            if (!principal.HasClaim(c => c.Type == CustomClaimTypes.Login) ||
                !principal.HasClaim(c => c.Type == CustomClaimTypes.Perfil))
            {
                throw new NaoAutorizadoException("Token inválido");
            }
            
            var claimsIdentity = principal.Identity as ClaimsIdentity;
            
            if (claimsIdentity?.Claims == null)
                throw new NaoAutorizadoException("Token inválido");

            var login = claimsIdentity.FindFirst(CustomClaimTypes.Login)?.Value;
            var nome = claimsIdentity.FindFirst(CustomClaimTypes.Nome)?.Value;
            var perfil = claimsIdentity.FindFirst(CustomClaimTypes.Perfil)?.Value;
            
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(perfil))
                throw new NaoAutorizadoException("Token inválido");

            return await Task.FromResult(new AutenticacaoUsuarioDto(login, nome, Guid.Parse(perfil)));
        }
        catch (Exception e)
        {
            throw new NaoAutorizadoException($"Token inválido. Erro: {e.Message}");
        }
    }
}