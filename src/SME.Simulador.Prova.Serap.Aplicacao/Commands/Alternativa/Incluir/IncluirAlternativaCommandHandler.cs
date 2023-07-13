using MediatR;
using SME.Simulador.Prova.Serap.Aplicacao.Commands.TextoBase.Salvar;
using SME.Simulador.Prova.Serap.Dados;
using SME.Simulador.Prova.Serap.Dados.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.Simulador.Prova.Serap.Aplicacao
{
    public class IncluirAlternativaCommandHandler : IRequestHandler<IncluirAlternativaCommand, long>
    {
        private readonly IRepositorioAlternativa repositorioAlternativa;

        public IncluirAlternativaCommandHandler(IRepositorioAlternativa repositorioAlternativa)
        {
            this.repositorioAlternativa = repositorioAlternativa;
        }

        public async Task<long> Handle(IncluirAlternativaCommand request, CancellationToken cancellationToken)
        {
            return await repositorioAlternativa.SalvarAsync(request.Alternativa);
        }
    }
}
