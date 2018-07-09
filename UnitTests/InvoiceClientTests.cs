using nfe.api.client.Infraestructure;
using ServiceInvoice.Domain.Common;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Tests.UnitTests
{
    public class InvoiceClientTests
    {
        [Trait("Unit Tests", "InvoiceClient - PostAsync")]
        [Fact(DisplayName = "PostAsync when send a invoice valid return OK")]
        public async Task PostAsync_WhenSendValidJson_ReturnsOk()
        {
            // Arrange
            var invoice = GenerateInvoiceToTest.Invoice();
            var mockHttp = TestHelper.CreateMockHttpPost(invoice.ToJson(), HttpMethod.Post);

            var invoiceClient = new InvoiceClient(mockHttp);

            // Act
            var result = await invoiceClient.PostAsync(TestHelper.companyId, TestHelper.apiKey, invoice, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ResultStatusCode.OK, result.Status);
            // Need to deserialize a invoiceResource to assert
            //ValidateHelper.ValidateInvoice(invoice, result.ValueAsSuccess);
        }
    }
}
