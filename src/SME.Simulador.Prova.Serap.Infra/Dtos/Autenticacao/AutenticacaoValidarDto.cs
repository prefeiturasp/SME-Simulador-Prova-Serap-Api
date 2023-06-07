namespace SME.Simulador.Prova.Serap.Infra;

public class AutenticacaoValidarDto : DtoBase
{
    public AutenticacaoValidarDto(string codigo)
    {
        Codigo = codigo;
    }

    public string Codigo { get; }
}