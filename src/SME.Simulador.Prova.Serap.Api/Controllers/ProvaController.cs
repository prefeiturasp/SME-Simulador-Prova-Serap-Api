using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SME.Simulador.Prova.Serap.Aplicacao;
using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.Api.Controllers;

[ApiController]
[Route("/simulador/api/v1/[controller]")]
public class ProvaController : ControllerBase
{
    [ValidarDto]
    [ProducesResponseType(typeof(IEnumerable<QuestaoResumoDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(List<string>), StatusCodes.Status422UnprocessableEntity)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [HttpGet("caderno/{cadernoId:long}", Name = nameof(ObterQuestoesResumoPorCadernoIdAsync))]
   // [Authorize("Bearer")]
    public async Task<IActionResult> ObterQuestoesResumoPorCadernoIdAsync([Required] long cadernoId,
        [FromServices] IObterQuestoesResumoPorCadernoIdUseCase useCase)
    {
        return Ok(await useCase.ExecutarAsync(cadernoId));
    }
}