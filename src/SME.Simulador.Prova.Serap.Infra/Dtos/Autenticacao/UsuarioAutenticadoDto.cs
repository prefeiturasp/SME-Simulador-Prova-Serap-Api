namespace SME.Simulador.Prova.Serap.Infra;

public class UsuarioAutenticadoDto : DtoBase
{
    public UsuarioAutenticadoDto(string token, DateTime dataHoraExpiracao)
    {
        Token = token;
        DataHoraExpiracao = dataHoraExpiracao;
    }

    public string Token { get; set; }
    public DateTime DataHoraExpiracao { get; set; }
    public DateTime? UltimoLogin { get; set; }    
}