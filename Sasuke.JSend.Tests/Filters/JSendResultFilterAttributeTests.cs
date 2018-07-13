using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using Sasuke.JSend.Filters;
using Sasuke.JSend.Responses;
using Sasuke.JSend.Results;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Sasuke.Tests.JSend.Filters
{
    /// <summary>
    /// Test JSendResultFilterAttribute
    ///  Inspired from: https://stackoverflow.com/questions/38285815/how-to-write-unit-test-for-actionfilter-when-using-service-locator
    /// </summary>
    public class JSendResultFilterAttributeTests
    {
        protected class TestData
        {
            [JsonProperty("integer", Order = 0)]
            public int Integer { get; set; }

            [JsonProperty("string", Order = 1)]
            public string String { get; set; }

            [JsonProperty("list", Order = 2)]
            public List<string> List { get; set; }

            [JsonProperty("object", Order = 3)]
            public object Object { get; set; }
        }
        
        protected static IEnumerable<object> TestCases =>
            new List<object>
            {
                "",
                "string",
                1234,
                new List<string>() { "foo", "bar", "baz" },
                new TestData()
                {
                    Integer = 1234,
                    String = "test",
                    List = new List<string>() { "foo", "bar", "baz" },
                    Object = new { foo = "bar", bar = new List<string>() { "baz", "qux" } }
                },
                new List<TestData>()
            };

        public static IEnumerable<object[]> TestCasesToActionResult()
        {
            foreach (var item in TestCases)
            {
                yield return new object[] { new ObjectResult(item) };
                yield return new object[] { new JsonResult(item) };
            }
        }

        [Theory]
        [MemberData(nameof(TestCasesToActionResult))]
        public void ObjectResultToJSend(IActionResult result)
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
            
            var resultExecutingContext = new ResultExecutingContext(
                actionContext,
                filters: new List<IFilterMetadata>(), // for majority of scenarios you need not worry about populating this parameter
                result: result,
                controller: null); // since the filter being tested here does not use the data from this parameter, just provide null

            var resultFilter = new JSendResultFilterAttribute();
            #endregion

            #region Act
            resultFilter.OnResultExecuting(resultExecutingContext);
            #endregion

            #region Assert
            JSendSuccessResult jsonResult = Assert.IsAssignableFrom<JSendSuccessResult>(resultExecutingContext.Result);
            Assert.Equal(200, jsonResult.StatusCode);

            Assert.IsAssignableFrom<IJSendResponse>(jsonResult.Value);

            var successResponse = Assert.IsAssignableFrom<SuccessResponse>(jsonResult.Value);

            Assert.Equal("success", successResponse.Status);
            
            if (result is ObjectResult)
            {
                var res = Assert.IsType<ObjectResult>(result);
                Assert.Equal(successResponse.Data, res.Value);
            }
            else
            {
                var res = Assert.IsType<JsonResult>(result);
                Assert.Equal(successResponse.Data, res.Value);
            }

            #endregion
        }
        
    }
}
