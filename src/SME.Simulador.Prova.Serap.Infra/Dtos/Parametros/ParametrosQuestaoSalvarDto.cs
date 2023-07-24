using System.ComponentModel.DataAnnotations;

namespace SME.Simulador.Prova.Serap.Infra;

public class ParametrosQuestaoSalvarDto : DtoBase
{
    [Required] public int[] ProvasId { get; set; } = Array.Empty<int>();
    [Required] public long[] QuestoesId { get; set; }
    public QuestaoAlteracaoDto? Questao { get; set; }

    public IEnumerable<AlternativaAlteracaoDto>? Alternativas { get; set; }
}