using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Sasuke.JSend.Responses;
using Sasuke.JSend.Results;

namespace Sasuke.JSend.Filters
{
    public class JSendResultFilterAttribute : ResultFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.Result is IJSendResult<IJSendResponse>)
                return;

            if (context.Result is JsonResult)
                context.Result = new JSendOkResult((context.Result as JsonResult).Value);
            else if (context.Result is ObjectResult)
                context.Result = new JSendOkResult((context.Result as ObjectResult).Value);
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
            // Can't change result here because response has already begun.
        }
    }
}
