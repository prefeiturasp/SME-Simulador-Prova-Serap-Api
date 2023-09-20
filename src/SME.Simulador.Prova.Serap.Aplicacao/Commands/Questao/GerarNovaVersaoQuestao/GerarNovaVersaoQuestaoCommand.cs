using MediatR;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class GerarNovaVersaoQuestaoCommand : IRequest<long>
{
    public GerarNovaVersaoQuestaoCommand(Dominio.Questao questao)
    {
        Questao = questao;
    }
    public Dominio.Questao Questao { get; }
}