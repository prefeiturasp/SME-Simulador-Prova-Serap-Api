using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.Simulador.Prova.Serap.Infra.Dtos.Parametros
{
    public class ParametrosQuestaoSalvar : DtoBase
    {
        private int[] provasId;

        [Required]
        public int[] ProvasId { get => provasId; set => provasId = value; }

        public QuestaoAlteracao Questao { get; set; }

        public IEnumerable<AlternativaAlteracaoDto> Alternativas { get; set; }

    }
}
