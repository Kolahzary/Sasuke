using System.Net;

namespace Sasuke.JSend.Results
{
    using Responses;
    public class JSendErrorResult : JSendResult<ErrorResponse>
    {
        public JSendErrorResult(string message, HttpStatusCode statusCode)
            : base(new ErrorResponse(message), statusCode)
        {
        }

        public JSendErrorResult(string message, HttpStatusCode statusCode, object data)
            : base(new ErrorResponse(message, data), statusCode)
        {
        }
    }
}
