using System.ComponentModel.DataAnnotations;

namespace SME.Simulador.Prova.Serap.Infra;

public class ValidarAutenticacaoUsuarioDto : DtoBase
{
    [Required(ErrorMessage = "O código deve ser informado.")]
    public string Codigo { get; set; } = string.Empty;
}