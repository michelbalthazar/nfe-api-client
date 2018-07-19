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

namespace Tests.UnitTests
{
    public class InvoiceClientGetDocumentXmlAsyncTests
    {
        private readonly string _invoiceResourceOk;
        private readonly string _xmlToTest;
        private readonly InvoiceResource _invoiceToAssert;

        public InvoiceClientGetDocumentXmlAsyncTests()
        {
            _invoiceResourceOk = File.ReadAllText(@"..\..\..\..\UnitTests\FileToTest\invoiceResource-Example.json");
            //_pdfByteToTest = File.ReadAllBytes(@"..\..\..\..\UnitTests\FileToTest\invoiceResource-Example.xml");
            _xmlToTest = File.ReadAllText(@"..\..\..\..\UnitTests\FileToTest\invoiceResource-Example.xml");
            _invoiceToAssert = InvoiceResource.FromJson(_invoiceResourceOk);
        }

        [Trait("Unit Tests", "InvoiceClient - GetDocumentXmlAsync")]
        [Fact(DisplayName = "GetDocumentXmlAsync when send invoiceId valid return OK")]
        public async Task GetDocumentXmlAsync_WhenInvoiceIdIsValid_ReturnsOk()
        {
            // Arrange
            var mockHttp = TestHelper.CreateMockHttp(HttpMethod.Get, _xmlToTest);

            var invoiceClient = new InvoiceClient(TestHelper.apiKey, mockHttp);

            // Act
            var result = await invoiceClient.GetDocumentXmlAsync(TestHelper.companyId, TestHelper.invoiceId, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ResultStatusCode.OK, result.Status);
            Assert.Equal(_xmlToTest.GetBytesFromString(), result.ValueAsSuccess.GetBytesFromString());
        }

        [Trait("Unit Tests", "InvoiceClient - GetDocumentXmlAsync")]
        [Fact(DisplayName = "GetDocumentXmlAsync test about exception")]
        public async Task GetDocumentXmlAsync_WhenRequestResponseReturnNull_ReturnsError()
        {
            // Arrange
            var mockHttp = TestHelper.CreateMockHttpGet(null);

            var invoiceClient = new InvoiceClient(TestHelper.apiKey, mockHttp.Object);

            // Act
            var result = await invoiceClient.GetDocumentXmlAsync(TestHelper.companyId, TestHelper.invoiceId, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ResultStatusCode.Error, result.Status);
            Assert.Equal("String reference not set to an instance of a String.\r\nParameter name: s", result.Value.ToString());
        }

        [Trait("Unit Tests", "InvoiceClient - GetDocumentXmlAsync")]
        [Fact(DisplayName = "GetDocumentXmlAsync when send invalid invoice return badRequest")]
        public async Task GetDocumentXmlAsync_WhenSendInvalidInvoice_ReturnsBadRequest()
        {
            // Arrange
            var mockHttp = TestHelper.CreateMockHttp(HttpMethod.Get, "testToException", httpStatusCode: HttpStatusCode.BadRequest);

            var invoiceClient = new InvoiceClient(TestHelper.apiKey, mockHttp);

            // Act
            var result = await invoiceClient.GetDocumentXmlAsync(TestHelper.companyId, TestHelper.invoiceId, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ResultStatusCode.BadRequest, result.Status);
        }

        [Trait("Unit Tests", "InvoiceClient - GetDocumentXmlAsync")]
        [Fact(DisplayName = "GetDocumentXmlAsync when send invalid apiKey return Unauthorized")]
        public async Task GetDocumentXmlAsync_WhenSendInvalidApiKey_ReturnsUnauthorized()
        {
            // Arrange
            var mockHttp = TestHelper.CreateMockHttp(HttpMethod.Get, "testToException", httpStatusCode: HttpStatusCode.Unauthorized);

            var invoiceClient = new InvoiceClient("InvalidApiKey", mockHttp);

            // Act
            var result = await invoiceClient.GetDocumentXmlAsync(TestHelper.companyId, TestHelper.invoiceId, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ResultStatusCode.Unauthorized, result.Status);
        }

        [Trait("Unit Tests", "InvoiceClient - GetDocumentXmlAsync")]
        [Fact(DisplayName = "GetDocumentXmlAsync when RequestTimeout return timeout")]
        public async Task GetDocumentXmlAsync_WhenRequestTimeout_ReturnsTimeout()
        {
            // Arrange
            var mockHttp = TestHelper.CreateMockHttp(HttpMethod.Get, "testToException", httpStatusCode: HttpStatusCode.RequestTimeout);

            var invoiceClient = new InvoiceClient(TestHelper.apiKey, mockHttp);

            // Act
            var result = await invoiceClient.GetDocumentXmlAsync(TestHelper.companyId, TestHelper.invoiceId, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ResultStatusCode.TimedOut, result.Status);
        }

        [Trait("Unit Tests", "InvoiceClient - GetDocumentXmlAsync")]
        [Fact(DisplayName = "GetDocumentXmlAsync when InternalServerError return error")]
        public async Task GetDocumentXmlAsync_WhenInternalServerError_ReturnsError()
        {
            // Arrange
            var mockHttp = TestHelper.CreateMockHttp(HttpMethod.Get, "testToException", httpStatusCode: HttpStatusCode.InternalServerError);

            var invoiceClient = new InvoiceClient(TestHelper.apiKey, mockHttp);

            // Act
            var result = await invoiceClient.GetDocumentXmlAsync(TestHelper.companyId, TestHelper.invoiceId, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ResultStatusCode.Error, result.Status);
        }

        [Trait("Unit Tests", "InvoiceClient - GetDocumentXmlAsync")]
        [Theory(DisplayName = "GetDocumentXmlAsync when send invalid invoice return badRequest")]
        [InlineData(default(HttpStatusCode))]
        [InlineData(HttpStatusCode.NotExtended)]
        [InlineData(HttpStatusCode.NotFound)]
        [InlineData(HttpStatusCode.NotAcceptable)]
        [InlineData(HttpStatusCode.RedirectKeepVerb)]
        [InlineData(HttpStatusCode.PreconditionFailed)]
        public async Task GetDocumentXmlAsync_WhenHttpStatusCodeIsUnexpected_ReturnsError(HttpStatusCode status)
        {
            // Arrange
            var mockHttp = TestHelper.CreateMockHttp(HttpMethod.Get, "testToException", httpStatusCode: status);

            var invoiceClient = new InvoiceClient(TestHelper.apiKey, mockHttp);

            // Act
            var result = await invoiceClient.GetDocumentXmlAsync(TestHelper.companyId, TestHelper.invoiceId, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ResultStatusCode.Error, result.Status);
        }
    }
}
