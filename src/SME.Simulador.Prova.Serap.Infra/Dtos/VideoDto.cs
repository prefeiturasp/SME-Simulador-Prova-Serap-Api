namespace SME.Simulador.Prova.Serap.Infra;

public class VideoDto : DtoBase
{
    public long VideoId { get; set; }
    public string CaminhoVideo { get; set; } = string.Empty;
    public long ThumbnailVideoId { get; set; }
    public string CaminhoThumbnailVideo { get; set; } = string.Empty;
    public long VideoConvertidoId { get; set; }
    public string CaminhoVideoConvertido { get; set; } = string.Empty;
}