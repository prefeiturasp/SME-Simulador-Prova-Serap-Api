using System.Data;

namespace SME.Simulador.Prova.Serap.Dados;

public abstract class ContextoBase : IDisposable
{
    protected ContextoBase(IDbConnection conexao)
    {
        Conexao = conexao ?? throw new ArgumentNullException(nameof(conexao));
    }

    public IDbConnection Conexao { get; }
    
    public IDbTransaction? Transacao { get; set; }

    public void Dispose()
    {
        Conexao.Dispose();
        GC.SuppressFinalize(this);        
    }
}