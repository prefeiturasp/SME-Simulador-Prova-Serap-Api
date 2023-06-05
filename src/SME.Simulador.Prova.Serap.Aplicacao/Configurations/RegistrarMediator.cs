using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public static class RegistrarMediator
{
    public static void Registrar(IServiceCollection services)
    {
        services.AddMediatR(config => config.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
    }
}