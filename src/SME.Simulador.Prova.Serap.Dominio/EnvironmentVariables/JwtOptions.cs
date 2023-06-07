namespace SME.Simulador.Prova.Serap.Dominio;

public class JwtOptions
{
    public string? Issuer { get; set; }
    public string? Audience { get; set; }
    public string ExpiresInMinutes { get; set; } = "4000";
    public string? IssuerSigningKey { get; set; }    
}