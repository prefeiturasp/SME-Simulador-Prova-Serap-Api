namespace SME.Simulador.Prova.Serap.Infra;

public abstract class AbstractException : Exception
{
    protected AbstractException(string? message) : base(message)
    {
    }

    public abstract int StatusCode { get; }
}