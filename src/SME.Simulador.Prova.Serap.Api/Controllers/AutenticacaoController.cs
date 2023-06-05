using Microsoft.AspNetCore.Mvc;
using SME.Simulador.Prova.Serap.Aplicacao;
using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.Api.Controllers;

[ApiController]
[Route("/api/v1/simulador/[controller]")]
public class AutenticacaoController : ControllerBase
{
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ValidacaoException), StatusCodes.Status422UnprocessableEntity)]
    [Produces("application/json")]
    [HttpPost(Name = nameof(AutenticarAsync))]
    public async Task<IActionResult> AutenticarAsync([FromBody] string request,
        [FromServices] IAutenticarUsuarioUseCase useCase)
    {
        return Ok(await useCase.ExecutarAsync(request));
    }
}