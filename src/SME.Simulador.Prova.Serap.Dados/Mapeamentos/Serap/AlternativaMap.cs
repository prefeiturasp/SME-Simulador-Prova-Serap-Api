using Dapper.FluentMap.Dommel.Mapping;

namespace SME.Simulador.Prova.Serap.Dados.Mapeamentos.Serap;

public class AlternativaMap : DommelEntityMap<Dominio.Alternativa>
{
    public AlternativaMap()
    {
        ToTable("Alternative");
        Map(c => c.Id).ToColumn("Id").IsKey();
        Map(c => c.Descricao).ToColumn("Description");
        Map(c => c.Correta).ToColumn("Correct");
        Map(c => c.Ordem).ToColumn("Order");
        Map(c => c.Justificativa).ToColumn("Justificative");
        Map(c => c.Numeracao).ToColumn("Numeration");
        Map(c => c.TCTCoeficienteBisserial).ToColumn("TCTBiserialCoefficient");
        Map(c => c.TCTDificuldade).ToColumn("TCTDificulty");
        Map(c => c.DiscriminaçãoTCT).ToColumn("TCTDiscrimination");
        Map(c => c.DataCriacao).ToColumn("CreateDate");
        Map(c => c.DataAtualizacao).ToColumn("UpdateDate");
        Map(c => c.Situacao).ToColumn("State");
        Map(c => c.QuestaoId).ToColumn("Item_Id");
    }
}