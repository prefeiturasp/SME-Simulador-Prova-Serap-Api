namespace SME.Simulador.Prova.Serap.Dominio;

public class UsuarioSerapCoreSso : EntidadeBase
{
    public Guid IdCoreSso { get; set; }
    public string? Login { get; set; }
    public string? Nome { get; set; }
    public DateTime CriadoEm { get; set; }
    public DateTime AtualizadoEm { get; set; }
}