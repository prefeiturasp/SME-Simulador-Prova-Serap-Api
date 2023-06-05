using FluentValidation;
using MediatR;
using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        this.validators = validators ?? throw new ArgumentNullException(nameof(validators));
    }
    
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (!validators.Any())
            return await next();
        
        var context = new ValidationContext<TRequest>(request);

        var errors = validators
            .Select(x => x.Validate(context))
            .SelectMany(x => x.Errors)
            .Where(x => x != null)
            .Select(c => c.ErrorMessage)
            .Distinct()
            .ToList();

        if (errors.Any())                
            throw new ValidacaoException(errors);

        return await next();
    }
}