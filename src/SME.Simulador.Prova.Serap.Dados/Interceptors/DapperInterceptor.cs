using Dapper;
using System.Data;
using SME.Simulador.Prova.Serap.Infra;
using static Dapper.SqlMapper;

namespace SME.Simulador.Prova.Serap.Dados;

public static class DapperInterceptor
{
    private static IServicoTelemetria? servicoTelemetria;
    private const string ServicoTelemetriaNaoDeveSerNulo = "O serviço de telemetria não deve ser nulo.";

    public static void Init(IServicoTelemetria? telemetria)
    {
        servicoTelemetria = telemetria ?? throw new ArgumentNullException(nameof(telemetria));
    }

    public static IEnumerable<T> Query<T>(this IDbConnection connection, string sql, object? param = null,
        IDbTransaction? transaction = null, bool buffered = true, int? commandTimeout = null,
        CommandType? commandType = null, string queryName = "")
    {
        if (servicoTelemetria == null)
            throw new ArgumentNullException(nameof(servicoTelemetria), ServicoTelemetriaNaoDeveSerNulo);
        
        var result = servicoTelemetria.RegistrarComRetorno<T>(
            () => SqlMapper.Query<T>(connection, sql, param, transaction, buffered, commandTimeout, commandType),
            "MSSql", $"Query {queryName}", sql);

        return result;
    }

    public static async Task<IEnumerable<T>> QueryAsync<T>(this IDbConnection cnn, string sql, object? param = null,
        IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null,
        string queryName = "")
    {
        if (servicoTelemetria == null)
            throw new ArgumentNullException(nameof(servicoTelemetria), ServicoTelemetriaNaoDeveSerNulo);

        var result = await servicoTelemetria.RegistrarComRetornoAsync<T>(
            async () => await SqlMapper.QueryAsync<T>(cnn, sql, param, transaction, commandTimeout, commandType),
            "MSSql", $"Query {queryName}", sql);

        return result;
    }

    public static async Task<T> QueryFirstOrDefaultAsync<T>(this IDbConnection cnn, string sql, object? param = null,
        IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null,
        string queryName = "Query MSSql")
    {
        if (servicoTelemetria == null)
            throw new ArgumentNullException(nameof(servicoTelemetria), ServicoTelemetriaNaoDeveSerNulo);
        
        var result = await servicoTelemetria.RegistrarComRetornoAsync<T>(
            async () => await SqlMapper.QueryFirstOrDefaultAsync<T>(cnn, sql, param, transaction, commandTimeout,
                commandType) ?? throw new InvalidOperationException(), "MSSql", $"Query {queryName}", sql);

        return result;
    }

    public static IEnumerable<TReturn> Query<TFirst, TSecond, TReturn>(this IDbConnection cnn, string sql,
        Func<TFirst, TSecond, TReturn> map, object? param = null, IDbTransaction? transaction = null,
        bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null,
        string queryName = "Query MSSql")
    {
        if (servicoTelemetria == null)
            throw new ArgumentNullException(nameof(servicoTelemetria), ServicoTelemetriaNaoDeveSerNulo);
        
        var result = servicoTelemetria.RegistrarComRetorno<TReturn>(
            () => SqlMapper.Query(cnn, sql, map, param, transaction, buffered, splitOn, commandTimeout, commandType),
            "MSSql", $"Query {queryName}", sql);

        return result;
    }

    public static IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TReturn>(this IDbConnection cnn, string sql,
        Func<TFirst, TSecond, TThird, TReturn> map, object? param = null, IDbTransaction? transaction = null,
        bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null,
        string queryName = "Query MSSql")
    {
        if (servicoTelemetria == null)
            throw new ArgumentNullException(nameof(servicoTelemetria), ServicoTelemetriaNaoDeveSerNulo);
        
        var result = servicoTelemetria.RegistrarComRetorno<TReturn>(
            () => SqlMapper.Query(cnn, sql, map, param, transaction, buffered, splitOn, commandTimeout, commandType),
            "MSSql", $"Query {queryName}", sql);

        return result;
    }

    public static IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TReturn>(this IDbConnection cnn,
        string sql, Func<TFirst, TSecond, TThird, TFourth, TReturn> map, object? param = null,
        IDbTransaction? transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null,
        CommandType? commandType = null, string queryName = "Query MSSql")
    {
        if (servicoTelemetria == null)
            throw new ArgumentNullException(nameof(servicoTelemetria), ServicoTelemetriaNaoDeveSerNulo);        
        
        var result = servicoTelemetria.RegistrarComRetorno<TReturn>(
            () => SqlMapper.Query(cnn, sql, map, param, transaction, buffered, splitOn, commandTimeout, commandType),
            "MSSql", $"Query {queryName}", sql);

        return result;
    }

