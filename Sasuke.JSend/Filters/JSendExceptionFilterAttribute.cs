using Microsoft.AspNetCore.Mvc.Filters;

namespace Sasuke.JSend.Filters
{
    using Results;

    public class JSendExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            context.ExceptionHandled = true;
            
            context.Result = new JSendInternalServerErrorResult(context.Exception.Message, context.Exception);
        }
    }
}
