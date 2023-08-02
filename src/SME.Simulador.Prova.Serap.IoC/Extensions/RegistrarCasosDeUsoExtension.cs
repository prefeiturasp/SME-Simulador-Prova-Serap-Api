using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SME.Simulador.Prova.Serap.Aplicacao;
using SME.Simulador.Prova.Serap.Aplicacao.Interfaces;

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
        services.TryAddScoped<IObterProvasPorQuestaoIdUseCase, ObterProvasPorQuestaoIdUseCase>();
        services.TryAddScoped<IUploadFileUseCase, UploadFileUseCase>();
        services.TryAddScoped<IGerarNovaVersaoQuestaoUseCase, GerarNovaVersaoQuestaoUseCase>();
    }
}