    public static IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(this IDbConnection cnn,
        string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TReturn> map, object? param = null,
        IDbTransaction? transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null,
        CommandType? commandType = null, string queryName = "Query MSSql")
    {
        if (servicoTelemetria == null)
            throw new ArgumentNullException(nameof(servicoTelemetria), ServicoTelemetriaNaoDeveSerNulo);        
        
        var result = servicoTelemetria.RegistrarComRetorno<TReturn>(
            () => SqlMapper.Query(cnn, sql, map, param, transaction, buffered, splitOn, commandTimeout, commandType),
            "MSSql", $"Query {queryName}", sql);

        return result;
    }

    public static IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(
        this IDbConnection cnn, string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn> map,
        object? param = null, IDbTransaction? transaction = null, bool buffered = true, string splitOn = "Id",
        int? commandTimeout = null, CommandType? commandType = null, string queryName = "Query MSSql")
    {
        if (servicoTelemetria == null)
            throw new ArgumentNullException(nameof(servicoTelemetria), ServicoTelemetriaNaoDeveSerNulo);        
        
        var result = servicoTelemetria.RegistrarComRetorno<TReturn>(
            () => SqlMapper.Query(cnn, sql, map, param, transaction, buffered, splitOn, commandTimeout, commandType),
            "MSSql", $"Query {queryName}", sql);

        return result;
    }

    public static IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(
        this IDbConnection cnn, string sql,
        Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn> map, object? param = null,
        IDbTransaction? transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null,
        CommandType? commandType = null, string queryName = "Query MSSql")
    {
        if (servicoTelemetria == null)
            throw new ArgumentNullException(nameof(servicoTelemetria), ServicoTelemetriaNaoDeveSerNulo);        
        
        var result = servicoTelemetria.RegistrarComRetorno<TReturn>(
            () => SqlMapper.Query(cnn, sql, map, param, transaction, buffered, splitOn, commandTimeout, commandType),
            "MSSql", $"Query {queryName}", sql);

        return result;
    }

    public static async Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TReturn>(this IDbConnection cnn,
        string sql, Func<TFirst, TSecond, TReturn> map, object? param = null, IDbTransaction? transaction = null,
        bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null,
        string queryName = "Query MSSql")
    {
        if (servicoTelemetria == null)
            throw new ArgumentNullException(nameof(servicoTelemetria), ServicoTelemetriaNaoDeveSerNulo);        
        
        var result = await servicoTelemetria.RegistrarComRetornoAsync<TReturn>(
            async () => await SqlMapper.QueryAsync(cnn, sql, map, param, transaction, buffered, splitOn, commandTimeout,
                commandType), "MSSql", $"Query {queryName}", sql);

        return result;
    }

    public static async Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TReturn>(this IDbConnection cnn,
        string sql, Func<TFirst, TSecond, TThird, TReturn> map, object? param = null, IDbTransaction? transaction = null,
        bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null,
        string queryName = "Query MSSql")
    {
        if (servicoTelemetria == null)
            throw new ArgumentNullException(nameof(servicoTelemetria), ServicoTelemetriaNaoDeveSerNulo);        
        
        var result = await servicoTelemetria.RegistrarComRetornoAsync<TReturn>(
            async () => await SqlMapper.QueryAsync(cnn, sql, map, param, transaction, buffered, splitOn, commandTimeout,
                commandType), "MSSql", $"Query {queryName}", sql);

        return result;
    }

    public static async Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TReturn>(
        this IDbConnection cnn, string sql, Func<TFirst, TSecond, TThird, TFourth, TReturn> map, object? param = null,
        IDbTransaction? transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null,
        CommandType? commandType = null, string queryName = "Query MSSql")
    {
        if (servicoTelemetria == null)
            throw new ArgumentNullException(nameof(servicoTelemetria), ServicoTelemetriaNaoDeveSerNulo);        
        
        var result = await servicoTelemetria.RegistrarComRetornoAsync<TReturn>(
            async () => await SqlMapper.QueryAsync(cnn, sql, map, param, transaction, buffered, splitOn, commandTimeout,
                commandType), "MSSql", $"Query {queryName}", sql);

        return result;
    }

