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
    public class InvoiceClientGetDocumentPdfAsyncTests
    {
        private readonly string _invoiceResourceOk;
        private readonly byte[] _pdfByteToTest;
        private readonly ServiceInvoiceResource _invoiceToAssert;

        public InvoiceClientGetDocumentPdfAsyncTests()
        {
            _invoiceResourceOk = File.ReadAllText(@"..\..\..\..\UnitTests\FileToTest\invoiceResource-Example.json");
            _pdfByteToTest = File.ReadAllBytes(@"..\..\..\..\UnitTests\FileToTest\pdf-file-to-test.pdf");
            _invoiceToAssert = _invoiceResourceOk.JsonToObject<ServiceInvoiceResource>();
        }

        [Trait("Unit Tests", "InvoiceClient - GetDocumentPdfBytesAsync")]
        [Fact(DisplayName = "GetDocumentPdfBytesAsync when send invoiceId valid return OK")]
        public async Task GetDocumentPdfBytesAsync_WhenInvoiceIdIsValid_ReturnsOk()
        {
            // Arrange

            var mockHttp = TestHelper.CreateMockHttp(HttpMethod.Get, _pdfByteToTest);

            var invoiceClient = new ServiceInvoiceClient(TestHelper.apiKey, mockHttp);

            // Act
            var result = await invoiceClient.GetDocumentPdfBytesAsync(TestHelper.companyId, TestHelper.invoiceId, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ResultStatusCode.OK, result.Status);
            Assert.Equal(_pdfByteToTest, result.ValueAsSuccess);
        }

        [Trait("Unit Tests", "InvoiceClient - GetDocumentPdfBytesAsync")]
        [Fact(DisplayName = "GetDocumentPdfBytesAsync test about exception")]
        public async Task GetDocumentPdfBytesAsync_WhenRequestResponseReturnNull_ReturnsError()
        {
            // Arrange
            var mockHttp = TestHelper.CreateMockHttpGet(null);

            var invoiceClient = new ServiceInvoiceClient(TestHelper.apiKey, mockHttp.Object);

            // Act
            var result = await invoiceClient.GetDocumentPdfBytesAsync(TestHelper.companyId, TestHelper.invoiceId, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ResultStatusCode.Error, result.Status);
            Assert.Equal("String reference not set to an instance of a String.\r\nParameter name: s", result.Value.ToString());
        }

        [Trait("Unit Tests", "InvoiceClient - GetDocumentPdfBytesAsync")]
        [Fact(DisplayName = "GetDocumentPdfBytesAsync when send invalid invoice return badRequest")]
        public async Task GetDocumentPdfBytesAsync_WhenSendInvalidInvoice_ReturnsBadRequest()
        {
            // Arrange
            var mockHttp = TestHelper.CreateMockHttp(HttpMethod.Get, new byte[0], httpStatusCode: HttpStatusCode.BadRequest);

            var invoiceClient = new ServiceInvoiceClient(TestHelper.apiKey, mockHttp);

            // Act
            var result = await invoiceClient.GetDocumentPdfBytesAsync(TestHelper.companyId, TestHelper.invoiceId, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ResultStatusCode.BadRequest, result.Status);
        }

        [Trait("Unit Tests", "InvoiceClient - GetDocumentPdfBytesAsync")]
        [Fact(DisplayName = "GetDocumentPdfBytesAsync when send invalid apiKey return Unauthorized")]
        public async Task GetDocumentPdfBytesAsync_WhenSendInvalidApiKey_ReturnsUnauthorized()
        {
            // Arrange
            var mockHttp = TestHelper.CreateMockHttp(HttpMethod.Get, new byte[0], httpStatusCode: HttpStatusCode.Unauthorized);

            var invoiceClient = new ServiceInvoiceClient("InvalidApiKey", mockHttp);

            // Act
            var result = await invoiceClient.GetDocumentPdfBytesAsync(TestHelper.companyId, TestHelper.invoiceId, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ResultStatusCode.Unauthorized, result.Status);
        }

        [Trait("Unit Tests", "InvoiceClient - GetDocumentPdfBytesAsync")]
        [Fact(DisplayName = "GetDocumentPdfBytesAsync when RequestTimeout return timeout")]
        public async Task GetDocumentPdfBytesAsync_WhenRequestTimeout_ReturnsTimeout()
        {
            // Arrange
            var mockHttp = TestHelper.CreateMockHttp(HttpMethod.Get, new byte[0], httpStatusCode: HttpStatusCode.RequestTimeout);

            var invoiceClient = new ServiceInvoiceClient(TestHelper.apiKey, mockHttp);

            // Act
            var result = await invoiceClient.GetDocumentPdfBytesAsync(TestHelper.companyId, TestHelper.invoiceId, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ResultStatusCode.TimedOut, result.Status);
        }

        [Trait("Unit Tests", "InvoiceClient - GetDocumentPdfBytesAsync")]
        [Fact(DisplayName = "GetDocumentPdfBytesAsync when InternalServerError return error")]
        public async Task GetDocumentPdfBytesAsync_WhenInternalServerError_ReturnsError()
        {
            // Arrange
            var mockHttp = TestHelper.CreateMockHttp(HttpMethod.Get, new byte[0], httpStatusCode: HttpStatusCode.InternalServerError);

            var invoiceClient = new ServiceInvoiceClient(TestHelper.apiKey, mockHttp);

            // Act
            var result = await invoiceClient.GetDocumentPdfBytesAsync(TestHelper.companyId, TestHelper.invoiceId, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ResultStatusCode.Error, result.Status);
        }

        [Trait("Unit Tests", "InvoiceClient - GetDocumentPdfBytesAsync")]
        [Theory(DisplayName = "GetDocumentPdfBytesAsync when send invalid invoice return badRequest")]
        [InlineData(default(HttpStatusCode))]
        [InlineData(HttpStatusCode.NotExtended)]
        [InlineData(HttpStatusCode.NotFound)]
        [InlineData(HttpStatusCode.NotAcceptable)]
        [InlineData(HttpStatusCode.RedirectKeepVerb)]
        [InlineData(HttpStatusCode.PreconditionFailed)]
        public async Task GetDocumentPdfBytesAsync_WhenHttpStatusCodeIsUnexpected_ReturnsError(HttpStatusCode status)
        {
            // Arrange
            var mockHttp = TestHelper.CreateMockHttp(HttpMethod.Get, new byte[0], httpStatusCode: status);

            var invoiceClient = new ServiceInvoiceClient(TestHelper.apiKey, mockHttp);

            // Act
            var result = await invoiceClient.GetDocumentPdfBytesAsync(TestHelper.companyId, TestHelper.invoiceId, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ResultStatusCode.Error, result.Status);
        }
    }
}
