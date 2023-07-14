
namespace SME.Simulador.Prova.Serap.Dominio
{
    public class QuestaoArquivo : EntidadeBase
    {
        public long? ThumbnailId { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public int Situacao { get; set; }
        public long QuestaoId { get; set; }
        public long? ArquivoId { get; set; }
        public long? ArquivoConvertidoId { get; set; }
    }
}