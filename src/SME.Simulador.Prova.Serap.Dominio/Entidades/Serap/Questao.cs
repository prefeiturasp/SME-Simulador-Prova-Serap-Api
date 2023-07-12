using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.Simulador.Prova.Serap.Dominio
{ 
    public class Questao : EntidadeBase
    {
        public string CodigoItem { get; set; }
        public int VersaoItem { get; set; } // ,[ItemVersion]
        public string? Enunciado { get; set; } //,[Statement]
        public string? PalavrasChaves { get; set; } //,[Keywords]
        public string? Tips { get; set; }
        public decimal? TRIDiscrimination { get; set; } //TRIDiscrimination
        public decimal? TRIDifficulty { get; set; } //TRIDifficulty
        public decimal? TRICasualSetting { get; set; } //TRICasualSetting
        public DateTime DataCriacao { get; set; } //[CreateDate
        public DateTime DataAtualizacao { get; set; } //[UpdateDate]
        public int Estado { get; set; } // state
        public int TextoBaseId { get; set; } //BaseText_Id
        public int MatrizId { get; set; } // [EvaluationMatrix_Id]
        public int LevelItemId { get; set; } // ,[ItemLevel_Id]
        public int SituacaoItemId { get; set; } // [ItemSituation_Id]
        public int TipoItem { get; set; } // [ItemType_Id]
        public int Proeficiencia { get; set; }//proficiency]
        public string? DescriptorSentence { get; set; } //,[descriptorSentence]
        public bool UltimaVersao { get; set; } //,[LastVersion]
        public bool EhRestrito { get; set; } // [IsRestrict]
        public bool ItemNarrado { get; set; } //,[ItemNarrated]
        public bool DeclaracaoAluno { get; set; } //[StudentStatement]
        public bool NarracaoDeclaracaoAluno { get; set; } // [NarrationStudentStatement]
        public bool NarracaoAlternativas { get; set; }  // [NarrationAlternatives]
        public bool Revogado { get; set; } //Revoked
        public int VersaoCodigoItem { get; set; } //,[ItemCodeVersion]
        public int AreaConhecimentoId { get; set; } //,[KnowledgeArea_Id]
        public int SubAssunto { get; set; } // [SubSubject_Id]
    }
}
