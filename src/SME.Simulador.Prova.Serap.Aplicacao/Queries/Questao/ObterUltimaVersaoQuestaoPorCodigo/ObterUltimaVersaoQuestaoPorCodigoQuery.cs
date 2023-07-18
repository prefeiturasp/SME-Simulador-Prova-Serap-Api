using MediatR;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class ObterUltimaVersaoQuestaoPorCodigoQuery : IRequest<int>
{
    public ObterUltimaVersaoQuestaoPorCodigoQuery(string codigoItem)
    {
        CodigoItem = codigoItem;
    }
    
    public string CodigoItem { get; }
}