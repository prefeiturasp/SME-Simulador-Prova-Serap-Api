﻿using Dapper.FluentMap.Dommel.Mapping;

namespace SME.Simulador.Prova.Serap.Dados.Mapeamentos.Serap;

public class CadeiaBlocoQuestaoMap : DommelEntityMap<Dominio.CadeiaBlocoQuestao>
{
    public CadeiaBlocoQuestaoMap()
    {
        ToTable("BlockChainItem");
        Map(c => c.Id).ToColumn("Id").IsKey();
        Map(c => c.CadeiaBlocoId).ToColumn("BlockChain_Id");
        Map(c => c.QuestaoId).ToColumn("Item_Id");
        Map(c => c.Ordem).ToColumn("Order");
        Map(c => c.DataCricao).ToColumn("CreateDate");
        Map(c => c.DataAtualizacao).ToColumn("UpdateDate");
        Map(c => c.Situacao).ToColumn("State");
    }
}