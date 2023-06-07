using Microsoft.Extensions.DependencyInjection;
using SME.Simulador.Prova.Serap.Dados.Configurations;
using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.IoC;

public static class ConfigurarDependencias
{
    public static void Configurar(IServiceCollection services)
    {
        RegistrarMapeamentos.Registrar();
        RegistrarRabbit.Registrar(services);
    }        
}