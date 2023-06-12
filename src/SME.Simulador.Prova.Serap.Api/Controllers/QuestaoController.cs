using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SME.Simulador.Prova.Serap.Aplicacao;
using SME.Simulador.Prova.Serap.Infra;
using SME.Simulador.Prova.Serap.Infra.Dtos;

namespace SME.Simulador.Prova.Serap.Api.Controllers;

[ApiController]
[Route("/api/v1/simulador/[controller]")]
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
}

