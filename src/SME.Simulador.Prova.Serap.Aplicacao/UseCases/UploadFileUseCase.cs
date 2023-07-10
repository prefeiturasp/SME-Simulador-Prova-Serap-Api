using MediatR;
using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class UploadFileUseCase : AbstractUseCase, IUploadFileUseCase
{
    public UploadFileUseCase(IMediator mediator) : base(mediator)
    {
    }    
    
    public async Task<ResponseUploadArquivoDto> ExecutarAsync(RequestUploadArquivoDto request)
    {
        return await mediator.Send(new UploadFileCommand(request));
    }
}