using MediatR;
using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class ObterQuestaoCompletaPorIdUseCase : AbstractUseCase, IObterQuestaoCompletaPorIdUseCase
{
    public ObterQuestaoCompletaPorIdUseCase(IMediator mediator) : base(mediator) { }

    public async Task<QuestaoCompletaDto> ExecutarAsync(ParametrosQuestaoCompletaDto parametros)
    {
        var questaoSerap = await mediator.Send(new ObterQuestaoCadernoProvaQuery(parametros.QuestaoId, parametros.CadernoId));

        if (questaoSerap == null) 
            throw new NegocioException("Questão não encontrada.");
        
        var ehProvaIniciada = await mediator.Send(new ObterEhProvaIniciadaQuery(questaoSerap.ProvaId));        

        var questao = new QuestaoCompletaDto
        {
            Id = questaoSerap.Id,
            Ordem = questaoSerap.Ordem,
            TextoBase = questaoSerap.TextoBase,
            Enunciado = questaoSerap.Enunciado,
            Caderno = questaoSerap.Caderno,
            TipoItem = questaoSerap.TipoItem,
            QuantidadeAlternativas = questaoSerap.QuantidadeAlternativas,
            QuestaoAnteriorId = questaoSerap.QuestaoAnteriorId,
            ProximaQuestaoId = questaoSerap.ProximaQuestaoId,
            EhProvaIniciada = ehProvaIniciada
        };

        var alternativas = await mediator.Send(new ObterAlternativasPorQuestaoIdQuery(parametros.QuestaoId));

        if (alternativas != null)
            questao.Alternativas = alternativas;

        await TratarAudiosQuestao(questao);
        await TratarVideosQuestao(questao);

        return questao;
    }

    private async Task TratarAudiosQuestao(QuestaoCompletaDto questaoSerap)
    {
        var audiosQuestao = await mediator.Send(new ObterAudiosPorQuestaoIdQuery(questaoSerap.Id));
        
        if (audiosQuestao != null && audiosQuestao.Any())
            questaoSerap.Audios = audiosQuestao;
    }

    private async Task TratarVideosQuestao(QuestaoCompletaDto questaoSerap)
    {
        var videosQuestao = await mediator.Send(new ObterVideosPorQuestaoIdQuery(questaoSerap.Id));

        if (videosQuestao != null && videosQuestao.Any())
            questaoSerap.Videos = videosQuestao;
    }
}