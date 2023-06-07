namespace SME.Simulador.Prova.Serap.Infra
{
    public class QuestaoSerapDto
    {
        public long Id { get; set; }
        public int Ordem { get; set; }
        public string TextoBase { get; set; }
        public string Enunciado { get; set; }
        public string Caderno { get; set; }
        public int TipoItem { get; set; }
        public int QuantidadeAlternativas { get; set; }
        public long? QuestaoAnteriorId { get; set; }
        public long? ProximaQuestaoId { get; set; }
    }
}
