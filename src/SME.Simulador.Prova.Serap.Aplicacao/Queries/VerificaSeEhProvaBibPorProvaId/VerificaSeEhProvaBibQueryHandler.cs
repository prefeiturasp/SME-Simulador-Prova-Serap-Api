using MediatR;
using SME.Simulador.Prova.Serap.Aplicacao.Queries.Questao.ObterQuestaoPorId;
using SME.Simulador.Prova.Serap.Dados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.Simulador.Prova.Serap.Aplicacao.Queries.VerificaSeEhProvaBibPorProvaId
{
    public class VerificaSeEhProvaBibQueryHandler : IRequestHandler<VerificaSeEhProvaBibQuery, bool>
    {
        private readonly IRepositorioProvaLegado repositorioProva;

        public VerificaSeEhProvaBibQueryHandler(IRepositorioProvaLegado repositorioProva)
        {
            this.repositorioProva = repositorioProva ?? throw new ArgumentNullException(nameof(repositorioProva));
        }

        public async Task<bool> Handle(VerificaSeEhProvaBibQuery request, CancellationToken cancellationToken)
        {
            return await repositorioProva.EhProvaBib(request.ProvaId) ;
        }


    }
}
