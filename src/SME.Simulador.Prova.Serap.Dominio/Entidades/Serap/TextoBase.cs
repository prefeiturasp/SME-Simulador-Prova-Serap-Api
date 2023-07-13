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
        public DateTime DataCriacao { get; set; }   //,[CreateDate]
        public DateTime DataAtualizacao { get; set; }  //        ,[UpdateDate]
        public int Situacao { get; set; } //           ,[State]
        public string? Fonte { get; set; }        // [Source]
         public string? OrientacaoInicial { get; set; } //
        public string? DeclaracaoInicial{ get; set; } //   ,[InitialStatement]                                            //  ,[InitialOrientation]
        public bool? DeclaracaoInicialNarracao { get; set; }  //[NarrationInitialStatement]     
        public bool? TextoBaseAluno { get; set; }//,[StudentBaseText]
        public bool? TextoBaseAlunoNarracao { get; set; } //NarrationStudentBaseText
        public bool? OrientacaTextoBase    { get; set; } //,[BaseTextOrientation] 


    }
}
