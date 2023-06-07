using System.ComponentModel.DataAnnotations;

namespace SME.Simulador.Prova.Serap.Infra;

public class AutenticacaoDto : DtoBase
{
    [Required(ErrorMessage = "É necessário informar login ou código Rf.")]
    public string Login { get; set; } = string.Empty;

    [Required(ErrorMessage = "É necessário informar o perfil.")]
    public string Perfil { get; set; } = string.Empty;

    [Required(ErrorMessage = "É necessário informar a chave api .")]
    public string ChaveApi { get; set; } = string.Empty;
}