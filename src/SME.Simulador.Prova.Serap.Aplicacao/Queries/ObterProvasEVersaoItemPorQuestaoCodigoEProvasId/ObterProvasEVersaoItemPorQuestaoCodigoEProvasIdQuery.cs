using MediatR;
using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class ObterProvasEVersaoItemPorQuestaoCodigoEProvasIdQuery : IRequest<IEnumerable<ProvaLegadoDto>>
{
    public ObterProvasEVersaoItemPorQuestaoCodigoEProvasIdQuery(string questaoCodigo, long[] provasId)
    {
        QuestaoCodigo = questaoCodigo;
        ProvasId = provasId;
    }

    public string QuestaoCodigo { get; }

    public long[] ProvasId { get; }
}