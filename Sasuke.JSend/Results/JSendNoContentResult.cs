using System.Net;

namespace Sasuke.JSend.Results
{
    public class JSendNoContentResult : JSendSuccessResult
    {
        public JSendNoContentResult()
            : base(null, HttpStatusCode.OK) // HttpStatusCode.NoContent
        {
        }
    }
}
