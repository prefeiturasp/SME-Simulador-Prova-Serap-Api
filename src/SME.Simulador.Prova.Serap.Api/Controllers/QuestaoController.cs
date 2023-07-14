using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SME.Simulador.Prova.Serap.Aplicacao;
using SME.Simulador.Prova.Serap.Aplicacao.Interfaces;
using SME.Simulador.Prova.Serap.Infra;
using SME.Simulador.Prova.Serap.Infra.Dtos.Parametros;

namespace SME.Simulador.Prova.Serap.Api.Controllers;

[ApiController]
[Route("/simulador/api/v1/[controller]")]
public class QuestaoController : ControllerBase
{
    [ValidarDto]
    [ProducesResponseType(typeof(QuestaoCompletaDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(QuestaoCompletaDto), StatusCodes.Status422UnprocessableEntity)]
    [HttpGet("completa", Name = nameof(ObterCompletaPorId))]
    [Authorize("Bearer")]
    public async Task<IActionResult> ObterCompletaPorId([FromQuery] ParametrosQuestaoCompletaDto parametros,
        [FromServices] IObterQuestaoCompletaPorIdUseCase useCase)
    {
        return Ok(await useCase.ExecutarAsync(parametros));
    }

    [ProducesResponseType(typeof(IEnumerable<ProvaLegadoDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(List<string>), StatusCodes.Status422UnprocessableEntity)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [HttpGet("{questaoId:long}/provas", Name = nameof(ObterProvasPorQuestaoIdAsync))]
    [Authorize("Bearer")]
    public async Task<IActionResult> ObterProvasPorQuestaoIdAsync([Required] long questaoId,
        [FromServices] IObterProvasPorQuestaoIdUseCase useCase)
    {
        return Ok(await useCase.ExecutarAsync(questaoId));
    }


    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(List<string>), StatusCodes.Status422UnprocessableEntity)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [HttpPost("Salvar-Alteracao", Name = nameof(SalvarAlteracao))]
    [Authorize("Bearer")]
    public async Task<IActionResult> SalvarAlteracao([Required] ParametrosQuestaoSalvar parametos,
        [FromServices] IGerarNovaVersaoQuestaoUseCase useCase)
    {
        return Ok(await useCase.ExecutarAsync(parametos));
    }

}


