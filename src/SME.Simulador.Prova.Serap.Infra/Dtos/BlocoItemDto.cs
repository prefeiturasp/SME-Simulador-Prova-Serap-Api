using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.Simulador.Prova.Serap.Infra.Dtos
{
    public class BlocoItemDto
    {
        public long Id { get; set; }
        public long BlocoId { get; set; }
        public long ItemId { get; set; }
        public int Ordem { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
