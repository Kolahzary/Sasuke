using System.Net;

namespace Sasuke.JSend.Results
{
    using Responses;
    public class JSendFailResult : JSendResult<FailResponse>
    {
        public JSendFailResult(object data, HttpStatusCode statusCode)
            : base(new FailResponse(data), statusCode)
        {
        }
    }
}
