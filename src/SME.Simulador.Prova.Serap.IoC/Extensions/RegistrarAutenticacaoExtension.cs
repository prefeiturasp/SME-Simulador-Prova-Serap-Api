using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SME.Simulador.Prova.Serap.Dominio;

namespace SME.Simulador.Prova.Serap.IoC;

internal static class RegistrarAutenticacaoExtension
{
    internal static void RegistrarAutenticacao(this IServiceCollection services)
    {
        var serviceProvider = services.BuildServiceProvider();
        var jwtOptions = serviceProvider.GetRequiredService<IOptions<JwtOptions>>().Value;
        
        if (jwtOptions.IssuerSigningKey == null)
            return;        
        
        var issuerSigningKey = Encoding.ASCII.GetBytes(jwtOptions.IssuerSigningKey);
        
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateLifetime = true,
                ValidateAudience = true,
                ValidAudience = jwtOptions.Audience,
                ValidateIssuer = true,
                ValidIssuer = jwtOptions.Issuer,
                ValidateIssuerSigningKey = true,
                ClockSkew = TimeSpan.Zero,
                IssuerSigningKey = new SymmetricSecurityKey(issuerSigningKey)
            };
        });

        services.AddAuthorization(auth =>
        {
            auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                .RequireAuthenticatedUser()
                .Build());
        });        
    }
}