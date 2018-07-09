using nfe.api.client.Infraestructure;
using ServiceInvoice.Domain.Common;
using ServiceInvoice.Domain.Models;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Tests.UnitTests
{
    public class InvoiceClientTests
    {
        private readonly string _invoiceResourceOk;
        private readonly InvoiceResource _invoiceToAssert;

        public InvoiceClientTests()
        {
            _invoiceResourceOk = File.ReadAllText(@"..\..\..\..\UnitTests\FileToTest\invoiceResource-Example.json");
            _invoiceToAssert = InvoiceResource.FromJson(_invoiceResourceOk);

        }

        [Trait("Unit Tests", "InvoiceClient - PostAsync")]
        [Fact(DisplayName = "PostAsync when send a invoice valid return OK")]
        public async Task PostAsync_WhenSendValidJson_ReturnsOk()
        {
            // Arrange
            var invoiceToRequest = GenerateInvoiceToTest.Invoice();

            var mockHttp = TestHelper.CreateMockHttpPost(_invoiceToAssert.ToJson(), HttpMethod.Post);

            var invoiceClient = new InvoiceClient(mockHttp);

            // Act
            var result = await invoiceClient.PostAsync(TestHelper.companyId, TestHelper.apiKey, invoiceToRequest, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ResultStatusCode.OK, result.Status);
            ValidateHelper.ValidateInvoice(_invoiceToAssert, result.ValueAsSuccess);
        }
    }
}
