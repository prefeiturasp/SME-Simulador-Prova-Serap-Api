using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MediatR;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SME.Simulador.Prova.Serap.Dominio;
using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class ObterTokenJwtQueryHandler : IRequestHandler<ObterTokenJwtQuery, (string, DateTime)>
{
    private readonly JwtOptions jwtOptions;

    public ObterTokenJwtQueryHandler(IOptions<JwtOptions> jwtOptions)
    {
        this.jwtOptions = jwtOptions.Value ?? throw new ArgumentNullException(nameof(jwtOptions));
    }

    public async Task<(string, DateTime)> Handle(ObterTokenJwtQuery request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(jwtOptions.IssuerSigningKey))
        {
            throw new ArgumentNullException(nameof(jwtOptions.IssuerSigningKey),
                "A chave de assinatura para emissão do token não foi encontrada.");
        }
        
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(jwtOptions.IssuerSigningKey);
        var dataAtual = UtilDataHora.ObterDataHoraAtualBrasiliaUtc();
        var dataHoraExpiracao = dataAtual.AddMinutes(double.Parse(jwtOptions.ExpiresInMinutes));
        var permiteEditarItem = Perfis.PermiteEditarItem(request.AutenticacaoUsuario.Perfil);
        
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new(CustomClaimTypes.Login, request.AutenticacaoUsuario.Login),
                new(CustomClaimTypes.Perfil, request.AutenticacaoUsuario.Perfil.ToString()),
                new(CustomClaimTypes.PermiteEditarItem, permiteEditarItem.ToString())
            }),
            Issuer = jwtOptions.Issuer,
            Audience = jwtOptions.Audience,
            NotBefore = dataAtual,
            Expires = dataHoraExpiracao,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        
        if (request.AutenticacaoUsuario.Nome != null)
            tokenDescriptor.Subject.AddClaim(new Claim(CustomClaimTypes.Nome, request.AutenticacaoUsuario.Nome));

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return await Task.FromResult((tokenHandler.WriteToken(token), dataHoraExpiracao));        
    }
}