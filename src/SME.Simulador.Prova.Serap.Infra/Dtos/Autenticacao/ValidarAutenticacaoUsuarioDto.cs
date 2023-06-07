namespace SME.Simulador.Prova.Serap.Infra;

public class ValidarAutenticacaoUsuarioDto : DtoBase
{
    public ValidarAutenticacaoUsuarioDto(string codigo)
    {
        Codigo = codigo;
    }

    public string Codigo { get; }
}