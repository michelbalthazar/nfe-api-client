using nfe.api.client.Infraestructure;
using ServiceInvoice.Domain.Common;
using ServiceInvoice.Domain.Models;
using System.Threading.Tasks;
using Xunit;

namespace Tests.IntegrationTests
{
    public class InvoiceClientIntegrationTests
    {
        private readonly GetAppSettings _settingsApp = new GetAppSettings();

        [Fact]
        public async Task PostAsync_WhenSendValidJson_ReturnsOk()
        {
            // arrange
            var apiKey = _settingsApp.Configuration["Authentication:ApiKey"];
            var companyIdSP = _settingsApp.Configuration["Authentication:CompanyId"];
            var client = new InvoiceClient();
            //var invoice = new InvoiceService(client);
            var item = new Invoice
            {
                CityServiceCode = "3093",
                Description = "TESTE EMISSAO",
                ServicesAmount = 0.01,
                Borrower = new Borrower
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
                        City = new City { CityCode = "5300108", CityName = "Brasilia" },
                        State = "DF"
                    },
                },

            };

            // act
            var result = await client.PostAsync(companyIdSP, apiKey, item);

            // asser
            Assert.NotNull(result);
            Assert.Equal(ResultStatusCode.OK, result.Status);
        }
    }
}
