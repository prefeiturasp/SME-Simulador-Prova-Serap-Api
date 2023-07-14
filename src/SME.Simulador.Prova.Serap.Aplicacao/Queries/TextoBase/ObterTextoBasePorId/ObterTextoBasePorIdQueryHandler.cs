using MediatR;
using SME.Simulador.Prova.Serap.Dados.Interfaces;
using SME.Simulador.Prova.Serap.Dominio;

namespace SME.Simulador.Prova.Serap.Aplicacao
{
    public class ObterTextoBasePorIdQueryHandler : IRequestHandler<ObterTextoBasePorIdQuery, TextoBase>
    {
        private readonly IRepositorioTextoBase repositorioTextoBase;

        public ObterTextoBasePorIdQueryHandler(IRepositorioTextoBase repositorioTextoBase)
        {
            this.repositorioTextoBase = repositorioTextoBase ?? throw new ArgumentNullException(nameof(repositorioTextoBase));
        }

        public async Task<TextoBase> Handle(ObterTextoBasePorIdQuery request, CancellationToken cancellationToken)
        {
            return await repositorioTextoBase.ObterPorIdAsync(request.TextoBaseId);
        }
    }
}