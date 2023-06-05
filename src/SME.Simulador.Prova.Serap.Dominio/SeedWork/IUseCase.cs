namespace SME.Simulador.Prova.Serap.Dominio;

public interface IUseCase<in TRequest, TResponse>
{
    Task<TResponse> ExecutarAsync(TRequest request);
}