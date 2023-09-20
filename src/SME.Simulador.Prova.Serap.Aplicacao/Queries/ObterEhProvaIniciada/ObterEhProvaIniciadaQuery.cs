using MediatR;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class ObterEhProvaIniciadaQuery : IRequest<bool>
{
    public ObterEhProvaIniciadaQuery(long provaId)
    {
        ProvaId = provaId;
    }

    public long ProvaId { get; }
}