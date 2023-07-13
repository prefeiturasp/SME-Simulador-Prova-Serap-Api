﻿
namespace SME.Simulador.Prova.Serap.Dominio
{
    public class CadeiaBlocoQuestao : EntidadeBase
    {
        public long CadeiaBlocoId { get; set; }
        public long QuestaoId { get; set; }
        public int Ordem { get; set; }
        public DateTime DataCricao { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public int Situacao { get; set; }
    }
}
