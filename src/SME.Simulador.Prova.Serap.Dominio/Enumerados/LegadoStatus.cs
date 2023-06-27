using System.ComponentModel;

namespace SME.Simulador.Prova.Serap.Dominio;

public enum LegadoStatus
{
    [Description("Não definido")]
    NaoDefinido = 0,
    [Description("Ativo")]
    Ativo = 1,
    [Description("Inativo")]
    Inativo = 2,
    [Description("Excluído")]
    Excluido = 3    
}