namespace SME.Simulador.Prova.Serap.Infra.Dtos
{
    public class QuestaoCompletaDto : QuestaoSerapDto
    {
        public IEnumerable<AlternativaDto> Alternativas { get; set; }
        public IEnumerable<ArquivoDto> Audios { get; set; }
        public IEnumerable<VideoDto> Videos { get; set; }
    }
}
