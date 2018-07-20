using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Sasuke.JSend.Responses;
using Sasuke.JSend.Results;

namespace Sasuke.JSend.Filters
{
    public class JSendResultFilterAttribute : ResultFilterAttribute
    {
        /*
        private bool IsEmpty(object val)
        {
            if (val != null)
            {
                var enu = (val as IEnumerable);
                if (enu == null) // if it's not enumerable
                    return false; // it's a non-null object, not empty
                else // if it's an enumerable
                    foreach (var item in enu) // and it has any item
                        return false; // it's not empty
            }
            return true;
        }*/
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.Result is IJSendResult<IJSendResponse>)
                return;
            
            if(context.Result is BadRequestObjectResult)
                context.Result = new JSendBadRequestResult((context.Result as BadRequestObjectResult).Value);
            else if (context.Result is JsonResult)
                context.Result = new JSendOkResult((context.Result as JsonResult).Value);
            else if (context.Result is ObjectResult)
            {
                var val = (context.Result as ObjectResult).Value;
                /*if (IsEmpty(val))
                    context.Result = new JSendNoContentResult();
                else*/
                    context.Result = new JSendOkResult(val);
            }
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
            // Can't change result here because response has already begun.
        }
    }
}
