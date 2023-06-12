using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SME.Simulador.Prova.Serap.Aplicacao;
using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.Api.Controllers;

[ApiController]
[Route("/simulador/api/v1/[controller]")]
public class AutenticacaoController : ControllerBase
{
    [ValidarDto]
    [ProducesResponseType(typeof(AutenticacaoValidarDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(List<string>), StatusCodes.Status422UnprocessableEntity)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [HttpPost(Name = nameof(AutenticarAsync))]
    [AllowAnonymous]
    public async Task<IActionResult> AutenticarAsync([FromBody] AutenticacaoDto request,
        [FromServices] IAutenticarUsuarioUseCase useCase)
    {
        return Ok(await useCase.ExecutarAsync(request));
    }

    [ValidarDto]
    [ProducesResponseType(typeof(UsuarioAutenticadoDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(RetornoBaseDto), StatusCodes.Status500InternalServerError)]
    [HttpPost("validar", Name = nameof(ValidarAsync))]
    [AllowAnonymous]
    public async Task<IActionResult> ValidarAsync([FromBody] ValidarAutenticacaoUsuarioDto request, 
        [FromServices] IValidarAutenticacaoUsuarioUseCase useCase)
    {
        return Ok(await useCase.ExecutarAsync(request));
    }    
    
    [ValidarDto]
    [ProducesResponseType(typeof(UsuarioAutenticadoDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(RetornoBaseDto), StatusCodes.Status500InternalServerError)]
    [HttpPost("revalidar", Name = nameof(RevalidarAsync))]
    [AllowAnonymous]
    public async Task<IActionResult> RevalidarAsync([FromBody] RevalidarTokenDto request, 
        [FromServices] IRevalidarTokenUseCase useCase)
    {
        return Ok(await useCase.ExecutarAsync(request));
    }    
}