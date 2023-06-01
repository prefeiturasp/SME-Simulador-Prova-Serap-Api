﻿namespace SME.Simulador.Prova.Serap.Dominio;

public class JwtOptions
{
    public const string Secao = nameof(JwtOptions);
    public string? Issuer { get; set; }
    public string? Audience { get; set; }
    public string? ExpiresInMinutes { get; set; }
    public string? IssuerSigningKey { get; set; }    
}