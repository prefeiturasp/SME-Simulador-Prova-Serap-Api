using MediatR;

namespace SME.Simulador.Prova.Serap.Aplicacao.Queries.VerificaSeEhProvaBibPorProvaId;

public class VerificaSeEhProvaBibQuery : IRequest<bool>
{
    public VerificaSeEhProvaBibQuery(long provaId)
    {
        ProvaId = provaId;
    }

    public long ProvaId { get; }
}