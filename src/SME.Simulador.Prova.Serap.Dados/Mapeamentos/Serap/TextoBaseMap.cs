using Dapper.FluentMap.Dommel.Mapping;

namespace SME.Simulador.Prova.Serap.Dados.Mapeamentos.Serap
{
    public class TextoBaseMap : DommelEntityMap<Dominio.TextoBase>
    {
        public TextoBaseMap()
        {
            ToTable("BaseText");

            Map(c => c.Id).ToColumn("Id").IsKey();

            Map(c => c.Descricao).ToColumn("Description");
            Map(c => c.DataCriacao).ToColumn("CreateDate");
            Map(c => c.DataAtualizacao).ToColumn("UpdateDate");
            Map(c => c.Situacao).ToColumn("State");
            Map(c => c.Fonte).ToColumn("Source");
            Map(c => c.OrientacaoInicial).ToColumn("InitialOrientation");
            Map(c => c.DeclaracaoInicial).ToColumn("InitialStatement");
            Map(c => c.DeclaracaoInicialNarracao).ToColumn("NarrationInitialStatement");
            Map(c => c.TextoBaseAluno).ToColumn("StudentBaseText");
            Map(c => c.TextoBaseAlunoNarracao).ToColumn("NarrationStudentBaseText");
            Map(c => c.OrientacaTextoBase).ToColumn("BaseTextOrientation");
        }
    }
}
