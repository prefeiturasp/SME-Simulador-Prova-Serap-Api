using SME.Simulador.Prova.Serap.Dominio;

namespace SME.Simulador.Prova.Serap.Dados;

public class RepositorioQuestaoArquivo : RepositorioGestaoAvaliacaoBase<QuestaoArquivo>, IRepositorioQuestaoArquivo
{
    private readonly GestaoAvaliacaoContexto gestaoAvaliacaoContexto;

    public RepositorioQuestaoArquivo(GestaoAvaliacaoContexto gestaoAvaliacaoContexto) : base(gestaoAvaliacaoContexto)
    {
        this.gestaoAvaliacaoContexto = gestaoAvaliacaoContexto ?? throw new ArgumentNullException(nameof(gestaoAvaliacaoContexto));
    }

    public async Task<IEnumerable<QuestaoArquivo>> ObterListaQuestaoArquivos(long questaoId)
    {
        const string query = @"SELECT  [Id]
                                           ,[Thumbnail_Id] as ThumbnailId
                                           ,[CreateDate] as DataCriacao
                                           ,[UpdateDate] as DataAtualizacao
                                           ,[State] as Situacao
                                           ,[File_Id] as ArquivoId 
                                           ,[Item_Id] as   QuestaoId
                                           ,[ConvertedFile_Id] as ArquivoConvertidoId
                              FROM [GestaoAvaliacao].[dbo].[ItemFile]
                                     WHERE Item_id = @questaoId
                                       AND State = @state";

        return await gestaoAvaliacaoContexto.Conexao.QueryAsync<QuestaoArquivo>(query,
            new
            {
                questaoId,
                state = (int)LegadoState.Ativo
            }, transaction: gestaoAvaliacaoContexto.Transacao);
    }
}