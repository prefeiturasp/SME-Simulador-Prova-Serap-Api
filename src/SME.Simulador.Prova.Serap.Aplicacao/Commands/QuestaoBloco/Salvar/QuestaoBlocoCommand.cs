using MediatR;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class QuestaoBlocoCommand : IRequest<long>
{
    public QuestaoBlocoCommand(Dominio.QuestaoBloco itemBloco)
    {
        QuestaoBloco = itemBloco;
    }
    
    public Dominio.QuestaoBloco QuestaoBloco { get; }
}