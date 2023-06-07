using Microsoft.Extensions.DependencyInjection;
using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.IoC;

internal static class RegistrarMvcExtension
{
    internal static void RegistrarMvc(this IServiceCollection services)
    {
        services.AddMvc(options =>
            {
                options.EnableEndpointRouting = true;
                options.Filters.Add(new ValidarDtoAttribute());
            });        
    }
}