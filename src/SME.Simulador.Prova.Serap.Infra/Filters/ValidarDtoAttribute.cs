using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SME.Simulador.Prova.Serap.Infra;

public class ValidarDtoAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
            context.Result = new FalhaValidacaoResult(context.ModelState);
    }

    private class FalhaValidacaoResult : ObjectResult
    {
        public FalhaValidacaoResult(ModelStateDictionary modelState) : base(RetornaBaseModel(modelState))
        {
            StatusCode = StatusCodes.Status422UnprocessableEntity;
        }

        private static RetornoBaseDto RetornaBaseModel(ModelStateDictionary modelState)
        {
            var dto = new RetornoBaseDto
            {
                Mensagens = modelState.Keys
                    .SelectMany(key =>
                    {
                        var itemModelState = modelState[key];

                        return itemModelState == null
                            ? Enumerable.Empty<string>()
                            : itemModelState.Errors.Select(x => new string(x.ErrorMessage));
                    }).ToList()
            };

            return dto;
        }
    }        
}