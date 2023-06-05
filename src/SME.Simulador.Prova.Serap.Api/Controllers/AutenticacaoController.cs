using Microsoft.AspNetCore.Mvc;
using SME.Simulador.Prova.Serap.Aplicacao;

namespace SME.Simulador.Prova.Serap.Api.Controllers;

[ApiController]
[Route("/api/v1/simulador/[controller]")]
public class AutenticacaoController : ControllerBase
{
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(IEnumerable<string>), StatusCodes.Status422UnprocessableEntity)]
    [HttpPost(Name = nameof(AutenticarAsync))]
    public async Task<IActionResult> AutenticarAsync([FromBody] string request,
        [FromServices] IAutenticarUsuarioUseCase useCase)
    {
        return Ok(await useCase.ExecutarAsync(request));
    }
}