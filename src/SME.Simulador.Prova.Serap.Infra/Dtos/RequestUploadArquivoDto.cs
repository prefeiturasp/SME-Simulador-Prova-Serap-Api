using SME.Simulador.Prova.Serap.Dominio;

namespace SME.Simulador.Prova.Serap.Infra;

public class RequestUploadArquivoDto : DtoBase
{
    public int ContentLength { get; set; }
    public string ContentType { get; set; } = string.Empty;
    public string FileName { get; set; } = string.Empty;
    public string InputStream { get; set; } = string.Empty;
    public FileType FileType { get; set; }    
}