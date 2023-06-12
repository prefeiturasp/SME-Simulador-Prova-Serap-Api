using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace SME.Simulador.Prova.Serap.Api;

public static class OperationFilterContextExtension
{
    public static bool IsAllowAnonymous(this OperationFilterContext context)
    {
        return context.ApiDescription.CustomAttributes().Any(attr => attr.GetType() == typeof(AllowAnonymousAttribute));        
    }    
}