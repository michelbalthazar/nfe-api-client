using nfe.api.client.Infraestructure;
using ServiceInvoice.Domain.Common;
using ServiceInvoice.Domain.Models;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Tests.UnitTests
{
    public class InvoiceClientPostAsyncTests
    {
        private readonly string _invoiceResourceOk;
        private readonly InvoiceResource _invoiceToAssert;
        private readonly Invoice _invoiceToRequest;

        public InvoiceClientPostAsyncTests()
        {
            _invoiceResourceOk = File.ReadAllText(@"..\..\..\..\UnitTests\FileToTest\invoiceResource-Example.json");
            _invoiceToAssert = InvoiceResource.FromJson(_invoiceResourceOk);
            _invoiceToRequest = GenerateInvoiceToTest.Invoice();

        }

        [Trait("Unit Tests", "InvoiceClient - PostAsync")]
        [Fact(DisplayName = "PostAsync when send a invoice valid return OK")]
        public async Task PostAsync_WhenSendValidJson_ReturnsOk()
        {
            // Arrange
            var mockHttp = TestHelper.CreateMockHttpPost(HttpMethod.Post, _invoiceToAssert.ToJson());

            var invoiceClient = new InvoiceClient(TestHelper.apiKey, mockHttp);

            // Act
            var result = await invoiceClient.PostAsync(TestHelper.companyId, _invoiceToRequest, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ResultStatusCode.OK, result.Status);
            ValidateHelper.ValidateInvoice(_invoiceToAssert, result.ValueAsSuccess);
        }

        [Trait("Unit Tests", "InvoiceClient - PostAsync")]
        [Fact(DisplayName = "PostAsync test about exception")]
        public async Task PostAsync_WhenRequestResponseReturnNull_ReturnsError()
        {
            // Arrange
            var mockHttp = TestHelper.CreateMockHttpGet("testToException");

            var invoiceClient = new InvoiceClient(TestHelper.apiKey, mockHttp.Object);

            // Act
            var result = await invoiceClient.PostAsync(TestHelper.companyId, _invoiceToRequest, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ResultStatusCode.Error, result.Status);
            Assert.Equal("Object reference not set to an instance of an object.", result.Value.ToString());
        }

        [Trait("Unit Tests", "InvoiceClient - PostAsync")]
        [Fact(DisplayName = "PostAsync when send invalid invoice return badRequest")]
        public async Task PostAsync_WhenSendInvalidInvoice_ReturnsBadRequest()
        {
            // Arrange
            var mockHttp = TestHelper.CreateMockHttpPost(HttpMethod.Post, httpStatusCode: HttpStatusCode.BadRequest);

            var invoiceClient = new InvoiceClient(TestHelper.apiKey, mockHttp);

            // Act
            var result = await invoiceClient.PostAsync(TestHelper.companyId, _invoiceToRequest, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ResultStatusCode.BadRequest, result.Status);
        }

        [Trait("Unit Tests", "InvoiceClient - PostAsync")]
        [Fact(DisplayName = "PostAsync when send invalid apiKey return Unauthorized")]
        public async Task PostAsync_WhenSendInvalidApiKey_ReturnsUnauthorized()
        {
            // Arrange
            var mockHttp = TestHelper.CreateMockHttpPost(HttpMethod.Post, httpStatusCode: HttpStatusCode.Unauthorized);

            var invoiceClient = new InvoiceClient("InvalidApiKey", mockHttp);

            // Act
            var result = await invoiceClient.PostAsync(TestHelper.companyId, _invoiceToRequest, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ResultStatusCode.Unauthorized, result.Status);
        }

        [Trait("Unit Tests", "InvoiceClient - PostAsync")]
        [Fact(DisplayName = "PostAsync when RequestTimeout return timeout")]
        public async Task PostAsync_WhenRequestTimeout_ReturnsTimeout()
        {
            // Arrange
            var mockHttp = TestHelper.CreateMockHttpPost(HttpMethod.Post, httpStatusCode: HttpStatusCode.RequestTimeout);

            var invoiceClient = new InvoiceClient(TestHelper.apiKey, mockHttp);

            // Act
            var result = await invoiceClient.PostAsync(TestHelper.companyId, _invoiceToRequest, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ResultStatusCode.TimedOut, result.Status);
        }

        [Trait("Unit Tests", "InvoiceClient - PostAsync")]
        [Fact(DisplayName = "PostAsync when InternalServerError return error")]
        public async Task PostAsync_WhenInternalServerError_ReturnsError()
        {
            // Arrange
            var mockHttp = TestHelper.CreateMockHttpPost(HttpMethod.Post, httpStatusCode: HttpStatusCode.InternalServerError);

            var invoiceClient = new InvoiceClient(TestHelper.apiKey, mockHttp);

            // Act
            var result = await invoiceClient.PostAsync(TestHelper.companyId, _invoiceToRequest, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ResultStatusCode.Error, result.Status);
        }

        [Trait("Unit Tests", "InvoiceClient - PostAsync")]
        [Theory(DisplayName = "PostAsync when send invalid invoice return badRequest")]
        [InlineData(default(HttpStatusCode))]
        [InlineData(HttpStatusCode.NotExtended)]
        [InlineData(HttpStatusCode.NotFound)]
        [InlineData(HttpStatusCode.NotAcceptable)]
        [InlineData(HttpStatusCode.RedirectKeepVerb)]
        [InlineData(HttpStatusCode.PreconditionFailed)]
        public async Task PostAsync_WhenHttpStatusCodeIsUnexpected_ReturnsError(HttpStatusCode status)
        {
            // Arrange
            var mockHttp = TestHelper.CreateMockHttpPost(HttpMethod.Post, httpStatusCode: status);

            var invoiceClient = new InvoiceClient(TestHelper.apiKey, mockHttp);

            // Act
            var result = await invoiceClient.PostAsync(TestHelper.companyId, _invoiceToRequest, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ResultStatusCode.Error, result.Status);
        }
    }
}
