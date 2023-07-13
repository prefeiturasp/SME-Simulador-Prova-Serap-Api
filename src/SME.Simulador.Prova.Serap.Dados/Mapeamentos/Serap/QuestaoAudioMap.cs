using Dapper.FluentMap.Dommel.Mapping;
using SME.Simulador.Prova.Serap.Dominio;


namespace SME.Simulador.Prova.Serap.Dados.Mapeamentos.Serap
{
    public class QuestaoAudioMap : DommelEntityMap<QuestaoAudio>
    {
        public QuestaoAudioMap()
        {
            ToTable("ItemAudio");

            Map(c => c.Id).ToColumn("Id").IsKey();
            Map(c => c.DataCriacao).ToColumn("CreateDate");
            Map(c => c.DataAtualizacao).ToColumn("UpdateDate");
            Map(c => c.Situacao).ToColumn("State");
            Map(c => c.ArquivoId).ToColumn("File_Id");
            Map(c => c.QuestaoId).ToColumn("Item_Id");
        }
    }
}