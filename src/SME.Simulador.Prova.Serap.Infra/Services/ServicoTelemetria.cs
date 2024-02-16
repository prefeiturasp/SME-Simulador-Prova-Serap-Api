using System.Diagnostics;
using Elastic.Apm;
using Microsoft.ApplicationInsights;
using Microsoft.Extensions.Options;
using SME.Simulador.Prova.Serap.Dominio;

namespace SME.Simulador.Prova.Serap.Infra;

public class ServicoTelemetria : IServicoTelemetria
{
    private readonly TelemetryClient telemetryClient;
    private readonly TelemetriaOptions telemetriaOptions;

    public ServicoTelemetria(TelemetryClient telemetryClient, IOptions<TelemetriaOptions> telemetriaOptions)
    {
        this.telemetryClient = telemetryClient ?? throw new ArgumentNullException(nameof(telemetryClient));
        this.telemetriaOptions = telemetriaOptions.Value ?? throw new ArgumentNullException(nameof(telemetriaOptions));
    }

    public async Task<dynamic?> RegistrarComRetornoAsync<T>(Func<Task<object?>> acao, string acaoNome, string telemetriaNome, string telemetriaValor)
    {
        DateTime inicioOperacao = default;
        Stopwatch? temporizador = default;
        dynamic? result;

        if (telemetriaOptions.ApplicationInsights)
        {
            inicioOperacao = DateTime.UtcNow;
            temporizador = Stopwatch.StartNew();
        }

        if (telemetriaOptions.Apm)
        {
            var temporizadorApm = Stopwatch.StartNew();
            
            result = await acao();
            temporizadorApm.Stop();

            Agent.Tracer.CurrentTransaction.CaptureSpan(telemetriaNome, acaoNome, span =>
            {
                span.SetLabel(telemetriaNome, telemetriaValor);
                span.Duration = temporizadorApm.Elapsed.TotalMilliseconds;
            });
        }
        else
        {
            result = await acao();
        }

        if (!telemetriaOptions.ApplicationInsights) 
            return result;

        if (temporizador == null) 
            return result;
        
        temporizador.Stop();

        telemetryClient.TrackDependency(acaoNome, telemetriaNome, telemetriaValor, inicioOperacao, temporizador.Elapsed,
            true);

        return result;
    }

    public dynamic RegistrarComRetorno<T>(Func<object> acao, string acaoNome, string telemetriaNome, string telemetriaValor)
    {
        DateTime inicioOperacao = default;
        Stopwatch? temporizador = default;
        dynamic result;

        if (telemetriaOptions.ApplicationInsights)
        {
            inicioOperacao = DateTime.UtcNow;
            temporizador = Stopwatch.StartNew();
        }

        if (telemetriaOptions.Apm)
        {
            var temporizadorApm = Stopwatch.StartNew();
            
            result = acao();
            temporizadorApm.Stop();

            Agent.Tracer.CurrentTransaction.CaptureSpan(telemetriaNome, acaoNome, span =>
            {
                span.SetLabel(telemetriaNome, telemetriaValor);
                span.Duration = temporizadorApm.Elapsed.TotalMilliseconds;
            });
        }
        else
        {
            result = acao();
        }

        if (!telemetriaOptions.ApplicationInsights) 
            return result;

        if (temporizador == null)
            return result;
        
        temporizador.Stop();
        telemetryClient.TrackDependency(acaoNome, telemetriaNome, telemetriaValor, inicioOperacao, temporizador.Elapsed,
            true);

        return result;
    }

    public void Registrar(Action acao, string acaoNome, string telemetriaNome, string telemetriaValor)
    {
        DateTime inicioOperacao = default;
        Stopwatch? temporizador = default;

        if (telemetriaOptions.ApplicationInsights)
        {
            inicioOperacao = DateTime.UtcNow;
            temporizador = Stopwatch.StartNew();
        }

        if (telemetriaOptions.Apm)
        {
            var temporizadorApm = Stopwatch.StartNew();
            
            acao();
            temporizadorApm.Stop();

            Agent.Tracer.CurrentTransaction.CaptureSpan(telemetriaNome, acaoNome, (span) =>
            {
                span.SetLabel(telemetriaNome, telemetriaValor);
                span.Duration = temporizadorApm.Elapsed.TotalMilliseconds;
            });
        }
        else
        {
            acao();
        }

        if (!telemetriaOptions.ApplicationInsights) 
            return;

        if (temporizador == null)
            return;
        
        temporizador.Stop();
        telemetryClient.TrackDependency(acaoNome, telemetriaNome, telemetriaValor, inicioOperacao, temporizador.Elapsed,
            true);
    }

    public async Task RegistrarAsync(Func<Task> acao, string acaoNome, string telemetriaNome, string telemetriaValor)
    {
        DateTime inicioOperacao = default;
        Stopwatch? temporizador = default;

        if (telemetriaOptions.ApplicationInsights)
        {
            inicioOperacao = DateTime.UtcNow;
            temporizador = Stopwatch.StartNew();
        }

        if (telemetriaOptions.Apm)
        {
            var temporizadorApm = Stopwatch.StartNew();
            
            await acao();
            temporizadorApm.Stop();

            Agent.Tracer.CurrentTransaction.CaptureSpan(telemetriaNome, acaoNome, (span) =>
            {
                span.SetLabel(telemetriaNome, telemetriaValor);
                span.Duration = temporizadorApm.Elapsed.TotalMilliseconds;
            });
        }
        else
        {
            await acao();
        }

        if (telemetriaOptions.ApplicationInsights && temporizador != null)
        {
            temporizador.Stop();

            telemetryClient.TrackDependency(acaoNome, telemetriaNome, telemetriaValor, inicioOperacao,
                temporizador.Elapsed, true);
        }
    }
}