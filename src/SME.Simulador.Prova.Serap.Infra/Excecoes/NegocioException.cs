using Microsoft.AspNetCore.Http;

namespace SME.Simulador.Prova.Serap.Infra;

public class NegocioException : AbstractException
{
    public NegocioException(string? message) : base(message)
    {
    }    
    
    public override int StatusCode => StatusCodes.Status409Conflict;
}