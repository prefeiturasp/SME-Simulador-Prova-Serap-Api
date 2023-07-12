using MediatR;
using SME.Simulador.Prova.Serap.Dados.Interfaces;

namespace SME.Simulador.Prova.Serap.Aplicacao
{
    public class ObterIdCadeiaBlocosPorItemEProvaIdQueryHandler : IRequestHandler<ObterIdCadeiaBlocosPorItemEProvaIdQuery, long>
    {
        private readonly IRepositorioCadeiaBlocos repositorioCadeiaBlocos;
        public ObterIdCadeiaBlocosPorItemEProvaIdQueryHandler(IRepositorioCadeiaBlocos repositorioCadeiaBlocos)
        {
            this.repositorioCadeiaBlocos = repositorioCadeiaBlocos ?? throw new ArgumentNullException(nameof(repositorioCadeiaBlocos));
        }
        public async Task<long> Handle(ObterIdCadeiaBlocosPorItemEProvaIdQuery request, CancellationToken cancellationToken)
        {
            return await repositorioCadeiaBlocos.ObterBlocoIdPorItemEhProvaId(request.ProvaId, request.ItemId);
        }
    }
}