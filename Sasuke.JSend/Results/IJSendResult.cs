using Microsoft.AspNetCore.Mvc;

namespace Sasuke.JSend.Results
{
    using Responses;
    /// <summary>
    /// Represents an action result that returns the specified JSend response with the specified status code.
    /// </summary>
    /// <typeparam name="TResponse">The type of the JSend response.</typeparam>
    public interface IJSendResult<out TResponse> : IActionResult where TResponse: IJSendResponse
    {
    }
}
