using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SME.Simulador.Prova.Serap.Dados;
using SME.Simulador.Prova.Serap.Dados.Interfaces;
using SME.Simulador.Prova.Serap.Dados.Repositorios;

namespace SME.Simulador.Prova.Serap.IoC;

internal static class RegistrarRepositoriosExtension
{
    internal static void RegistrarRepositorios(this IServiceCollection services)
    {
        services.TryAddScoped<IRepositorioCache, RepositorioCache>();
        services.TryAddScoped<IRepositorioUsuarioSerapCoreSso, RepositorioUsuarioSerapCoreSso>();
        services.TryAddScoped<IRepositorioAlternativa, RepositorioAlternativa>();
        services.TryAddScoped<IRepositorioQuestao, RepositorioQuestao>();
        services.TryAddScoped<IRepositorioArquivo, RepositorioArquivo>();
        services.TryAddScoped<IRepositorioProvaLegado, RepositorioProvaLegado>();
        services.TryAddScoped<IRepositorioExecucaoControle, RepositorioExecucaoControle>();
        services.TryAddScoped<IRepositorioBlocoQuestao, RepositorioBlocoQuestao>();
        services.TryAddScoped<IRepositorioCadeiaBlocos, RepositorioCadeiaBlocos>();
        services.TryAddScoped<IRepositorioTextoBase, RepositorioTextoBase>();
        services.TryAddScoped<IRepositorioQuestaoArquivo, RepositorioQuestaoArquivo>();
        services.TryAddScoped<IRepositorioQuestaoAudio, RepositorioQuestaoAudio>();
        services.TryAddScoped<IRepositorioQuestaoGradeCurricular, RepositorioQuestaoGradeCurricular>();
        services.TryAddScoped<IRepositorioQuestaoHabilidade, RepositorioQuestaoHabilidade>();

    }
}