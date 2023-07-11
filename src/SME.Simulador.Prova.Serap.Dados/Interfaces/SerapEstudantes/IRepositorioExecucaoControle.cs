using SME.Simulador.Prova.Serap.Dominio;

namespace SME.Simulador.Prova.Serap.Dados;

public interface IRepositorioExecucaoControle
{
    Task<ExecucaoControle> ObterUltimaExecucaoPorTipoAsync(ExecucaoControleTipo execucaoControleTipo);
}