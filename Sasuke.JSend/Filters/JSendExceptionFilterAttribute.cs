using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Sasuke.JSend.Responses;
using Sasuke.JSend.Results;
using System.Net;

namespace Sasuke.JSend.Filters
{
    public class JSendExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            context.ExceptionHandled = true;
            
            context.Result = new JSendInternalServerErrorResult(context.Exception.Message, context.Exception);
        }
    }
}
