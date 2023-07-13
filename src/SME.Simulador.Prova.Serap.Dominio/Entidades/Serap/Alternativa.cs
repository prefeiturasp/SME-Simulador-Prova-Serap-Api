

namespace SME.Simulador.Prova.Serap.Dominio
{
    public class Alternativa : EntidadeBase
    {
        public string Descricao { get; set; }//   ,[Description]
        public bool? Correta { get; set; }  //,[Correct]
        public int? Ordem { get; set; } //,[Order]
        public string? Justificativa { get; set; } //,[Justificative]
        public string? Numeracao { get; set; }    //,[Numeration]
        public decimal? TCTCoeficienteBisserial { get; set; } //,[TCTBiserialCoefficient]
        public decimal? TCTDificuldade { get; set; }  //,[TCTDificulty]
        public decimal? DiscriminaçãoTCT { get; set; } //,[TCTDiscrimination]
        public DateTime DataCriacao { get; set; }  //,[CreateDate]
        public DateTime DataAtualizacao { get; }   //,[UpdateDate]
        public int Situacao { get; set; }  //,[State]
        public long QuestaoId { get; set; } //,[Item_Id]
    }
}