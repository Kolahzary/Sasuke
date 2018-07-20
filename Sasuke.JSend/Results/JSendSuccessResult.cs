using System.Net;

namespace Sasuke.JSend.Results
{
    using Responses;
    public class JSendSuccessResult : JSendResult<SuccessResponse>
    {
        public JSendSuccessResult(object data, HttpStatusCode statusCode)
            : base(new SuccessResponse(data), statusCode)
        {
        }
    }
}
