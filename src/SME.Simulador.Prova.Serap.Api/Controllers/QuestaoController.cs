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

    //[Authorize("Bearer")]
    [HttpGet("completa")]
    [ProducesResponseType(typeof(QuestaoCompletaDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(QuestaoCompletaDto), StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> ObterCompletaPorId([FromBody] ParametrosQuestaoCompletaDto parametros, [FromServices] IObterQuestaoCompletaPorIdUseCase obterQuestaoCompletaPorIdUseCase)
    {
        return Ok(await obterQuestaoCompletaPorIdUseCase.ExecutarAsync(parametros));
    }

}

