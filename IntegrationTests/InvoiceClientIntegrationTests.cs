using nfe.api.client.Infraestructure;
using ServiceInvoice.Domain.Common;
using ServiceInvoice.Domain.Models;
using System.Threading.Tasks;
using Tests.UnitTests;
using Xunit;

namespace Tests.IntegrationTests
{
    public class InvoiceClientIntegrationTests
    {
        private readonly GetAppSettings _settingsApp;
        private readonly string _companyIdSP;
        private readonly InvoiceClient _client;
        private readonly string _invoiceId;
        private string _pathToSave;

        public InvoiceClientIntegrationTests()
        {
            _settingsApp = new GetAppSettings();
            _companyIdSP = _settingsApp.Configuration["Authentication:CompanyId"];
            _invoiceId = _settingsApp.Configuration["Authentication:InvoiceId"];
            _pathToSave = _settingsApp.Configuration["Authentication:Path"];

            var apiKey = _settingsApp.Configuration["Authentication:ApiKey"];
            _client = new InvoiceClient(apiKey);
        }

        [Trait("Integration Tests", "InvoiceClient - PostAsync")]
        [Fact(DisplayName = "PostAsync when send a invoice valid return OK")]
        public async Task PostAsync_WhenSendValidJson_ReturnsOk()
        {
            // Arrange
            var item = new Invoice
            {
                CityServiceCode = "3093",
                Description = "TESTE EMISSAO",
                ServicesAmount = 0.01,
                Borrower = new Person
                {
                    FederalTaxNumber = 191,
                    Name = "BANCO DO BRASIL SA",
                    Email = "email@remetente",
                    Address = new Address
                    {
                        Country = "BRA",
                        PostalCode = "70073901",
                        Street = "Outros Quadra 1 Bloco G Lote 32",
                        Number = "S/N",
                        AdditionalInformation = "QUADRA 01 BLOCO G",
                        District = "Asa Sul",
                        City = new City { Code = "5300108", Name = "Brasilia" },
                        State = "DF"
                    },
                },

            };

            // Act
            var result = await _client.PostAsync(_companyIdSP, item);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ResultStatusCode.OK, result.Status);
        }

        [Trait("Integration Tests", "InvoiceClient - GetAsync")]
        [Fact(DisplayName = "GetAsync when send invoiceId valid return OK")]
        public async Task GetAsync_WhenSendInvoiceIdValid_ReturnsOk()
        {
            // Arrange

            // Act
            var result = await _client.GetOneAsync(_companyIdSP, _invoiceId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ResultStatusCode.OK, result.Status);
        }

        [Trait("Integration Tests", "InvoiceClient - DeleteAsync")]
        [Fact(DisplayName = "DeleteAsync when send invoiceId valid return OK")]
        public async Task DeleteAsync_WhenSendInvoiceIdValid_ReturnsOk()
        {
            // Arrange

            // Act
            var result = await _client.DeleteAsync(_companyIdSP, _invoiceId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ResultStatusCode.OK, result.Status);
        }

        [Trait("Integration Tests", "InvoiceClient - GetDocumentPdfAsync")]
        [Fact(DisplayName = "GetDocumentPdfAsync when send invoiceId valid return ok and save pdf file")]
        public async Task GetDocumentPdfAsync_WhenSendInvoiceIdValid_ReturnsOk()
        {
            // Arrange

            // Act
            var result = await _client.GetDocumentPdfBytesAsync(_companyIdSP, _invoiceId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ResultStatusCode.OK, result.Status);

            // save to see pdf
            TestHelper.GeneratePdf(result.ValueAsSuccess, _invoiceId, _pathToSave);

            // Assert
            byte[] bytes = System.IO.File.ReadAllBytes($"{_pathToSave}\\nfe-io.pdf");

            Assert.Equal(bytes, result.ValueAsSuccess);
        }
    }
}
