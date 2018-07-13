using Sasuke.JSend.Responses;
using System.Net;

namespace Sasuke.JSend.Results
{
    public class JSendBadRequestResult : JSendFailResult
    {
        public JSendBadRequestResult(string reason = "Bad request.")
            : base(reason, HttpStatusCode.BadRequest)
        {
        }
    }
}
