using Dapper.FluentMap.Dommel.Mapping;

namespace SME.Simulador.Prova.Serap.Dados.Mapeamentos.Serap;

public class QuestaoBlocoMap : DommelEntityMap<Dominio.QuestaoBloco>
{
    public QuestaoBlocoMap()
    {
        ToTable("BlockItem");
        Map(c => c.Id).ToColumn("Id").IsKey();
        Map(c => c.BlocoId).ToColumn("Block_Id");
        Map(c => c.QuestaoId).ToColumn("Item_Id");
        Map(c => c.Ordem).ToColumn("Order");
        Map(c => c.DataCricao).ToColumn("CreateDate");
        Map(c => c.DataAtualizacao).ToColumn("UpdateDate");
        Map(c => c.Situacao).ToColumn("State");
    }
}