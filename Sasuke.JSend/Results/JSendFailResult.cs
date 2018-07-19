using Sasuke.JSend.Responses;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Sasuke.JSend.Results
{
    public class JSendFailResult : JSendResult<FailResponse>
    {
        public JSendFailResult(object data, HttpStatusCode statusCode)
            : base(new FailResponse(data), statusCode)
        {
        }
    }
}
