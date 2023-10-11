using MediatR;
using SME.Simulador.Prova.Serap.Dominio;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class ObterTextoBasePorIdQuery : IRequest<TextoBase?>
{
    public ObterTextoBasePorIdQuery(long textoBaseId)
    {
        TextoBaseId = textoBaseId;
    }

    public long TextoBaseId { get; }
}