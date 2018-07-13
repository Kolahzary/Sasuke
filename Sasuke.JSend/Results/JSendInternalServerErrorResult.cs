using Sasuke.JSend.Responses;
using System.Net;

namespace Sasuke.JSend.Results
{
    public class JSendInternalServerErrorResult : JSendErrorResult
    {
        public JSendInternalServerErrorResult(string message)
            : base(message, HttpStatusCode.InternalServerError)
        {
        }

        public JSendInternalServerErrorResult(string message, object data)
            : base(message, HttpStatusCode.InternalServerError, data)
        {
        }
    }
}
