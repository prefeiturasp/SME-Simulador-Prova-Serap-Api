using Microsoft.AspNetCore.Http;

namespace SME.Simulador.Prova.Serap.Infra;

public class NaoAutorizadoException : AbstractException
{
    public NaoAutorizadoException(string? message) : base(message)
    {
    }
    
    public override int StatusCode => StatusCodes.Status401Unauthorized;
}