    public static async Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(
        this IDbConnection cnn, string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TReturn> map,
        object? param = null, IDbTransaction? transaction = null, bool buffered = true, string splitOn = "Id",
        int? commandTimeout = null, CommandType? commandType = null, string queryName = "Query MSSql")
    {
        if (servicoTelemetria == null)
            throw new ArgumentNullException(nameof(servicoTelemetria), ServicoTelemetriaNaoDeveSerNulo);        
        
        var result = await servicoTelemetria.RegistrarComRetornoAsync<TReturn>(
            async () => await SqlMapper.QueryAsync(cnn, sql, map, param, transaction, buffered, splitOn, commandTimeout,
                commandType), "MSSql", $"Query {queryName}", sql);

        return result;
    }

    public static async Task<IEnumerable<TReturn>>
        QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(this IDbConnection cnn, string sql,
            Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn> map, object? param = null,
            IDbTransaction? transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null,
            CommandType? commandType = null, string queryName = "Query MSSql")
    {
        if (servicoTelemetria == null)
            throw new ArgumentNullException(nameof(servicoTelemetria), ServicoTelemetriaNaoDeveSerNulo);        
        
        var result = await servicoTelemetria.RegistrarComRetornoAsync<TReturn>(
            async () => await SqlMapper.QueryAsync(cnn, sql, map, param, transaction, buffered, splitOn, commandTimeout,
                commandType), "MSSql", $"Query {queryName}", sql);

        return result;
    }

    public static async Task<IEnumerable<TReturn>>
        QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(this IDbConnection cnn,
            string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn> map,
            object? param = null, IDbTransaction? transaction = null, bool buffered = true, string splitOn = "Id",
            int? commandTimeout = null, CommandType? commandType = null, string queryName = "Query MSSql")
    {
        if (servicoTelemetria == null)
            throw new ArgumentNullException(nameof(servicoTelemetria), ServicoTelemetriaNaoDeveSerNulo);        
        
        var result = await servicoTelemetria.RegistrarComRetornoAsync<TReturn>(
            async () => await SqlMapper.QueryAsync(cnn, sql, map, param, transaction, buffered, splitOn, commandTimeout,
                commandType), "MSSql", $"Query {queryName}", sql);

        return result;
    }

    public static async Task<GridReader> QueryMultipleAsync(this IDbConnection cnn, string sql, object? param = null,
        IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null,
        string queryName = "QueryMultiple MSSql")
    {
        if (servicoTelemetria == null)
            throw new ArgumentNullException(nameof(servicoTelemetria), ServicoTelemetriaNaoDeveSerNulo);        
        
        var result = await servicoTelemetria.RegistrarComRetornoAsync<GridReader>(
            async () => await SqlMapper.QueryMultipleAsync(cnn, sql, param, transaction, commandTimeout, commandType),
            "MSSql", $"Query {queryName}", sql);
        
        return result;
    }

    public static int Execute(this IDbConnection cnn, string sql, object? param = null,
        IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null,
        string queryName = "Command MSSql")
    {
        if (servicoTelemetria == null)
            throw new ArgumentNullException(nameof(servicoTelemetria), ServicoTelemetriaNaoDeveSerNulo);
        
        var result = servicoTelemetria.RegistrarComRetorno<int>(
            () => SqlMapper.Execute(cnn, sql, param, transaction, commandTimeout, commandType), "MSSql",
            $"Command {queryName}", sql);

        return result;
    }

    public static int Execute(this IDbConnection cnn, CommandDefinition command, string queryName = "Command MSSql")
    {
        if (servicoTelemetria == null)
            throw new ArgumentNullException(nameof(servicoTelemetria), ServicoTelemetriaNaoDeveSerNulo);
        
        var result = servicoTelemetria.RegistrarComRetorno<int>(() => SqlMapper.Execute(cnn, command), "MSSql",
            $"Command {queryName}", command.ToString() ?? string.Empty);

        return result;
    }

    #region Repositório Base

    public static IEnumerable<TEntity> GetAll<TEntity>(this IDbConnection connection, bool buffered = true)
        where TEntity : class
    {
        if (servicoTelemetria == null)
            throw new ArgumentNullException(nameof(servicoTelemetria), ServicoTelemetriaNaoDeveSerNulo);
        
        var result = servicoTelemetria.RegistrarComRetorno<TEntity>(
            () => Dommel.DommelMapper.GetAll<TEntity>(connection, buffered: buffered), "MSSql",
            $"GetAll Entidade {typeof(TEntity).Name}", "GetAll");
        return result;
    }

