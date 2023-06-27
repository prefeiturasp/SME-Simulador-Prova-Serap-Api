using MediatR;
using SME.Simulador.Prova.Serap.Dominio;
using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class ObterProvasPorStatusQuery : IRequest<IEnumerable<ProvaDto>>
{
    public ObterProvasPorStatusQuery(ProvaStatus status)
    {
        Status = status;
    }

    public ProvaStatus Status { get; }
}