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
    public class InvoiceClientSendEmailAsyncTests
    {
        private readonly string _invoiceResourceOk;
        private readonly InvoiceResource _invoiceToAssert;

        public InvoiceClientSendEmailAsyncTests()
        {
            _invoiceResourceOk = File.ReadAllText(@"..\..\..\..\UnitTests\FileToTest\invoiceResource-Example.json");
            _invoiceToAssert = _invoiceResourceOk.JsonToObject<InvoiceResource>();
        }

        [Trait("Unit Tests", "InvoiceClient - SendEmailAsync")]
        [Fact(DisplayName = "SendEmailAsync when send invoiceId valid return OK")]
        public async Task SendEmailAsync_WhenInvoiceIdIsValid_ReturnsOk()
        {
            // Arrange
            var mockHttp = TestHelper.CreateMockHttp(HttpMethod.Put, "");

            var invoiceClient = new InvoiceClient(TestHelper.apiKey, mockHttp);

            // Act
            var result = await invoiceClient.SendEmailAsync(TestHelper.companyId, TestHelper.invoiceId, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ResultStatusCode.OK, result.Status);
        }

        [Trait("Unit Tests", "InvoiceClient - SendEmailAsync")]
        [Fact(DisplayName = "SendEmailAsync test about exception")]
        public async Task SendEmailAsync_WhenRequestResponseReturnNull_ReturnsError()
        {
            // Arrange
            var mockHttp = TestHelper.CreateMockHttpGet(null);

            var invoiceClient = new InvoiceClient(TestHelper.apiKey, mockHttp.Object);

            // Act
            var result = await invoiceClient.SendEmailAsync(TestHelper.companyId, TestHelper.invoiceId, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ResultStatusCode.Error, result.Status);
            Assert.Equal("Object reference not set to an instance of an object.", result.Value.ToString());
        }

        [Trait("Unit Tests", "InvoiceClient - SendEmailAsync")]
        [Fact(DisplayName = "SendEmailAsync when send invalid invoice return badRequest")]
        public async Task SendEmailAsync_WhenSendInvalidInvoice_ReturnsBadRequest()
        {
            // Arrange
            var mockHttp = TestHelper.CreateMockHttp(HttpMethod.Put, httpStatusCode: HttpStatusCode.BadRequest);

            var invoiceClient = new InvoiceClient(TestHelper.apiKey, mockHttp);

            // Act
            var result = await invoiceClient.SendEmailAsync(TestHelper.companyId, TestHelper.invoiceId, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ResultStatusCode.BadRequest, result.Status);
        }

        [Trait("Unit Tests", "InvoiceClient - SendEmailAsync")]
        [Fact(DisplayName = "SendEmailAsync when send invalid apiKey return Unauthorized")]
        public async Task SendEmailAsync_WhenSendInvalidApiKey_ReturnsUnauthorized()
        {
            // Arrange
            var mockHttp = TestHelper.CreateMockHttp(HttpMethod.Put, httpStatusCode: HttpStatusCode.Unauthorized);

            var invoiceClient = new InvoiceClient("InvalidApiKey", mockHttp);

            // Act
            var result = await invoiceClient.SendEmailAsync(TestHelper.companyId, TestHelper.invoiceId, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ResultStatusCode.Unauthorized, result.Status);
        }

        [Trait("Unit Tests", "InvoiceClient - SendEmailAsync")]
        [Fact(DisplayName = "SendEmailAsync when RequestTimeout return timeout")]
        public async Task SendEmailAsync_WhenRequestTimeout_ReturnsTimeout()
        {
            // Arrange
            var mockHttp = TestHelper.CreateMockHttp(HttpMethod.Put, httpStatusCode: HttpStatusCode.RequestTimeout);

            var invoiceClient = new InvoiceClient(TestHelper.apiKey, mockHttp);

            // Act
            var result = await invoiceClient.SendEmailAsync(TestHelper.companyId, TestHelper.invoiceId, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ResultStatusCode.TimedOut, result.Status);
        }

        [Trait("Unit Tests", "InvoiceClient - SendEmailAsync")]
        [Fact(DisplayName = "SendEmailAsync when InternalServerError return error")]
        public async Task SendEmailAsync_WhenInternalServerError_ReturnsError()
        {
            // Arrange
            var mockHttp = TestHelper.CreateMockHttp(HttpMethod.Put, httpStatusCode: HttpStatusCode.InternalServerError);

            var invoiceClient = new InvoiceClient(TestHelper.apiKey, mockHttp);

            // Act
            var result = await invoiceClient.SendEmailAsync(TestHelper.companyId, TestHelper.invoiceId, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ResultStatusCode.Error, result.Status);
        }

        [Trait("Unit Tests", "InvoiceClient - SendEmailAsync")]
        [Theory(DisplayName = "SendEmailAsync when send invalid invoice return badRequest")]
        [InlineData(default(HttpStatusCode))]
        [InlineData(HttpStatusCode.NotExtended)]
        [InlineData(HttpStatusCode.NotFound)]
        [InlineData(HttpStatusCode.NotAcceptable)]
        [InlineData(HttpStatusCode.RedirectKeepVerb)]
        [InlineData(HttpStatusCode.PreconditionFailed)]
        public async Task SendEmailAsync_WhenHttpStatusCodeIsUnexpected_ReturnsError(HttpStatusCode status)
        {
            // Arrange
            var mockHttp = TestHelper.CreateMockHttp(HttpMethod.Put, httpStatusCode: status);

            var invoiceClient = new InvoiceClient(TestHelper.apiKey, mockHttp);

            // Act
            var result = await invoiceClient.SendEmailAsync(TestHelper.companyId, TestHelper.invoiceId, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ResultStatusCode.Error, result.Status);
        }
    }
}
