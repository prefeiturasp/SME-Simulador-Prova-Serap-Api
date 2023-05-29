using Microsoft.AspNetCore.Builder;
using SME.Simulador.Prova.Serap.Dados;
using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.IoC;

public static class RegistrarDependencias
{
    public static void Registrar(WebApplicationBuilder builder)
    {
        builder.ConfigurarTelemetria();
        builder.ConfigurarDataAccess();
    }
}
