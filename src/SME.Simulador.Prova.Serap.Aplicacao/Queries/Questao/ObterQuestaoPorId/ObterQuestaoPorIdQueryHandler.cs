using MediatR;
using SME.Simulador.Prova.Serap.Dados;
using SME.Simulador.Prova.Serap.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.Simulador.Prova.Serap.Aplicacao.Queries.Questao.ObterQuestaoPorId
{
    public class ObterQuestaoPorIdQueryHandler : IRequestHandler<ObterQuestaoPorIdQuery, SME.Simulador.Prova.Serap.Dominio.Questao>
    {
        private readonly IRepositorioQuestao repositorioQuestao;

        public ObterQuestaoPorIdQueryHandler(IRepositorioQuestao repositorioQuestao)
        {
            this.repositorioQuestao = repositorioQuestao ?? throw new ArgumentNullException(nameof(repositorioQuestao));
        }

        public async Task<SME.Simulador.Prova.Serap.Dominio.Questao> Handle(ObterQuestaoPorIdQuery request, CancellationToken cancellationToken)
        {
            return await repositorioQuestao.ObterPorIdAsync(request.QuestaoId);
        }

      
    }
}
