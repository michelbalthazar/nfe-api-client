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
    public class InvoiceClientDeleteAsyncTests
    {
        private readonly string _invoiceResourceOk;
        private readonly InvoiceResource _invoiceToAssert;

        public InvoiceClientDeleteAsyncTests()
        {
            _invoiceResourceOk = File.ReadAllText(@"..\..\..\..\UnitTests\FileToTest\invoiceResource-Example.json");
            _invoiceToAssert = InvoiceResource.FromJson(_invoiceResourceOk);
        }

        [Trait("Unit Tests", "InvoiceClient - DeleteAsync")]
        [Fact(DisplayName = "DeleteAsync when send invoiceId valid return OK")]
        public async Task DeleteAsync_WhenInvoiceIdIsValid_ReturnsOk()
        {
            // Arrange
            var mockHttp = TestHelper.CreateMockHttp(HttpMethod.Delete, _invoiceToAssert.ToJson());

            var invoiceClient = new InvoiceClient(TestHelper.apiKey, mockHttp);

            // Act
            var result = await invoiceClient.DeleteAsync(TestHelper.companyId, TestHelper.invoiceId, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.ValueAsSuccess);
            Assert.Equal(ResultStatusCode.OK, result.Status);
        }

        [Trait("Unit Tests", "InvoiceClient - DeleteAsync")]
        [Fact(DisplayName = "DeleteAsync test about exception")]
        public async Task DeleteAsync_WhenRequestResponseReturnNull_ReturnsError()
        {
            // Arrange
            var mockHttp = TestHelper.CreateMockHttpGet(null);

            var invoiceClient = new InvoiceClient(TestHelper.apiKey, mockHttp.Object);

            // Act
            var result = await invoiceClient.DeleteAsync(TestHelper.companyId, TestHelper.invoiceId, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ResultStatusCode.Error, result.Status);
            Assert.Equal("Object reference not set to an instance of an object.", result.Value.ToString());
        }

        [Trait("Unit Tests", "InvoiceClient - DeleteAsync")]
        [Fact(DisplayName = "DeleteAsync when send invalid invoice return badRequest")]
        public async Task DeleteAsync_WhenSendInvalidInvoice_ReturnsBadRequest()
        {
            // Arrange
            var mockHttp = TestHelper.CreateMockHttp(HttpMethod.Delete, httpStatusCode: HttpStatusCode.BadRequest);

            var invoiceClient = new InvoiceClient(TestHelper.apiKey, mockHttp);

            // Act
            var result = await invoiceClient.DeleteAsync(TestHelper.companyId, TestHelper.invoiceId, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ResultStatusCode.BadRequest, result.Status);
        }

        [Trait("Unit Tests", "InvoiceClient - DeleteAsync")]
        [Fact(DisplayName = "DeleteAsync when send invalid apiKey return Unauthorized")]
        public async Task DeleteAsync_WhenSendInvalidApiKey_ReturnsUnauthorized()
        {
            // Arrange
            var mockHttp = TestHelper.CreateMockHttp(HttpMethod.Delete, httpStatusCode: HttpStatusCode.Unauthorized);

            var invoiceClient = new InvoiceClient("InvalidApiKey", mockHttp);

            // Act
            var result = await invoiceClient.DeleteAsync(TestHelper.companyId, TestHelper.invoiceId, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ResultStatusCode.Unauthorized, result.Status);
        }

        [Trait("Unit Tests", "InvoiceClient - DeleteAsync")]
        [Fact(DisplayName = "DeleteAsync when RequestTimeout return timeout")]
        public async Task DeleteAsync_WhenRequestTimeout_ReturnsTimeout()
        {
            // Arrange
            var mockHttp = TestHelper.CreateMockHttp(HttpMethod.Delete, httpStatusCode: HttpStatusCode.RequestTimeout);

            var invoiceClient = new InvoiceClient(TestHelper.apiKey, mockHttp);

            // Act
            var result = await invoiceClient.DeleteAsync(TestHelper.companyId, TestHelper.invoiceId, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ResultStatusCode.TimedOut, result.Status);
        }

        [Trait("Unit Tests", "InvoiceClient - DeleteAsync")]
        [Fact(DisplayName = "DeleteAsync when InternalServerError return error")]
        public async Task DeleteAsync_WhenInternalServerError_ReturnsError()
        {
            // Arrange
            var mockHttp = TestHelper.CreateMockHttp(HttpMethod.Delete, httpStatusCode: HttpStatusCode.InternalServerError);

            var invoiceClient = new InvoiceClient(TestHelper.apiKey, mockHttp);

            // Act
            var result = await invoiceClient.DeleteAsync(TestHelper.companyId, TestHelper.invoiceId, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ResultStatusCode.Error, result.Status);
        }

        [Trait("Unit Tests", "InvoiceClient - DeleteAsync")]
        [Theory(DisplayName = "DeleteAsync when send invalid invoice return badRequest")]
        [InlineData(default(HttpStatusCode))]
        [InlineData(HttpStatusCode.NotExtended)]
        [InlineData(HttpStatusCode.NotFound)]
        [InlineData(HttpStatusCode.NotAcceptable)]
        [InlineData(HttpStatusCode.RedirectKeepVerb)]
        [InlineData(HttpStatusCode.PreconditionFailed)]
        public async Task DeleteAsync_WhenHttpStatusCodeIsUnexpected_ReturnsError(HttpStatusCode status)
        {
            // Arrange
            var mockHttp = TestHelper.CreateMockHttp(HttpMethod.Delete, httpStatusCode: status);

            var invoiceClient = new InvoiceClient(TestHelper.apiKey, mockHttp);

            // Act
            var result = await invoiceClient.DeleteAsync(TestHelper.companyId, TestHelper.invoiceId, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ResultStatusCode.Error, result.Status);
        }
    }
}
