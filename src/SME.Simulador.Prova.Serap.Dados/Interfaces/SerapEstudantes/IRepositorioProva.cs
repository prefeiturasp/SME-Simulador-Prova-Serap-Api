namespace SME.Simulador.Prova.Serap.Dados;

public interface IRepositorioProva
{
    Task<bool> EhProvaIniciada(long provaLegadoId);
}