using System.ComponentModel.DataAnnotations;

namespace SME.Simulador.Prova.Serap.Infra;

public class ParametrosQuestaoSalvarDto : DtoBase
{
    [Required] public int[] ProvasId { get; set; } = Array.Empty<int>();

    public QuestaoAlteracaoDto? Questao { get; set; }

    public IEnumerable<AlternativaAlteracaoDto>? Alternativas { get; set; }
}