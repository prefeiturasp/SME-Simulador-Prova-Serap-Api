﻿using MediatR;
using SME.Simulador.Prova.Serap.Dados.Interfaces;
using SME.Simulador.Prova.Serap.Infra.Dtos;

namespace SME.Simulador.Prova.Serap.Aplicacao
{
    public class ObterQuestaoBlocoPorItemEProvaIdQueryHandler : IRequestHandler<ObterQuestaoBlocoPorItemEProvaIdQuery, BlocoItemDto>
    {
        private readonly IRepositorioBlocoQuestao repositorioBlocos;
        public ObterQuestaoBlocoPorItemEProvaIdQueryHandler(IRepositorioBlocoQuestao repositorioBlocos)
        {
            this.repositorioBlocos = repositorioBlocos ?? throw new ArgumentNullException(nameof(repositorioBlocos));
        }
        public async Task<BlocoItemDto> Handle(ObterQuestaoBlocoPorItemEProvaIdQuery request, CancellationToken cancellationToken)
        {
            return await repositorioBlocos.ObterBlocoIdPorItemEhProvaId(request.ProvaId, request.ItemId);
        }
    }
}