namespace SME.Simulador.Prova.Serap.Infra;

public class RetornoBaseDto
{
    public RetornoBaseDto()
    {
        Mensagens = new List<string>();
    }

    public List<string> Mensagens { get; set; }
    public bool ExistemErros => Mensagens.Any();
}