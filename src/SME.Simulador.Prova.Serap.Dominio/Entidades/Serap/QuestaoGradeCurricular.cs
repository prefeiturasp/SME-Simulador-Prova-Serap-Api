
namespace SME.Simulador.Prova.Serap.Dominio
{
    public class QuestaoGradeCurricular : EntidadeBase
    {
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public int Situacao { get; set; }
        public long QuestaoId { get; set; }
        public int TipoGradeCurricular { get; set; }
    }
}