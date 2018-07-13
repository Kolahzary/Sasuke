using Microsoft.AspNetCore.Mvc;

namespace Sasuke.JSend
{
    public abstract class JSendCatchAllController : JSendControllerBase
    {
        protected string _NotFoundMessageFormat;
        public JSendCatchAllController(string messageFormat = "There isn't any route definded for /{0}")
        {
            _NotFoundMessageFormat = messageFormat;
        }

        [Route("{*path}", Order = 999)]
        public ActionResult Get(string path)
        {
            return JSendNotFound(string.Format(_NotFoundMessageFormat, path));
        }
    }
}
