using MediatR;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class ObterEhProvaIniciadaQuery : IRequest<bool>
{
    public ObterEhProvaIniciadaQuery(long provaLegadoId)
    {
        ProvaLegadoId = provaLegadoId;
    }

    public long ProvaLegadoId { get; }
}