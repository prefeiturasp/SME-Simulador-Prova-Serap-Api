using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.Dados;

public class RepositorioArquivo : IRepositorioArquivo
{
    private readonly GestaoAvaliacaoContexto gestaoAvaliacaoContexto;

    public RepositorioArquivo(GestaoAvaliacaoContexto gestaoAvaliacaoContexto)
    {
        this.gestaoAvaliacaoContexto = gestaoAvaliacaoContexto ?? throw new ArgumentNullException(nameof(gestaoAvaliacaoContexto));
    }

    public async Task<IEnumerable<ArquivoDto>> ObterAudiosPorQuestaoId(long questaoId)
    {
        const string query = @"select f.[Path] Caminho, f.Id
                                from Item i WITH (NOLOCK)
                                    inner join ItemAudio ia WITH (NOLOCK) on i.Id = ia.Item_id and i.[State] = ia.[State]
                                    inner join [File] f WITH (NOLOCK) on f.Id = ia.[File_Id] and f.[State] = ia.[State]
                                where i.[State] = 1
                                    and i.Id = @questaoId;";

        return await gestaoAvaliacaoContexto.Conexao.QueryAsync<ArquivoDto>(query, new { questaoId },
            transaction: gestaoAvaliacaoContexto.Transacao);
    }

    public async Task<IEnumerable<VideoDto>> ObterVideosPorQuestaoId(long questaoId)
    {
        const string query = @"SELECT  
                                    F.Id AS VideoId, 
                                    F.[Path] CaminhoVideo,  
                                    isnull(FT.Id,0) AS ThumbnailVideoId, 
                                    FT.[Path] AS CaminhoThumbnailVideo, 
                                    isnull(FC.Id, 0) AS VideoConvertidoId,
                                    FC.[Path] AS CaminhoVideoConvertido
                                FROM ItemFile IFI WITH (NOLOCK)
                                    INNER JOIN [File] F WITH (NOLOCK) ON F.Id = IFI.File_Id
                                    INNER JOIN [File] FT WITH (NOLOCK) ON FT.Id = IFI.Thumbnail_Id
                                    LEFT JOIN [File] FC (NOLOCK) ON IFI.ConvertedFile_Id = FC.Id
                                WHERE IFI.State = 1 
                                AND IFI.Item_Id = @questaoId;";

        return await gestaoAvaliacaoContexto.Conexao.QueryAsync<VideoDto>(query, new { questaoId },
            transaction: gestaoAvaliacaoContexto.Transacao);
    }
}