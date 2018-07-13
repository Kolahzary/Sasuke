using Microsoft.AspNetCore.Mvc;
using Sasuke.JSend.Responses;
using System.Net;

namespace Sasuke.JSend.Results
{
    public class JSendNotFoundResult : JSendFailResult
    {
        public JSendNotFoundResult(string reason = "The requested resource could not be found.")
            : base(reason, HttpStatusCode.NotFound)
        {
        }
    }
}
