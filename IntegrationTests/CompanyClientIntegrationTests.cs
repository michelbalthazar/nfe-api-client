using nfe.api.client.Infraestructure;
using ServiceInvoice.Domain.Common;
using ServiceInvoice.Domain.Models;
using System;
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
        private readonly string _companyReturn;
        private readonly CompanyClient _client;
        private readonly LegalPerson _company;

        public CompanyClientIntegrationTests()
        {
            _settingsApp = new GetAppSettings();
            _companyIdSP = _settingsApp.Configuration["Authentication:CompanyId"];

            var apiKey = _settingsApp.Configuration["Authentication:ApiKey"];
            _client = new CompanyClient(apiKey);

            _companyReturn = File.ReadAllText(@"..\..\..\..\UnitTests\FileToTest\companySP_example.json");
            _company = GenerateObjectToTest.Company();
        }

        [Trait("Integration Tests", "CompanyClient - PostAsync")]
        [Fact(DisplayName = "PostAsync when send a company valid return OK", Skip = "To create a company unskip this test")]
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

        [Trait("Integration Tests", "CompanyClient - GetOneAsync")]
        [Fact(DisplayName = "GetOneAsync when send a company valid return OK")]
        public async Task GetOneAsync_WhenCompanyIdIsValid_ReturnsOk()
        {
            // Arrange

            // Act
            var result = await _client.GetOneAsync(_companyIdSP);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ResultStatusCode.OK, result.Status);
            ValidateHelper.ValidateCompany(_companyReturn.JsonToObject<LegalPerson>(), result.ValueAsSuccess);
        }

        [Trait("Integration Tests", "CompanyClient - DeleteAsync")]
        [Fact(DisplayName = "DeleteAsync when send a company valid return Deleted")]
        public async Task DeleteAsync_WhenSendValidCompanyJson_ReturnsDeleted()
        {
            // Arrange
            var company = await _client.PostAsync(_company);

            // Act
            var result = await _client.DeleteAsync(company.ValueAsSuccess.Id);

            company = await _client.PostAsync(_company);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ResultStatusCode.OK, result.Status);
        }
    }
}