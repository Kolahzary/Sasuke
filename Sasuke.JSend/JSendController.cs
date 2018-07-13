using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Sasuke.JSend.Filters;
using Sasuke.JSend.Results;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace Sasuke.JSend
{
    [ApiController]
    [JSendExceptionFilter]
    [JSendResultFilter]
    public abstract class JSendControllerBase : ControllerBase
    {
        [Pure]
        protected internal JSendOkResult JSendOk(object data) => new JSendOkResult(data);

        [Pure]
        protected internal JSendBadRequestResult JSendBadRequest() => new JSendBadRequestResult();
        [Pure]
        protected internal JSendBadRequestResult JSendBadRequest(string reason) => new JSendBadRequestResult(reason);

        [Pure]
        protected internal JSendNotFoundResult JSendNotFound() => new JSendNotFoundResult();
        [Pure]
        protected internal JSendNotFoundResult JSendNotFound(string reason) => new JSendNotFoundResult(reason);

        [Pure]
        protected internal JSendUnauthorizedResult JSendUnauthorized() => new JSendUnauthorizedResult();
        [Pure]
        protected internal JSendUnauthorizedResult JSendUnauthorized(string reason) => new JSendUnauthorizedResult(reason);

    }

}
