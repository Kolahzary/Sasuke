using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Sasuke.JSend.Results
{
    public class JSendUnauthorizedResult : JSendFailResult
    {
        public JSendUnauthorizedResult(string reason = "Authorization has been denied for this request.")
            : base(reason, HttpStatusCode.Unauthorized)
        {
        }
    }
}
