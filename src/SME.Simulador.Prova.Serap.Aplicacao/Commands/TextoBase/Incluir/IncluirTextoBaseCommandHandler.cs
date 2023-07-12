using MediatR;
using SME.Simulador.Prova.Serap.Dados.Interfaces;

namespace SME.Simulador.Prova.Serap.Aplicacao.Commands.TextoBase.Salvar
{
    public class IncluirTextoBaseCommandHandler : IRequestHandler<IncluirTextoBaseCommand, long>
    {
        private readonly IRepositorioTextoBase repositorioTextoBase;

        public IncluirTextoBaseCommandHandler(IRepositorioTextoBase repositorioTextoBase)
        {
            this.repositorioTextoBase = repositorioTextoBase;
        }

        public async Task<long> Handle(IncluirTextoBaseCommand request, CancellationToken cancellationToken)
        {
            return await repositorioTextoBase.SalvarAsync(request.TextoBase);
        }
    }
}