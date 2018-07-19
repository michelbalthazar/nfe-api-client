using nfe.api.client.Infraestructure;
using ServiceInvoice.Domain.Common;
using ServiceInvoice.Domain.Models;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Tests.UnitTests.Clients.Company
{
    public class CompanyClientPostAsyncTests
    {
        private readonly string _companyReturn;
        private readonly LegalPerson _company;

        public CompanyClientPostAsyncTests()
        {
            _companyReturn = File.ReadAllText(@"..\..\..\..\UnitTests\FileToTest\company-return-example.json");
            _company = GenerateObjectToTest.Company();
        }

        [Trait("Unit Tests", "CompanyClient - PostAsync")]
        [Fact(DisplayName = "PostAsync when send a company valid return OK")]
        public async Task PostAsync_WhenSendValidJson_ReturnsOk()
        {
            // Arrange
            var mockHttp = TestHelper.CreateMockHttp(HttpMethod.Post, _companyReturn);

            var companyClient = new CompanyClient(TestHelper.apiKey, mockHttp);

            // Act
            var result = await companyClient.PostAsync(_company, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ResultStatusCode.OK, result.Status);
            ValidateHelper.ValidateCompany(_company, result.ValueAsSuccess);
        }
    }
}
