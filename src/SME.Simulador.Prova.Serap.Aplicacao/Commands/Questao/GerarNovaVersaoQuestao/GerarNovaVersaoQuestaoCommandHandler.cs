using MediatR;
using SME.Simulador.Prova.Serap.Dados;
using SME.Simulador.Prova.Serap.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.Simulador.Prova.Serap.Aplicacao.Commands.Questao.GerarNovaVersaoQuestao
{
    public class GerarNovaVersaoQuestaoCommandHandler : IRequestHandler<GerarNovaVersaoQuestaoCommand, long>
    {
        private readonly IRepositorioQuestao repositorioQuestao;

        public GerarNovaVersaoQuestaoCommandHandler(IRepositorioQuestao repositorioQuestao)
        {
            this.repositorioQuestao = repositorioQuestao;
        }

        public async Task<long> Handle(GerarNovaVersaoQuestaoCommand request, CancellationToken cancellationToken)
        {
            return await repositorioQuestao.SalvarAsync(request.Questao) ;
        }
    }
}