    public static object Insert<TEntity>(this IDbConnection connection, TEntity entity,
        IDbTransaction? transaction = null) where TEntity : class
    {
        if (servicoTelemetria == null)
            throw new ArgumentNullException(nameof(servicoTelemetria), ServicoTelemetriaNaoDeveSerNulo);
        
        var entidade = entity.GetType().Name;

        var result = servicoTelemetria.RegistrarComRetorno<TEntity>(
            () => Dommel.DommelMapper.Insert(connection, entity, transaction), "MSSql",
            $"Insert Entidade {entidade}", "Insert");

        return result;
    }

    public static bool Update<TEntity>(this IDbConnection connection, TEntity entity,
        IDbTransaction? transaction = null)
    {
        if (servicoTelemetria == null)
            throw new ArgumentNullException(nameof(servicoTelemetria), ServicoTelemetriaNaoDeveSerNulo);
        
        var entidade = entity?.GetType().Name;

        var result = servicoTelemetria.RegistrarComRetorno<TEntity>(
            () => Dommel.DommelMapper.Update(connection, entity, transaction), "MSSql",
            $"Update Entidade {entidade}", "Insert");

        return result;
    }

    public static TEntity Get<TEntity>(this IDbConnection connection, object id) where TEntity : class
    {
        if (servicoTelemetria == null)
            throw new ArgumentNullException(nameof(servicoTelemetria), ServicoTelemetriaNaoDeveSerNulo);

        var result = servicoTelemetria.RegistrarComRetorno<TEntity>(
            () => Dommel.DommelMapper.Get<TEntity>(connection, id), "MSSql", $"Get Entidade {typeof(TEntity).Name}",
            "Get");

        return result;
    }

    public static bool Delete<TEntity>(this IDbConnection connection, TEntity entity,
        IDbTransaction? transaction = null,
        string queryName = "Command MSSql")
    {
        if (servicoTelemetria == null)
            throw new ArgumentNullException(nameof(servicoTelemetria), ServicoTelemetriaNaoDeveSerNulo);

        var result = servicoTelemetria.RegistrarComRetorno<TEntity>(
            () => Dommel.DommelMapper.Delete(connection, entity, transaction), "MSSql",
            queryName, "Delete");

        return result;
    }

    public static async Task<TEntity> GetAsync<TEntity>(this IDbConnection connection, object id, IDbTransaction? transacao = null)
        where TEntity : class
    {
        if (servicoTelemetria == null)
            throw new ArgumentNullException(nameof(servicoTelemetria), ServicoTelemetriaNaoDeveSerNulo);

        var result = await servicoTelemetria.RegistrarComRetornoAsync<TEntity>(
            async () => await Dommel.DommelMapper.GetAsync<TEntity>(connection, id, transaction: transacao), "MSSql",
            $"GetAsync Entidade {typeof(TEntity).Name}", "GetAsync");

        return result;
    }

    public static async Task<bool> UpdateAsync<TEntity>(this IDbConnection connection, TEntity entity,
        IDbTransaction? transaction = null)
    {
        if (servicoTelemetria == null)
            throw new ArgumentNullException(nameof(servicoTelemetria), ServicoTelemetriaNaoDeveSerNulo);
        
        var entidade = entity?.GetType().Name;

        var result = await servicoTelemetria.RegistrarComRetornoAsync<TEntity>(
            async () => await Dommel.DommelMapper.UpdateAsync(connection, entity, transaction: transaction), "MSSql",
            $"UpdateAsync Entidade {entidade}", "UpdateAsync");

        return result;
    }

    public static async Task<object> InsertAsync<TEntity>(this IDbConnection connection, TEntity entity,
        IDbTransaction? transaction = null) where TEntity : class
    {
        if (servicoTelemetria == null)
            throw new ArgumentNullException(nameof(servicoTelemetria), ServicoTelemetriaNaoDeveSerNulo);

        var entidade = entity.GetType().Name;

        var result = await servicoTelemetria.RegistrarComRetornoAsync<TEntity>(
            async () => await Dommel.DommelMapper.InsertAsync(connection, entity, transaction: transaction), "MSSql",
            $"UpdateAsync Entidade {entidade}", "UpdateAsync");

        return result;
    }

    #endregion
}

  