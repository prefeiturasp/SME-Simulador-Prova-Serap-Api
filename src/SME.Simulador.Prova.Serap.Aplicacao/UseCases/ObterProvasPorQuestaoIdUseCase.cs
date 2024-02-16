using MediatR;
using SME.Simulador.Prova.Serap.Dominio;
using SME.Simulador.Prova.Serap.Infra;
using System.Collections.Generic;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class ObterProvasPorQuestaoIdUseCase : AbstractUseCase, IObterProvasPorQuestaoIdUseCase
{
    public ObterProvasPorQuestaoIdUseCase(IMediator mediator) : base(mediator)
    {
    }

    public async Task<IEnumerable<ProvaLegadoDto>> ExecutarAsync(long request)
    {
        var questao = await mediator.Send(new ObterQuestaoPorIdQuery(request));
        if (questao == null)
            throw new Exception($"Não foi encontrado a questão com o id: {request}");

        var questaoCodigo = questao.CodigoItem;
        var provasNaoIniciadas = await mediator.Send(new ObterProvasNaoIniciadasPorQuestaoIdQuery(questaoCodigo));
        var provasParaSeremSincronizadas = await ObterProvasParaSeramSincronizadasENaoForamIniciadas(questaoCodigo);
        var idsProvasParaAtualizar = new HashSet<long>();

        foreach (var id in provasNaoIniciadas.Select(c => c.Id))
            idsProvasParaAtualizar.Add(id);

        foreach (var id in provasParaSeremSincronizadas.Select(c => c.Id))
            idsProvasParaAtualizar.Add(id);

        var provasPorQuestao = await mediator.Send(new ObterProvasEVersaoItemPorQuestaoCodigoEProvasIdQuery(questaoCodigo, idsProvasParaAtualizar.ToArray()));
        return provasPorQuestao;
    }

    private async Task<IEnumerable<ProvaLegadoDto>> ObterProvasParaSeramSincronizadasENaoForamIniciadas(string questaoCodigo)
    {
        var execucaoControle = await mediator.Send(new ObterUltimaExecucaoPorTipoQuery(ExecucaoControleTipo.ProvaLegadoSincronizacao));
        var filtroProvasParaSeremSincronizadas = new FiltroProvasParaSeremSincronizadasDto(questaoCodigo, execucaoControle.UltimaExecucao);
        return await mediator.Send(new ObterProvasPorQuestaoParaSeremSincronizadasENaoForamIniciadasQuery(filtroProvasParaSeremSincronizadas));
    }
}