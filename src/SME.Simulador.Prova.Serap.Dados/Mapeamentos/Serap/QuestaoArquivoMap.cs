using Dapper.FluentMap.Dommel.Mapping;
using SME.Simulador.Prova.Serap.Dominio;

namespace SME.Simulador.Prova.Serap.Dados.Mapeamentos.Serap
{
    internal class QuestaoArquivoMap : DommelEntityMap<QuestaoArquivo>
    {
        public QuestaoArquivoMap()
        {
            ToTable("ItemFile");

            Map(c => c.Id).ToColumn("Id").IsKey();
            Map(c => c.QuestaoId).ToColumn("Item_Id");
            Map(c => c.DataCriacao).ToColumn("CreateDate");
            Map(c => c.DataAtualizacao).ToColumn("UpdateDate");
            Map(c => c.Situacao).ToColumn("State");
            Map(c => c.ArquivoId).ToColumn("File_Id");
            Map(c => c.ArquivoConvertidoId).ToColumn("ConvertedFile_Id");
            Map(c => c.ThumbnailId).ToColumn("Thumbnail_Id");
        }
    }
}