using Dapper.FluentMap.Dommel.Mapping;
using SME.Simulador.Prova.Serap.Dominio;

namespace SME.Simulador.Prova.Serap.Dados.Mapeamentos.Serap
{
    public class QuestaoGradeCurricularMap : DommelEntityMap<QuestaoGradeCurricular>
    {
        public QuestaoGradeCurricularMap()
        {
            ToTable("ItemCurriculumGrade");

            Map(c => c.Id).ToColumn("Id").IsKey();
            Map(c => c.QuestaoId).ToColumn("Item_Id");
            Map(c => c.DataCriacao).ToColumn("CreateDate");
            Map(c => c.DataAtualizacao).ToColumn("UpdateDate");
            Map(c => c.Situacao).ToColumn("State");
            Map(c => c.TipoGradeCurricular).ToColumn("TypeCurriculumGradeId");
        }
    }
}