using MediatR;
using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.Aplicacao.Queries.Questao.ObterQuestaoPorId
{
    public class ObterQuestaoPorIdQuery : IRequest<SME.Simulador.Prova.Serap.Dominio.Questao>
    {
        public ObterQuestaoPorIdQuery(long questaoId)
        {
            QuestaoId = questaoId;
        }

        public long QuestaoId { get; }
    }
}