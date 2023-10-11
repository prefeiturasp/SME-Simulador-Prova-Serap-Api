﻿namespace SME.Simulador.Prova.Serap.Infra;

public interface IServicoTelemetria
{
    Task<dynamic?> RegistrarComRetornoAsync<T>(Func<Task<object?>> acao, string acaoNome, string telemetriaNome, string telemetriaValor);
    dynamic RegistrarComRetorno<T>(Func<object> acao, string acaoNome, string telemetriaNome, string telemetriaValor);
    void Registrar(Action acao, string acaoNome, string telemetriaNome, string telemetriaValor);
    Task RegistrarAsync(Func<Task> acao, string acaoNome, string telemetriaNome, string telemetriaValor);    
}