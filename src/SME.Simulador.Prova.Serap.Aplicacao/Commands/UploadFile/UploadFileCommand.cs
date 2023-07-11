using MediatR;
using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class UploadFileCommand : IRequest<ResponseUploadArquivoDto>
{
    public UploadFileCommand(RequestUploadArquivoDto uploadArquivo)
    {
        UploadArquivo = uploadArquivo;
    }

    public RequestUploadArquivoDto UploadArquivo { get; }
}