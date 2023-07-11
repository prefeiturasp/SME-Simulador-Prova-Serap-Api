using System.Text;
using MediatR;
using Newtonsoft.Json;
using SME.Simulador.Prova.Serap.Dominio;
using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class UploadFileCommandHandler : IRequestHandler<UploadFileCommand, ResponseUploadArquivoDto>
{
    private readonly IHttpClientFactory httpClientFactory;

    public UploadFileCommandHandler(IHttpClientFactory httpClientFactory)
    {
        this.httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
    }

    public async Task<ResponseUploadArquivoDto> Handle(UploadFileCommand request, CancellationToken cancellationToken)
    {
        var httpClientApiSerap = httpClientFactory.CreateClient(SerapConstants.ApiSerap);
        var parametros = JsonConvert.SerializeObject(request.UploadArquivo);

        var resposta = await httpClientApiSerap.PostAsync("SimuladorSerapEstudantes/File/Upload",
            new StringContent(parametros, Encoding.UTF8, "application/json"), cancellationToken);

        try
        {
            resposta.EnsureSuccessStatusCode();

            return JsonConvert.DeserializeObject<ResponseUploadArquivoDto>(
                await resposta.Content.ReadAsStringAsync(cancellationToken)) ?? new ResponseUploadArquivoDto
            {
                FileLink = string.Empty,
                IdFile = 0,
                Message = "Falha ao realizar o upload do arquivo.",
                Success = false,
                Type = string.Empty
            };
        }
        catch (Exception e)
        {
            throw new ErroException($"Erro ao realizar o upload do arquivo: {e.Message}");
        }
    }
}