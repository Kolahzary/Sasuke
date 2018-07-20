using System.Net;

namespace Sasuke.JSend.Results
{
    public class JSendOkResult : JSendSuccessResult
    {
        public JSendOkResult(object data)
            : base(data, HttpStatusCode.OK)
        {
        }
    }
}
