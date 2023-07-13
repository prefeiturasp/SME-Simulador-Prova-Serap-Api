using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.Simulador.Prova.Serap.Dominio
{
    public class QuestaoAudio : EntidadeBase
    {
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public int Situacao { get; set; }
        public long QuestaoId { get; set; }
        public long ArquivoId { get; set; }
    }
}