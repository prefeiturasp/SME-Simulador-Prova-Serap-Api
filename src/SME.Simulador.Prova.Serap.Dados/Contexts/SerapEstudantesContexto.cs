using System.Data;
using Microsoft.Extensions.Options;
using Npgsql;
using SME.Simulador.Prova.Serap.Dominio;

namespace SME.Simulador.Prova.Serap.Dados;

public sealed class SerapEstudantesContexto : ContextoBase
{
    private SerapEstudantesContexto(IDbConnection conexao) : base(conexao)
    {
    }

    private SerapEstudantesContexto(string connectionStringSerapEstudantes) : this(
        new NpgsqlConnection(connectionStringSerapEstudantes))
    {
        if (string.IsNullOrEmpty(connectionStringSerapEstudantes))
        {
            throw new ArgumentNullException(nameof(connectionStringSerapEstudantes),
                "A 'string' de conexão para o banco de 'serap_estudantes' deve ser informada.");
        }        
    }

    public SerapEstudantesContexto(IOptions<ConnectionStringsOptions> connectionStringsOptions) : this(
        connectionStringsOptions.Value.SerapEstudantes)
    {
        Conexao.Open();
    }
}