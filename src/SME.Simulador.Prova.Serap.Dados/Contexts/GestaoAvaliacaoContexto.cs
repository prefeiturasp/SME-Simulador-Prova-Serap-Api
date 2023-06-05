using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using SME.Simulador.Prova.Serap.Dominio;

namespace SME.Simulador.Prova.Serap.Dados;

public sealed class GestaoAvaliacaoContexto : ContextoBase
{
    private GestaoAvaliacaoContexto(IDbConnection conexao) : base(conexao)
    {
    }

    private GestaoAvaliacaoContexto(string connectionStringGestaoAvalizacao) : this(
        new SqlConnection(connectionStringGestaoAvalizacao))
    {
        if (string.IsNullOrEmpty(connectionStringGestaoAvalizacao))
        {
            throw new ArgumentNullException(nameof(connectionStringGestaoAvalizacao),
                "A 'string' de conexão para o banco de 'GestaoAvaliacao' deve ser informada.");
        }
    }

    public GestaoAvaliacaoContexto(IOptions<ConnectionStringsOptions> connectionStringsOptions) : this(
        connectionStringsOptions.Value.GestaoAvaliacao)
    {
        Conexao.Open();
    }
}