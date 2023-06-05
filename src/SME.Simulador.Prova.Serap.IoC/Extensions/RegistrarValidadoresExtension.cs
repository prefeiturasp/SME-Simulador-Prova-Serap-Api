using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace SME.Simulador.Prova.Serap.IoC;

internal static class RegistrarValidadoresExtension
{
    internal static void RegistrarValidadores(this IServiceCollection services)
    {
        var assemblyAplicacao = AppDomain.CurrentDomain.Load("SME.Simulador.Prova.Serap.Aplicacao");
        var validators = AssemblyScanner.FindValidatorsInAssembly(assemblyAplicacao);
        validators.ForEach(result => services.TryAddScoped(result.InterfaceType, result.ValidatorType));
    }
}