using System.ComponentModel.DataAnnotations;

namespace SME.Simulador.Prova.Serap.Infra.Dtos.Parametros;

public class ParametrosQuestaoSalvarDto : DtoBase
{
    [Required] public int[] ProvasId { get; set; } = Array.Empty<int>();

    public QuestaoAlteracao Questao { get; set; } = new();

    public IEnumerable<AlternativaAlteracaoDto> Alternativas { get; set; } = new List<AlternativaAlteracaoDto>();
}