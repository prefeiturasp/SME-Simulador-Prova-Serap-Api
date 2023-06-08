namespace SME.Simulador.Prova.Serap.Infra.Dtos
{
    public class AlternativaDto
    {
        public long Id { get; set; }
        public long QuestaoId { get; set; }
        public string Descricao { get; set; }
        public int Ordem { get; set; }
        public string Numeracao { get; set; }
    }
}
