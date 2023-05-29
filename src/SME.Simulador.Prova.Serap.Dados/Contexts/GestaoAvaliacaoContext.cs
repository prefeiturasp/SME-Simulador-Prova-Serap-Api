using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using SME.Simulador.Prova.Serap.Dominio;

namespace SME.Simulador.Prova.Serap.Dados;

public class GestaoAvaliacaoContext : IDisposable
{
    public GestaoAvaliacaoContext(IOptions<ConnectionStringsOptions> connectionStringsOptions)
    {
        var connectionStringGestaoAvalizacao = connectionStringsOptions.Value.GestaoAvaliacao;

        if (string.IsNullOrEmpty(connectionStringGestaoAvalizacao))
            throw new ArgumentNullException(nameof(connectionStringGestaoAvalizacao),
                "A 'string' de conexão para o banco de GestaoAvaliacao deve ser informada.");
        
        Conexao = new SqlConnection(connectionStringGestaoAvalizacao);
        Conexao.Open();
    }

    public IDbConnection Conexao { get; }
    public IDbTransaction? Transacao { get; set; }

    public void Dispose()
    {
        Conexao.Dispose();
        GC.SuppressFinalize(this);
    }
}