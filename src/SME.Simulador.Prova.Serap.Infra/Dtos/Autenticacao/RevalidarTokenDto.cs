using System.ComponentModel.DataAnnotations;

namespace SME.Simulador.Prova.Serap.Infra;

public class RevalidarTokenDto : DtoBase
{
    [Required(ErrorMessage = "É necessário informar o token.")]
    public string Token { get; set; }
}