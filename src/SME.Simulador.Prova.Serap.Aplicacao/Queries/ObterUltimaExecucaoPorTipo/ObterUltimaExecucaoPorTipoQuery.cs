using MediatR;
using SME.Simulador.Prova.Serap.Dominio;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class ObterUltimaExecucaoPorTipoQuery : IRequest<ExecucaoControle>
{
    public ObterUltimaExecucaoPorTipoQuery(ExecucaoControleTipo execucaoTipo)
    {
        ExecucaoTipo = execucaoTipo;
    }

    public ExecucaoControleTipo ExecucaoTipo { get; }
}