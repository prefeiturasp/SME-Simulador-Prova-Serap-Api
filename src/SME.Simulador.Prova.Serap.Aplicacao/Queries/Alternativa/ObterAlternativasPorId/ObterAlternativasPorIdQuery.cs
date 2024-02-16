using MediatR;
using SME.Simulador.Prova.Serap.Dominio;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class ObterAlternativasPorIdQuery : IRequest<Alternativa>
{
    public ObterAlternativasPorIdQuery(long id)
    {
        Id = id;
    }
    
    public long Id { get; }
}