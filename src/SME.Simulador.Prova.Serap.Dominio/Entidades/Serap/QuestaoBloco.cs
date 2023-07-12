using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.Simulador.Prova.Serap.Dominio
{
    public class QuestaoBloco :EntidadeBase
    {
        public long BlocoId { get; set; }
        public long ItemId { get; set; }
        public int Ordem { get; set; }
        public DateTime DataCricao { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public int Situacao { get; set; }
    }
}
