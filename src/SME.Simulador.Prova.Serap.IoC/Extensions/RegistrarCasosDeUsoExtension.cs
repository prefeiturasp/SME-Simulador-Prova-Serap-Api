using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SME.Simulador.Prova.Serap.Aplicacao;

namespace SME.Simulador.Prova.Serap.IoC;

internal static class RegistrarCasosDeUsoExtension
{
    internal static void RegistrarCasosDeUso(this IServiceCollection services)
    {
        services.TryAddScoped<IAutenticarUsuarioUseCase, AutenticarUsuarioUseCase>();
        services.TryAddScoped<IValidarAutenticacaoUsuarioUseCase, ValidarAutenticacaoUsuarioUseCase>();
        services.TryAddScoped<IRevalidarTokenUseCase, RevalidarTokenUseCase>();
        services.TryAddScoped<IObterQuestaoCompletaPorIdUseCase, ObterQuestaoCompletaPorIdUseCase>();
        services.TryAddScoped<IObterQuestoesResumoPorCadernoIdUseCase, ObterQuestoesResumoPorCadernoIdUseCase>();
    }
}