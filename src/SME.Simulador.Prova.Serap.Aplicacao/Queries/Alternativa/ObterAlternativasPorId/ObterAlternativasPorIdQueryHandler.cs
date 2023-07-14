using MediatR;
using SME.Simulador.Prova.Serap.Dados;
using SME.Simulador.Prova.Serap.Dados.Interfaces;
using SME.Simulador.Prova.Serap.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.Simulador.Prova.Serap.Aplicacao
{
    public class ObterAlternativasPorIdQueryHandler : IRequestHandler<ObterAlternativasPorIdQuery, Dominio.Alternativa>
    {
        private readonly IRepositorioAlternativa repositorioAlternativa;

        public ObterAlternativasPorIdQueryHandler(IRepositorioAlternativa repositorioAlternativa)
        {
            this.repositorioAlternativa = repositorioAlternativa ?? throw new ArgumentNullException(nameof(repositorioAlternativa));
        }

        public async Task<Alternativa> Handle(ObterAlternativasPorIdQuery request, CancellationToken cancellationToken)
        {
            return await repositorioAlternativa.ObterPorIdAsync(request.Id);
        }
    }
}
