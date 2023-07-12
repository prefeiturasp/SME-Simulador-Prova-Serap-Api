using MediatR;
using SME.Simulador.Prova.Serap.Infra.Dtos;

namespace SME.Simulador.Prova.Serap.Aplicacao
{
    public class ObterIdBlocoPorQuestaoEProvaIdQuery : IRequest<BlocoItemDto>
    {
        public ObterIdBlocoPorQuestaoEProvaIdQuery(long provaId, long itemId)
        {
            ProvaId = provaId;
            ItemId = itemId;
        }
        public long ProvaId { get; }
        public long ItemId { get; }
    }
}