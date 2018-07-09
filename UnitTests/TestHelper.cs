using Moq;
using ServiceInvoice.Domain.Models;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Tests.UnitTests
{
    public static class TestHelper
    {
        #region properties to tests
        public static string companyId = "companyToTest";
        public static string apiKey = "apiKeyToTest";
        #endregion

        public static Mock<HttpClient> CreateMockHttp(string response, HttpStatusCode httpStatusCode = HttpStatusCode.OK)
        {
            var responseMessage = new Mock<HttpResponseMessage>();
            responseMessage.Object.StatusCode = httpStatusCode;
            responseMessage.Object.Content = new FakeHttpContent(response);

            var messageHandler = new FakeHttpMessageHandler(responseMessage.Object);

            var mockHttpClient = new Mock<HttpClient>(messageHandler);

            return mockHttpClient;
        }
    }
    #region class to helper mock httpClient
    public class FakeHttpMessageHandler : HttpMessageHandler
    {
        private HttpResponseMessage response;

        public FakeHttpMessageHandler(HttpResponseMessage response)
        {
            this.response = response;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var responseTask = new TaskCompletionSource<HttpResponseMessage>();
            responseTask.SetResult(response);

            return responseTask.Task;
        }
    }

    public class FakeHttpContent : HttpContent
    {
        public string Content { get; set; }

        public FakeHttpContent(string content)
        {
            Content = content;
        }

        protected async override Task SerializeToStreamAsync(Stream stream, TransportContext context)
        {
            byte[] byteArray = Encoding.ASCII.GetBytes(Content);
            await stream.WriteAsync(byteArray, 0, Content.Length);
        }

        protected override bool TryComputeLength(out long length)
        {
            length = Content?.Length ?? 0;
            return true;
        }
    }
    #endregion

    #region class validate helper
    public static class ValidateHelper
    {
        public static void ValidateInvoice(Invoice expect, Invoice actual)
        {
            Assert.NotNull(expect);
            Assert.NotNull(actual);
            Assert.Equal(expect.CityServiceCode, actual.CityServiceCode);
            Assert.Equal(expect.Description, actual.Description);
            Assert.Equal(expect.EconomicActivitieCode, actual.EconomicActivitieCode);
            Assert.Equal(expect.FederalServiceCode, actual.FederalServiceCode);
            Assert.Equal(expect.ServicesAmount, actual.ServicesAmount);

            ValidateBorrower(expect.Borrower, actual.Borrower);
        }

        public static void ValidateBorrower(Borrower expect, Borrower actual)
        {
            Assert.NotNull(expect);
            Assert.NotNull(actual);
            Assert.Equal(expect.Email, actual.Email);
            Assert.Equal(expect.FederalTaxNumber, actual.FederalTaxNumber);
            Assert.Equal(expect.MunicipalTaxNumber, actual.MunicipalTaxNumber);
            Assert.Equal(expect.Name, actual.Name);
            Assert.Equal(expect.Type, actual.Type);
            Assert.Equal(expect.Address.AdditionalInformation, actual.Address.AdditionalInformation);
            Assert.Equal(expect.Address.City.Code, actual.Address.City.Code);
            Assert.Equal(expect.Address.City.Name, actual.Address.City.Name);
            Assert.Equal(expect.Address.Country, actual.Address.Country);
            Assert.Equal(expect.Address.District, actual.Address.District);
            Assert.Equal(expect.Address.Number, actual.Address.Number);
            Assert.Equal(expect.Address.PostalCode, actual.Address.PostalCode);
            Assert.Equal(expect.Address.State, actual.Address.State);
            Assert.Equal(expect.Address.Street, actual.Address.Street);
        }

        public static void ValidateIssuer(LegalPerson expect, LegalPerson actual)
        {
            Assert.NotNull(expect);
            Assert.NotNull(actual);
            Assert.Equal(expect.Email, actual.Email);
            Assert.Equal(expect.FederalTaxNumber, actual.FederalTaxNumber);
            Assert.Equal(expect.MunicipalTaxNumber, actual.MunicipalTaxNumber);
            Assert.Equal(expect.Name, actual.Name);
            Assert.Equal(expect.Type, actual.Type);
            Assert.Equal(expect.Address.AdditionalInformation, actual.Address.AdditionalInformation);
            Assert.Equal(expect.Address.City.Code, actual.Address.City.Code);
            Assert.Equal(expect.Address.City.Name, actual.Address.City.Name);
            Assert.Equal(expect.Address.Country, actual.Address.Country);
            Assert.Equal(expect.Address.District, actual.Address.District);
            Assert.Equal(expect.Address.Number, actual.Address.Number);
            Assert.Equal(expect.Address.PostalCode, actual.Address.PostalCode);
            Assert.Equal(expect.Address.State, actual.Address.State);
            Assert.Equal(expect.Address.Street, actual.Address.Street);
            Assert.Equal(expect.SpecialTaxRegime, actual.SpecialTaxRegime);
            Assert.Equal(expect.TaxRegime, actual.TaxRegime);
            Assert.Equal(expect.TradeName, actual.TradeName);
        }
    }
    #endregion
}
