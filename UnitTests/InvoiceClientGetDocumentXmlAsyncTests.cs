using nfe.api.client.Infraestructure;
using ServiceInvoice.Domain.Common;
using ServiceInvoice.Domain.Models;
using System;
using System.IO;
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
    }
}
