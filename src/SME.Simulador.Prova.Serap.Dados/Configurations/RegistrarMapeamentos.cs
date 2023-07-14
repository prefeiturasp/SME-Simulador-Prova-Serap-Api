using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;
using SME.Simulador.Prova.Serap.Dados.Mapeamentos.Serap;

namespace SME.Simulador.Prova.Serap.Dados.Configurations;

public static class RegistrarMapeamentos
{
    public static void Registrar()
    {
        FluentMapper.Initialize(config =>
        {
            config.AddMap(new UsuarioSerapCoreSsoMap());
            config.AddMap(new ExecucaoControleMap());
            config.AddMap(new QuestaoMap());
            config.AddMap(new QuestaoBlocoMap());
            config.AddMap(new TextoBaseMap());
            config.AddMap(new AlternativaMap());
            config.AddMap(new CadeiaBlocoQuestaoMap());

            config.AddMap(new QuestaoArquivoMap());
            config.AddMap(new QuestaoGradeCurricularMap());
            config.AddMap(new QuestaoHabilidadeMap());
            config.AddMap(new QuestaoAudioMap());

            config.ForDommel();
        });
    }    
}