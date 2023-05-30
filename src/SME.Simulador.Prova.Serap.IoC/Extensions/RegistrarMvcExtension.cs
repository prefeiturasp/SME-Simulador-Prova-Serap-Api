using Microsoft.Extensions.DependencyInjection;

namespace SME.Simulador.Prova.Serap.IoC;

internal static class RegistrarMvcExtension
{
    internal static void RegistrarMvc(this IServiceCollection services)
    {
        services.AddMvc(options =>
            {
                options.EnableEndpointRouting = true;
            });        
    }
}