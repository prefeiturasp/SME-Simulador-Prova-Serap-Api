﻿using MediatR;
using SME.Simulador.Prova.Serap.Infra.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.Simulador.Prova.Serap.Aplicacao
{
    public class ObterCadeiaBlocoQuestaoPorItemEProvaIdQuery : IRequest<CadeiaBlocoQuestaoDto>
    {
        public ObterCadeiaBlocoQuestaoPorItemEProvaIdQuery(long provaId, long itemId)
        {
            ProvaId = provaId;
            ItemId = itemId;
        }
        public long ProvaId { get; }
        public long ItemId { get; }
    }
}