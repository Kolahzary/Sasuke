using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using Moq;
using Sasuke.JSend.Filters;
using Sasuke.JSend.Responses;
using Sasuke.JSend.Results;
using System;
using System.Collections.Generic;
using Xunit;

namespace Sasuke.Tests.JSend.Filters
{
    /// <summary>
    /// Test JSendExceptionFilterAttribute
    ///  Inspired from: https://stackoverflow.com/questions/38285815/how-to-write-unit-test-for-actionfilter-when-using-service-locator
    /// </summary>
    public class JSendExceptionFilterAttributeTests
    {
        protected static IEnumerable<Exception> TestCases =>
            new List<Exception>
            {
                new Exception(),
                new Exception("This is a test"),
                new DivideByZeroException("DBZE"),
                new ArgumentException("AE","param",null)
            };

        public static IEnumerable<object[]> GetTestCases()
        {
            foreach (var item in TestCases)
            {
                yield return new object[] { item };
            }
        }

        [Theory]
        [MemberData(nameof(GetTestCases))]
        public void ExceptionToJSend(Exception exception)
        {
            #region Arrange
            var serviceProviderMock = new Mock<IServiceProvider>();
            serviceProviderMock.Setup(serviceProvider => serviceProvider.GetService(typeof(ILogger<ResultFilterAttribute>)))
                .Returns(Mock.Of<ILogger<ResultFilterAttribute>>());

            var httpContext = new DefaultHttpContext()
            {
                RequestServices = serviceProviderMock.Object
            };
            
            var actionContext = new ActionContext(httpContext, new RouteData(), new ActionDescriptor());
            

            var exceptionContext = new ExceptionContext(
                actionContext: actionContext,
                filters: new List<IFilterMetadata>())
            {
                Exception = exception
            };
            
            var exceptionFilter = new JSendExceptionFilterAttribute();
            #endregion

            #region Act
            exceptionFilter.OnException(exceptionContext);
            #endregion

            #region Assert

            JSendErrorResult result = Assert.IsAssignableFrom<JSendErrorResult>(exceptionContext.Result);
            Assert.Equal(500, result.StatusCode);

            Assert.IsAssignableFrom<IJSendResponse>(result.Value);

            var errorResponse = Assert.IsAssignableFrom<ErrorResponse>(result.Value);

            Assert.Equal("error", errorResponse.Status);

            Assert.Equal(exception.Message, errorResponse.Message);
            Assert.Equal(exception, errorResponse.Data);
            #endregion
        }
        
    }
}
