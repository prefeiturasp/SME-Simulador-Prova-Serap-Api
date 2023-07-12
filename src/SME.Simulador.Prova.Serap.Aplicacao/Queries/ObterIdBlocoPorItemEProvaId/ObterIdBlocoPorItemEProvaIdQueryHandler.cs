using MediatR;
using SME.Simulador.Prova.Serap.Dados.Interfaces;
using SME.Simulador.Prova.Serap.Infra.Dtos;

namespace SME.Simulador.Prova.Serap.Aplicacao
{
    public class ObterIdBlocoPorItemEProvaIdQueryHandler : IRequestHandler<ObterIdBlocoPorQuestaoEProvaIdQuery, BlocoItemDto>
    {
        private readonly IRepositorioBlocoItems repositorioBlocos;
        public ObterIdBlocoPorItemEProvaIdQueryHandler(IRepositorioBlocoItems repositorioBlocos)
        {
            this.repositorioBlocos = repositorioBlocos ?? throw new ArgumentNullException(nameof(repositorioBlocos));
        }
        public async Task<BlocoItemDto> Handle(ObterIdBlocoPorQuestaoEProvaIdQuery request, CancellationToken cancellationToken)
        {
            return await repositorioBlocos.ObterBlocoIdPorItemEhProvaId(request.ProvaId, request.ItemId);
        }
    }
}