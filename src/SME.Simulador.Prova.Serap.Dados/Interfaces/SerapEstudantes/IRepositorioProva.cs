using SME.Simulador.Prova.Serap.Dominio;
using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.Dados;

public interface IRepositorioProva
{
    Task<bool> EhProvaIniciadaAsync(long provaLegadoId);
    Task<IEnumerable<ProvaDto>> ObterProvasPorStatusAsync(ProvaStatus status);
}