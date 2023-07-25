using System.ComponentModel.DataAnnotations;

namespace SME.Simulador.Prova.Serap.Infra;

public class ParametrosQuestaoSalvarDto : DtoBase
{
    [Required] public List<ProvasQuestoesDto>? ProvasQuestoes { get; set; }
    public QuestaoAlteracaoDto? Questao { get; set; }

    public IEnumerable<AlternativaAlteracaoDto>? Alternativas { get; set; }
}