using System.ComponentModel.DataAnnotations;

namespace SME.Simulador.Prova.Serap.Infra;

public class ParametrosQuestaoCompletaDto : DtoBase
{
    [Required]
    public long QuestaoId { get; set; }
    
    [Required]
    public long CadernoId { get; set; }
}