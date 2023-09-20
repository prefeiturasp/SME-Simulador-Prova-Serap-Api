namespace SME.Simulador.Prova.Serap.Dominio;

public class Questao : EntidadeBase
{
    public string CodigoItem { get; set; } = string.Empty;
    public int VersaoItem { get; set; }
    public string? Enunciado { get; set; } 
    public string? PalavrasChaves { get; set; }
    public string? Tips { get; set; }
    public decimal? TRIDiscrimination { get; set; } 
    public decimal? TRIDifficulty { get; set; } 
    public decimal? TRICasualSetting { get; set; } 
    public DateTime DataCriacao { get; set; } 
    public DateTime DataAtualizacao { get; set; } 
    public int Situacao { get; set; } 
    public long TextoBaseId { get; set; }
    public int MatrizId { get; set; } 
    public int? LevelItemId { get; set; } 
    public int SituacaoItemId { get; set; } 
    public int TipoItem { get; set; }
    public int? Proeficiencia { get; set; }
    public string? DescriptorSentence { get; set; } 
    public bool? UltimaVersao { get; set; } 
    public bool? EhRestrito { get; set; } 
    public bool? ItemNarrado { get; set; } 
    public bool? DeclaracaoAluno { get; set; }
    public bool? NarracaoDeclaracaoAluno { get; set; } 
    public bool? NarracaoAlternativas { get; set; }  
    public bool? Revogado { get; set; } 
    public int VersaoCodigoQuestao { get; set; }
    public int? AreaConhecimentoId { get; set; } 
    public int? SubAssunto { get; set; }
}