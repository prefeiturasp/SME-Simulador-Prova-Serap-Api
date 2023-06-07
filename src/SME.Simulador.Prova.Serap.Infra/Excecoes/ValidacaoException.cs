using Microsoft.AspNetCore.Http;

namespace SME.Simulador.Prova.Serap.Infra;

public class ValidacaoException : AbstractException
{
    private ValidacaoException(string? message) : base(message)
    {
    }    
    
    public ValidacaoException(IEnumerable<string>? erros) : this("Um ou mais erros de validações foram retornados.")
    {
        Mensagens = erros?.ToList();
    }

    public override int StatusCode => StatusCodes.Status422UnprocessableEntity;
    public List<string>? Mensagens { get; }
}