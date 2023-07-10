using System.Text;
using MediatR;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SME.Simulador.Prova.Serap.Dominio;
using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class UploadFileCommandHandler : IRequestHandler<UploadFileCommand, ResponseUploadArquivoDto>
{
    private readonly IHttpClientFactory httpClientFactory;
    private readonly ClientApiOptions clientApiOptions;

    public UploadFileCommandHandler(IHttpClientFactory httpClientFactory, IOptions<ClientApiOptions> clientApiOptions)
    {
        this.httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        this.clientApiOptions = clientApiOptions.Value ?? throw new ArgumentNullException(nameof(clientApiOptions));
    }

    public async Task<ResponseUploadArquivoDto> Handle(UploadFileCommand request, CancellationToken cancellationToken)
    {
        var httpClient = httpClientFactory.CreateClient(SerapConstants.ApiSerap);
        var parametros = JsonConvert.SerializeObject(request.UploadArquivo);

        var resposta = await httpClient.PostAsync("SimuladorSerapEstudantes/File/Upload",
            new StringContent(parametros, Encoding.UTF8, "application/json"), cancellationToken);

        try
        {
            resposta.EnsureSuccessStatusCode();

            return JsonConvert.DeserializeObject<ResponseUploadArquivoDto>(
                await resposta.Content.ReadAsStringAsync(cancellationToken)) ?? new ResponseUploadArquivoDto
            {
                FileLink = string.Empty,
                IdFile = 0,
                Message = "Falha ao realizar o upload do arquivo",
                Success = false,
                Type = string.Empty
            };
        }
        catch (Exception e)
        {
            throw new ErroException($"Falha ao realizar o upload do arquivo: {e.Message}");
        }
    }
}