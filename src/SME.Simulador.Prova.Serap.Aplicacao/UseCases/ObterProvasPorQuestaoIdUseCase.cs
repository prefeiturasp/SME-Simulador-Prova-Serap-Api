﻿using MediatR;
using SME.Simulador.Prova.Serap.Dominio;
using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class ObterProvasPorQuestaoIdUseCase : AbstractUseCase, IObterProvasPorQuestaoIdUseCase
{
    public ObterProvasPorQuestaoIdUseCase(IMediator mediator) : base(mediator)
    {
    }
    
    public async Task<IEnumerable<ProvaLegadoDto>> ExecutarAsync(long request)
    {
        var provasNaoIniciadas = await mediator.Send(new ObterProvasPorStatusQuery(ProvaStatus.NaoIniciado));
        var provasParaSeremSincronizadas = await ObterProvasParaSeramSincronizadas(request);

        var idsProvasParaAtualizar = new List<long>();
        idsProvasParaAtualizar.AddRange(provasNaoIniciadas.Select(c => c.ProvaLegadoId));
        idsProvasParaAtualizar.AddRange(provasParaSeremSincronizadas.Select(c => c.Id));

        var provasPorQuestao = await mediator.Send(new ObterProvasPorQuestaoIdQuery(request));

        return provasPorQuestao.Where(c => idsProvasParaAtualizar.Contains(c.Id));
    }

    private async Task<IEnumerable<ProvaLegadoDto>> ObterProvasParaSeramSincronizadas(long questaoId)
    {
        var execucaoControle = await mediator.Send(new ObterUltimaExecucaoPorTipoQuery(ExecucaoControleTipo.ProvaLegadoSincronizacao));
        var filtroProvasParaSeremSincronizadas = new FiltroProvasParaSeremSincronizadasDto(questaoId, execucaoControle.UltimaExecucao);
        return await mediator.Send(new ObterProvasPorQuestaoParaSeremSincronizadasQuery(filtroProvasParaSeremSincronizadas));        
    }
}