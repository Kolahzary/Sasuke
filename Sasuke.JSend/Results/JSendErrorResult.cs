using Sasuke.JSend.Responses;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Sasuke.JSend.Results
{
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
