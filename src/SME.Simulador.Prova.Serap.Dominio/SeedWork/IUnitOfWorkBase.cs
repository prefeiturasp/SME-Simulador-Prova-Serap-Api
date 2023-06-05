namespace SME.Simulador.Prova.Serap.Dominio;

public interface IUnitOfWorkBase : IDisposable
{
    void BeginTransaction();
    void Commit();
    void Rollback();        
}