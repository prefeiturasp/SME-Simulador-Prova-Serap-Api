using Microsoft.AspNetCore.Mvc;
using SME.Simulador.Prova.Serap.Aplicacao;
using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.Api.Controllers;

[ApiController]
[Route("/api/v1/simulador/[controller]")]
public class AutenticacaoController : ControllerBase
{
    [ValidarDto]
    [ProducesResponseType(typeof(AutenticacaoValidarDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(List<string>), StatusCodes.Status422UnprocessableEntity)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [HttpPost(Name = nameof(AutenticarAsync))]
    public async Task<IActionResult> AutenticarAsync([FromBody] AutenticacaoDto request,
        [FromServices] IAutenticarUsuarioUseCase useCase)
    {
        return Ok(await useCase.ExecutarAsync(request));
    }
}