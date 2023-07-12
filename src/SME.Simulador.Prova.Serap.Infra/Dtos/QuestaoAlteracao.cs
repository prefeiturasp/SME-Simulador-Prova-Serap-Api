using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.Simulador.Prova.Serap.Infra.Dtos
{
    public class QuestaoAlteracao
    {
        public int Id { get; set; }
        public string Enunciado { get; set; } = string.Empty;
        public string TextoBase  { get; set;} = string.Empty;
    }
}
