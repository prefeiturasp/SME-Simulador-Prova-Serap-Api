using MediatR;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class ObterQuestaoPorIdQuery : IRequest<Dominio.Questao>
{
    public ObterQuestaoPorIdQuery(long questaoId)
    {
        QuestaoId = questaoId;
    }

    public long QuestaoId { get; }
}