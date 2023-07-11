using Dapper.FluentMap.Dommel.Mapping;
using SME.Simulador.Prova.Serap.Dominio;

namespace SME.Simulador.Prova.Serap.Dados;

public class ExecucaoControleMap : DommelEntityMap<ExecucaoControle>
{
    public ExecucaoControleMap()
    {
        ToTable("execucao_controle");
        Map(c => c.Id).ToColumn("id").IsKey();
        Map(c => c.ExecucaoTipo).ToColumn("execucao_tipo");
        Map(c => c.UltimaExecucao).ToColumn("ultima_execucao");
    }
}