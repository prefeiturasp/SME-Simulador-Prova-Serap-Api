using SME.Simulador.Prova.Serap.Dados.Configurations;

namespace SME.Simulador.Prova.Serap.IoC;

public static class ConfigurarDependencias
{
    public static void Configurar()
    {
        RegistrarMapeamentos.Registrar();
    }        
}