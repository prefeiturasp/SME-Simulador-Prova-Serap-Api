using Dapper.FluentMap.Dommel.Mapping;

namespace SME.Simulador.Prova.Serap.Dados.Mapeamentos.Serap;

public class QuestaoMap : DommelEntityMap<Dominio.Questao>
{
    public QuestaoMap()
    {
        ToTable("Item");
        Map(c => c.Id).ToColumn("Id").IsKey();
        Map(c => c.CodigoItem).ToColumn("ItemCode");
        Map(c => c.VersaoItem).ToColumn("ItemVersion");
        Map(c => c.Enunciado).ToColumn("Statement");
        Map(c => c.PalavrasChaves).ToColumn("Keywords");
        Map(c => c.Tips).ToColumn("Tips");
        Map(c => c.TRIDiscrimination).ToColumn("TRIDiscrimination");
        Map(c => c.TRIDifficulty).ToColumn("TRIDifficulty");
        Map(c => c.TRICasualSetting).ToColumn("TRICasualSetting");
        Map(c => c.DataCriacao).ToColumn("CreateDate");
        Map(c => c.DataAtualizacao).ToColumn("UpdateDate");
        Map(c => c.Situacao).ToColumn("State");
        Map(c => c.TextoBaseId).ToColumn("BaseText_Id");
        Map(c => c.MatrizId).ToColumn("EvaluationMatrix_Id");
        Map(c => c.LevelItemId).ToColumn("ItemLevel_Id");
        Map(c => c.SituacaoItemId).ToColumn("ItemSituation_Id");
        Map(c => c.TipoItem).ToColumn("ItemType_Id");
        Map(c => c.Proeficiencia).ToColumn("proficiency");
        Map(c => c.DescriptorSentence).ToColumn("descriptorSentence");
        Map(c => c.UltimaVersao).ToColumn("LastVersion");
        Map(c => c.EhRestrito).ToColumn("IsRestrict");
        Map(c => c.ItemNarrado).ToColumn("ItemNarrated");
        Map(c => c.DeclaracaoAluno).ToColumn("StudentStatement");
        Map(c => c.NarracaoDeclaracaoAluno).ToColumn("NarrationStudentStatement");
        Map(c => c.NarracaoAlternativas).ToColumn("NarrationAlternatives");
        Map(c => c.Revogado).ToColumn("Revoked");
        Map(c => c.VersaoCodigoQuestao).ToColumn("ItemCodeVersion");
        Map(c => c.AreaConhecimentoId).ToColumn("KnowledgeArea_Id");
        Map(c => c.SubAssunto).ToColumn("SubSubject_Id");
    }
}