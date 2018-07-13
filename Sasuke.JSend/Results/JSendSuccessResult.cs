using Sasuke.JSend.Responses;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Sasuke.JSend.Results
{
    public class JSendSuccessResult : JSendResult<SuccessResponse>
    {
        public JSendSuccessResult(object data, HttpStatusCode statusCode)
            : base(new SuccessResponse(data), statusCode)
        {
        }
    }
}
