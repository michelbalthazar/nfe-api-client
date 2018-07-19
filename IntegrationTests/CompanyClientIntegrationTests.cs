using nfe.api.client.Infraestructure;
using ServiceInvoice.Domain.Common;
using ServiceInvoice.Domain.Models;
using System.IO;
using System.Threading.Tasks;
using Tests.UnitTests;
using Xunit;

namespace Tests.IntegrationTests
{
    public class CompanyClientIntegrationTests
    {
        private readonly GetAppSettings _settingsApp;
        private readonly string _companyIdSP;
        private readonly CompanyClient _client;
        private readonly LegalPerson _company;

        public CompanyClientIntegrationTests()
        {
            _settingsApp = new GetAppSettings();
            _companyIdSP = _settingsApp.Configuration["Authentication:CompanyId"];

            var apiKey = _settingsApp.Configuration["Authentication:ApiKey"];
            _client = new CompanyClient(apiKey);

            _company = GenerateObjectToTest.Company();
        }

        [Trait("Integration Tests", "CompanyClient - PostAsync")]
        [Fact(DisplayName = "PostAsync when send a company valid return OK")]
        public async Task PostAsync_WhenSendValidCompanyJson_ReturnsOk()
        {
            // Arrange

            // Act
            var result = await _client.PostAsync(_company);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ResultStatusCode.OK, result.Status);
            ValidateHelper.ValidateCompany(_company, result.ValueAsSuccess);
        }

    }
}
