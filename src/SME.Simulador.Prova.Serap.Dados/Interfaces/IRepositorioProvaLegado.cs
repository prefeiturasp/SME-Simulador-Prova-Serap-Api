namespace SME.Simulador.Prova.Serap.Dados;

public interface IRepositorioProvaLegado
{
    Task<bool> EhProvaIniciada(long provaId);    
}