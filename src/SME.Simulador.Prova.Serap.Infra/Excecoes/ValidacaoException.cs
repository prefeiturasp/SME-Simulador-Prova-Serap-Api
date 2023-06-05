namespace SME.Simulador.Prova.Serap.Infra;

public class ValidacaoException : Exception
{
    public ValidacaoException(IEnumerable<string>? erros)
    {
        Mensagens = erros?.ToList();
    }
    
    public List<string>? Mensagens { get; }
}