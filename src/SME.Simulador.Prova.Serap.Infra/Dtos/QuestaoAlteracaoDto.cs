using Elastic.Apm.Api.Constraints;

namespace SME.Simulador.Prova.Serap.Infra;

public class QuestaoAlteracaoDto
{

    [Required] public int Id { get; set; }
    public string Enunciado { get; set; } = string.Empty;
    public string TextoBase { get; set; } = string.Empty;
}