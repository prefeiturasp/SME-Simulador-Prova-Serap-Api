using MediatR;
using SME.Simulador.Prova.Serap.Dominio;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class IncluirAlternativaCommand : IRequest<long>
{
    public IncluirAlternativaCommand(Alternativa alternativa)
    {
        Alternativa = alternativa;
    }
    public Alternativa Alternativa { get; }
}