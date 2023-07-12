using MediatR;
using SME.Simulador.Prova.Serap.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.Simulador.Prova.Serap.Aplicacao
{
    public class IncluirAlternativaCommand : IRequest<long>
    {
        public IncluirAlternativaCommand(Alternativa alternativa)
        {
            Alternativa = alternativa;
        }
        public Alternativa Alternativa { get; }
    }
}
