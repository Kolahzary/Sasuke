using Sasuke.JSend.Responses;
using System.Net;

namespace Sasuke.JSend.Results
{
    public class JSendBadRequestResult : JSendFailResult
    {
        public JSendBadRequestResult(object data = null)
            : base(data ?? "Bad request.", HttpStatusCode.BadRequest)
        {
        }
    }
}
