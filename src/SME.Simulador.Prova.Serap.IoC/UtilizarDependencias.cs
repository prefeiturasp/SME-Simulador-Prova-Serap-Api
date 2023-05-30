using Microsoft.AspNetCore.Builder;

namespace SME.Simulador.Prova.Serap.IoC;

public static class UtilizarDependencias
{
    public static void Utilizar(WebApplication app)
    {
        app.UtilizarCors();
        app.UtilizarElasticApm();
        app.UtilizarMetricas();
    }
}