using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace SME.Simulador.Prova.Serap.Api;

internal static class RegistrarDocumentacaoSwagger
{
    internal static void ConfigurarDocumentacao(this SwaggerGenOptions config)
    {
        config.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "Simulador do SERAp Estudantes",
            Version = "1.0.0",
            Description = "Simulador das provas do SERAp Estudantes"
        });

        var securitySchema = new OpenApiSecurityScheme
        {
            Description = "Para autenticação, incluir 'Bearer' seguido do token JWT. Exemplo: \"Authorization: Bearer {token}\"",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.Http,
            Scheme = "bearer",
            BearerFormat = "JWT",
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            }
        };
    
        config.AddSecurityDefinition("Bearer", securitySchema);
        
        var securityRequirement = new OpenApiSecurityRequirement
        {
            { securitySchema, new[] { "Bearer" } }
        };
        
        config.AddSecurityRequirement(securityRequirement);
    }
}