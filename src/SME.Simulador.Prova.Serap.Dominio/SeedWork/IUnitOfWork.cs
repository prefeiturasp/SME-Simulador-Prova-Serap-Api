namespace SME.Simulador.Prova.Serap.Dominio;

public interface IUnitOfWork : IDisposable
{
    void BeginTransaction();
    void Commit();
    void Rollback();        
}