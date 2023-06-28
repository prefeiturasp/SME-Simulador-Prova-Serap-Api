using MediatR;
using SME.Simulador.Prova.Serap.Dados;
using SME.Simulador.Prova.Serap.Dominio;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class ObterUltimaExecucaoPorTipoQueryHandler : IRequestHandler<ObterUltimaExecucaoPorTipoQuery, ExecucaoControle>
{
    private readonly IRepositorioExecucaoControle repositorioExecucaoControle;

    public ObterUltimaExecucaoPorTipoQueryHandler(IRepositorioExecucaoControle repositorioExecucaoControle)
    {
        this.repositorioExecucaoControle = repositorioExecucaoControle ?? throw new ArgumentNullException(nameof(repositorioExecucaoControle));
    }

    public async Task<ExecucaoControle> Handle(ObterUltimaExecucaoPorTipoQuery request, CancellationToken cancellationToken)
    {
        return await repositorioExecucaoControle.ObterUltimaExecucaoPorTipoAsync(request.ExecucaoTipo);
    }
}