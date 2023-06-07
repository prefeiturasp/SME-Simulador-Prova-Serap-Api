namespace SME.Simulador.Prova.Serap.Infra;

public class AutenticacaoUsuarioDto : DtoBase
{
    public AutenticacaoUsuarioDto(string login, string? nome, Guid perfil)
    {
        Login = login;
        Nome = nome;
        Perfil = perfil;
    }

    public string Login { get; set; }
    public string? Nome { get; set; }
    public Guid Perfil { get; set; }    
}