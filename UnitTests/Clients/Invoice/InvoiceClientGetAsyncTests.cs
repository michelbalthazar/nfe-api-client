using nfe.api.client.Infraestructure;
using ServiceInvoice.Domain.Common;
using ServiceInvoice.Domain.Models;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Tests.UnitTests.Clients.Invoice
{
    public class InvoiceClientGetAsyncTests
    {
        private readonly string _invoiceResourceOk;
        private readonly ServiceInvoiceResource _invoiceToAssert;

        public InvoiceClientGetAsyncTests()
        {
            _invoiceResourceOk = File.ReadAllText(@"..\..\..\..\UnitTests\FileToTest\invoiceResource-Example.json");
            _invoiceToAssert = _invoiceResourceOk.JsonToObject<ServiceInvoiceResource>();
        }

        [Trait("Unit Tests", "InvoiceClient - GetOneAsync")]
        [Fact(DisplayName = "GetOneAsync when send invoiceId valid return OK")]
        public async Task GetOneAsync_WhenInvoiceIdIsValid_ReturnsOk()
        {
            // Arrange
            var mockHttp = TestHelper.CreateMockHttp(HttpMethod.Get, _invoiceToAssert.ToJson<ServiceInvoiceResource>());

            var invoiceClient = new ServiceInvoiceClient(TestHelper.apiKey, mockHttp);

            // Act
            var result = await invoiceClient.GetOneAsync(TestHelper.companyId, TestHelper.invoiceId, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ResultStatusCode.OK, result.Status);
            ValidateHelper.ValidateInvoice(_invoiceToAssert, result.ValueAsSuccess);
        }

        [Trait("Unit Tests", "InvoiceClient - GetOneAsync")]
        [Fact(DisplayName = "GetOneAsync test about exception")]
        public async Task GetOneAsync_WhenRequestResponseReturnNull_ReturnsError()
        {
            // Arrange
            var mockHttp = TestHelper.CreateMockHttpGet(null);

            var invoiceClient = new ServiceInvoiceClient(TestHelper.apiKey, mockHttp.Object);

            // Act
            var result = await invoiceClient.GetOneAsync (TestHelper.companyId, TestHelper.invoiceId, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ResultStatusCode.Error, result.Status);
            Assert.Equal("String reference not set to an instance of a String.\r\nParameter name: s", result.Value.ToString());
        }

        [Trait("Unit Tests", "InvoiceClient - GetOneAsync")]
        [Fact(DisplayName = "GetOneAsync when send invalid invoice return badRequest")]
        public async Task GetOneAsync_WhenSendInvalidInvoice_ReturnsBadRequest()
        {
            // Arrange
            var mockHttp = TestHelper.CreateMockHttp(HttpMethod.Get, httpStatusCode: HttpStatusCode.BadRequest);

            var invoiceClient = new ServiceInvoiceClient(TestHelper.apiKey, mockHttp);

            // Act
            var result = await invoiceClient.GetOneAsync (TestHelper.companyId, TestHelper.invoiceId, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ResultStatusCode.BadRequest, result.Status);
        }

        [Trait("Unit Tests", "InvoiceClient - GetOneAsync")]
        [Fact(DisplayName = "GetOneAsync when send invalid apiKey return Unauthorized")]
        public async Task GetOneAsync_WhenSendInvalidApiKey_ReturnsUnauthorized()
        {
            // Arrange
            var mockHttp = TestHelper.CreateMockHttp(HttpMethod.Get, httpStatusCode: HttpStatusCode.Unauthorized);

            var invoiceClient = new ServiceInvoiceClient("InvalidApiKey", mockHttp);

            // Act
            var result = await invoiceClient.GetOneAsync (TestHelper.companyId, TestHelper.invoiceId, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ResultStatusCode.Unauthorized, result.Status);
        }

        [Trait("Unit Tests", "InvoiceClient - GetOneAsync")]
        [Fact(DisplayName = "GetOneAsync when RequestTimeout return timeout")]
        public async Task GetOneAsync_WhenRequestTimeout_ReturnsTimeout()
        {
            // Arrange
            var mockHttp = TestHelper.CreateMockHttp(HttpMethod.Get, httpStatusCode: HttpStatusCode.RequestTimeout);

            var invoiceClient = new ServiceInvoiceClient(TestHelper.apiKey, mockHttp);

            // Act
            var result = await invoiceClient.GetOneAsync (TestHelper.companyId, TestHelper.invoiceId, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ResultStatusCode.TimedOut, result.Status);
        }

        [Trait("Unit Tests", "InvoiceClient - GetOneAsync")]
        [Fact(DisplayName = "GetOneAsync when InternalServerError return error")]
        public async Task GetOneAsync_WhenInternalServerError_ReturnsError()
        {
            // Arrange
            var mockHttp = TestHelper.CreateMockHttp(HttpMethod.Get, httpStatusCode: HttpStatusCode.InternalServerError);

            var invoiceClient = new ServiceInvoiceClient(TestHelper.apiKey, mockHttp);

            // Act
            var result = await invoiceClient.GetOneAsync (TestHelper.companyId, TestHelper.invoiceId, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ResultStatusCode.Error, result.Status);
        }

        [Trait("Unit Tests", "InvoiceClient - GetOneAsync")]
        [Theory(DisplayName = "GetOneAsync when send invalid invoice return badRequest")]
        [InlineData(default(HttpStatusCode))]
        [InlineData(HttpStatusCode.NotExtended)]
        [InlineData(HttpStatusCode.NotFound)]
        [InlineData(HttpStatusCode.NotAcceptable)]
        [InlineData(HttpStatusCode.RedirectKeepVerb)]
        [InlineData(HttpStatusCode.PreconditionFailed)]
        public async Task GetOneAsync_WhenHttpStatusCodeIsUnexpected_ReturnsError(HttpStatusCode status)
        {
            // Arrange
            var mockHttp = TestHelper.CreateMockHttp(HttpMethod.Get, httpStatusCode: status);

            var invoiceClient = new ServiceInvoiceClient(TestHelper.apiKey, mockHttp);

            // Act
            var result = await invoiceClient.GetOneAsync (TestHelper.companyId, TestHelper.invoiceId, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ResultStatusCode.Error, result.Status);
        }
    }
}
