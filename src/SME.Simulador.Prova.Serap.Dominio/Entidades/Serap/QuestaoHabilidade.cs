namespace SME.Simulador.Prova.Serap.Dominio
{ 
    public class QuestaoHabilidade : EntidadeBase
    {
        public bool? HabilidadeOriginal { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public int Situacao { get; set; }
        public long QuestaoId { get; set; }
        public long HabilidadeId { get; set; }
    }
}
