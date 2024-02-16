using MediatR;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class IncluirQuestaoArquivoCommand : IRequest<long>
{
    public IncluirQuestaoArquivoCommand(Dominio.QuestaoArquivo questaoArquivo)
    {
        QuestaoArquivo = questaoArquivo;
    }

    public Dominio.QuestaoArquivo QuestaoArquivo { get; }
}