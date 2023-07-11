using Microsoft.AspNetCore.Http;

namespace SME.Simulador.Prova.Serap.Infra;

public class ErroException : AbstractException
{
    public ErroException(string? message) : base(message)
    {
    }

    public override int StatusCode => StatusCodes.Status500InternalServerError;
}