namespace SME.Simulador.Prova.Serap.Infra;

public class QuestaoCompletaDto : QuestaoSerapDto
{
    public IEnumerable<AlternativaDto> Alternativas { get; set; } = Enumerable.Empty<AlternativaDto>();
    public IEnumerable<ArquivoDto> Audios { get; set; } = Enumerable.Empty<ArquivoDto>();
    public IEnumerable<VideoDto> Videos { get; set; } = Enumerable.Empty<VideoDto>();
    public bool EhProvaIniciada { get; set; }
}