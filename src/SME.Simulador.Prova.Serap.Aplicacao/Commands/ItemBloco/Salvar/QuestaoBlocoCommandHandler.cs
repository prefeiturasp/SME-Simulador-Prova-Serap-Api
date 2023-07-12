using MediatR;
using SME.Simulador.Prova.Serap.Dados.Interfaces;

namespace SME.Simulador.Prova.Serap.Aplicacao 
{ 
    public class QuestaoBlocoCommandHandler : IRequestHandler<QuestaoBlocoCommand, long>
    {
        private readonly IRepositorioBlocoItems repositorioBlocoItems;

        public QuestaoBlocoCommandHandler(IRepositorioBlocoItems repositorioBlocoItems)
        {
            this.repositorioBlocoItems = repositorioBlocoItems;
        }

        public async Task<long> Handle(QuestaoBlocoCommand request, CancellationToken cancellationToken)
        {
            return await repositorioBlocoItems.SalvarAsync(request.ItemBloco);
        }
    }
}