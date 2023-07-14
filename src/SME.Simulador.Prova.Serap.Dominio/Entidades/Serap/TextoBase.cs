using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.Simulador.Prova.Serap.Dominio
{
    public class TextoBase : EntidadeBase
    {
        public string? Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public int Situacao { get; set; }
        public string? Fonte { get; set; }
        public string? OrientacaoInicial { get; set; }
        public string? DeclaracaoInicial { get; set; }
        public bool? DeclaracaoInicialNarracao { get; set; }
        public bool? TextoBaseAluno { get; set; }
        public bool? TextoBaseAlunoNarracao { get; set; }
        public bool? OrientacaTextoBase { get; set; }


    }
}
