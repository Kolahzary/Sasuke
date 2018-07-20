using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Sasuke.JSend.Results
{
    using Responses;
    public class JSendResult<TResponse> : ObjectResult, IJSendResult<TResponse> where TResponse : IJSendResponse
    {
        public JSendResult(TResponse response, HttpStatusCode statusCode = HttpStatusCode.OK)
            : base(response)
        {
            StatusCode = (int)statusCode;
        }
    }
}
