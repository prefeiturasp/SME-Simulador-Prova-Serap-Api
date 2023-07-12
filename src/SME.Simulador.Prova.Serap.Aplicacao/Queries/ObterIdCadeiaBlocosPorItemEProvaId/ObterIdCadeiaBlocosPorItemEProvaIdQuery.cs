using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.Simulador.Prova.Serap.Aplicacao
{
    public class ObterIdCadeiaBlocosPorItemEProvaIdQuery : IRequest<long>
    {
        public ObterIdCadeiaBlocosPorItemEProvaIdQuery(long provaId, long itemId)
        {
            ProvaId = provaId;
            ItemId = itemId;
        }
        public long ProvaId { get; }
        public long ItemId { get; }
    }
}