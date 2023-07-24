using MediatR;
using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class ObterProvasNaoIniciadasPorQuestaoIdQuery : IRequest<IEnumerable<ProvaLegadoDto>>
{
    public ObterProvasNaoIniciadasPorQuestaoIdQuery(string questaoCodigo)
    {
        QuestaoCodigo = questaoCodigo;
    }

    public string QuestaoCodigo { get; }
}