using MessagePack;
using SME.Simulador.Prova.Serap.Infra;
using StackExchange.Redis;

namespace SME.Simulador.Prova.Serap.Dados;

public class RepositorioCache : IRepositorioCache
{
    private readonly IDatabase database;
    private readonly IServicoLog servicoLog;

    public RepositorioCache(IConnectionMultiplexer connectionMultiplexer, IServicoLog servicoLog)
    {
        if (connectionMultiplexer == null)
            throw new ArgumentNullException(nameof(connectionMultiplexer));
        
        this.servicoLog = servicoLog ?? throw new ArgumentNullException(nameof(servicoLog));

        database = connectionMultiplexer.GetDatabase();
    }

    public async Task SalvarRedisAsync(string nomeChave, object valor, int minutosParaExpirar = 720)
    {
        try
        {
            await database.StringSetAsync(nomeChave, MessagePackSerializer.Serialize(valor),
                TimeSpan.FromMinutes(minutosParaExpirar));
        }
        catch (Exception e)
        {
            servicoLog.Registrar(e);
        }
    }

    public async Task RemoverRedisAsync(string nomeChave)
    {
        try
        {
            await database.KeyDeleteAsync(nomeChave);
        }
        catch (Exception e)
        {
            servicoLog.Registrar(e);
        }
    }

    public async Task<T> ObterRedisAsync<T>(string nomeChave, Func<Task<T>> buscarDados, int minutosParaExpirar = 720)
    {
        try
        {
            byte[]? byteCache = await database.StringGetAsync(nomeChave);

            if (byteCache != null)
                return MessagePackSerializer.Deserialize<T>(byteCache);                

            var dados = await buscarDados();
        
            if (dados != null)
                await SalvarRedisAsync(nomeChave, dados, minutosParaExpirar);

            return dados;
        }
        catch (Exception e)
        {
            servicoLog.Registrar(e);
            return await buscarDados();
        }
    }

    public async Task<T?> ObterRedisAsync<T>(string nomeChave)
    {
        try
        {
            byte[]? byteCache = await database.StringGetAsync(nomeChave);
            return byteCache != null ? MessagePackSerializer.Deserialize<T>(byteCache) : default;
        }
        catch (Exception e)
        {
            servicoLog.Registrar(e);
        }

        return default;
    }

    public async Task<bool> ExisteChaveAsync(string nomeChave)
    {
        try
        {
            return await database.KeyExistsAsync(nomeChave);
        }
        catch (Exception e)
        {
            servicoLog.Registrar(e);
        }

        return false;
    }

    public async Task<string> ObterRedisToJsonAsync(string nomeChave, Func<Task<string>> buscarDados,
        int minutosParaExpirar = 720)
    {
        try
        {
            byte[]? byteCache = await database.StringGetAsync(nomeChave);

            if (byteCache != null)
                return MessagePackSerializer.ConvertToJson(byteCache);

            var dados = await buscarDados();

            await SalvarRedisToJsonAsync(nomeChave, dados, minutosParaExpirar);

            return dados;
        }
        catch (Exception e)
        {
            servicoLog.Registrar(e);
            return await buscarDados();
        }
    }

    public async Task<string> ObterRedisToJsonAsync(string nomeChave)
    {
        try
        {
            byte[]? byteCache = await database.StringGetAsync(nomeChave);
            return byteCache != null ? MessagePackSerializer.ConvertToJson(byteCache) : string.Empty;
        }
        catch (Exception e)
        {
            servicoLog.Registrar(e);
        }

        return string.Empty;
    }

    public async Task SalvarRedisToJsonAsync(string nomeChave, string json, int minutosParaExpirar = 720)
    {
        if (string.IsNullOrEmpty(json))
            return;

        try
        {
            var bytes = MessagePackSerializer.ConvertFromJson(json);
            await database.StringSetAsync(nomeChave, bytes, TimeSpan.FromMinutes(minutosParaExpirar));
        }
        catch (Exception e)
        {
            servicoLog.Registrar(e);
        }
    }
}