using Microsoft.AspNetCore.Builder;
using SME.Simulador.Prova.Serap.Aplicacao;

namespace SME.Simulador.Prova.Serap.IoC;

public static class RegistrarDependencias
{
    public static void Registrar(WebApplicationBuilder builder)
    {
        builder.RegistrarEnvironmentVariables();
        builder.RegistrarTelemetria();
        builder.Services.RegistrarServicos();
        builder.Services.RegistrarContextos();
        builder.Services.RegistrarAutenticacao();
        builder.Services.RegistrarCors();
        builder.Services.RegistrarRedis();
        builder.Services.RegistrarMvc();
        builder.Services.RegistrarRepositorios();
        RegistrarMediator.Registrar(builder.Services);
        builder.Services.RegistrarValidadores();
        builder.Services.RegistrarCasosDeUso();
    }
}
