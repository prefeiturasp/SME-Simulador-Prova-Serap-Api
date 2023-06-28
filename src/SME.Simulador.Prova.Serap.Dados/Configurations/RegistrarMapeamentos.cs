using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;

namespace SME.Simulador.Prova.Serap.Dados.Configurations;

public static class RegistrarMapeamentos
{
    public static void Registrar()
    {
        FluentMapper.Initialize(config =>
        {
            config.AddMap(new UsuarioSerapCoreSsoMap());
            config.AddMap(new ExecucaoControleMap());
            config.ForDommel();
        });
    }    
}