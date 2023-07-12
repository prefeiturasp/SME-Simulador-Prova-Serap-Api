using Microsoft.AspNetCore.Mvc;
using SME.Simulador.Prova.Serap.Aplicacao;
using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.Api.Controllers;

[ApiController]
[Route("/simulador/api/v1/[controller]")]
public class FileController : ControllerBase
{
    [ValidarDto]
    [ProducesResponseType(typeof(ResponseUploadArquivoDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(RetornoBaseDto), StatusCodes.Status500InternalServerError)]
    [HttpPost("upload", Name = nameof(UploadAsync))]
    public async Task<IActionResult> UploadAsync([FromBody] RequestUploadArquivoDto request, 
        [FromServices] IUploadFileUseCase useCase)
    {
        return Ok(await useCase.ExecutarAsync(request));
    }
}