using nfe.api.client.Infraestructure;
using ServiceInvoice.Domain.Common;
using ServiceInvoice.Domain.Models;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Tests.UnitTests.Clients.Company
{
    public class CompanyClientGetOneAsyncTests
    {
        private readonly string _companyReturn;
        private readonly LegalPerson _company;

        public CompanyClientGetOneAsyncTests()
        {
            _companyReturn = File.ReadAllText(@"..\..\..\..\UnitTests\FileToTest\company-return-example.json");
            _company = GenerateObjectToTest.Company();
        }

        [Trait("Unit Tests", "CompanyClient - GetOneAsync")]
        [Fact(DisplayName = "GetOneAsync when send a company valid return OK")]
        public async Task GetOneAsync_WhenSendValidJson_ReturnsOk()
        {
            // Arrange
            var mockHttp = TestHelper.CreateMockHttp(HttpMethod.Get, _companyReturn);

            var companyClient = new CompanyClient(TestHelper.apiKey, mockHttp);

            // Act
            var result = await companyClient.GetOneAsync(TestHelper.companyId, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ResultStatusCode.OK, result.Status);
            ValidateHelper.ValidateCompany(_company, result.ValueAsSuccess);
        }

        [Trait("Unit Tests", "CompanyClient - GetOneAsync")]
        [Fact(DisplayName = "GetOneAsync test about exception")]
        public async Task GetOneAsync_WhenRequestResponseReturnNull_ReturnsError()
        {
            // Arrange
            var mockHttp = TestHelper.CreateMockHttpGet("testToException");

            var companyClient = new CompanyClient(TestHelper.apiKey, mockHttp.Object);

            // Act
            var result = await companyClient.GetOneAsync(TestHelper.apiKey, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ResultStatusCode.Error, result.Status);
        }

        [Trait("Unit Tests", "CompanyClient - GetOneAsync")]
        [Fact(DisplayName = "GetOneAsync when send invalid invoice return badRequest")]
        public async Task GetOneAsync_WhenSendInvalidInvoice_ReturnsBadRequest()
        {
            // Arrange
            var mockHttp = TestHelper.CreateMockHttp(HttpMethod.Post, httpStatusCode: HttpStatusCode.BadRequest);

            var companyClient = new CompanyClient(TestHelper.apiKey, mockHttp);

            // Act
            var result = await companyClient.GetOneAsync(TestHelper.apiKey, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ResultStatusCode.BadRequest, result.Status);
        }

        [Trait("Unit Tests", "CompanyClient - GetOneAsync")]
        [Fact(DisplayName = "GetOneAsync when send invalid apiKey return Unauthorized")]
        public async Task GetOneAsync_WhenSendInvalidApiKey_ReturnsUnauthorized()
        {
            // Arrange
            var mockHttp = TestHelper.CreateMockHttp(HttpMethod.Post, httpStatusCode: HttpStatusCode.Unauthorized);

            var companyClient = new CompanyClient("InvalidApiKey", mockHttp);

            // Act
            var result = await companyClient.GetOneAsync(TestHelper.apiKey, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ResultStatusCode.Unauthorized, result.Status);
        }

        [Trait("Unit Tests", "CompanyClient - GetOneAsync")]
        [Fact(DisplayName = "GetOneAsync when RequestTimeout return timeout")]
        public async Task GetOneAsync_WhenRequestTimeout_ReturnsTimeout()
        {
            // Arrange
            var mockHttp = TestHelper.CreateMockHttp(HttpMethod.Post, httpStatusCode: HttpStatusCode.RequestTimeout);

            var companyClient = new CompanyClient(TestHelper.apiKey, mockHttp);

            // Act
            var result = await companyClient.GetOneAsync(TestHelper.apiKey, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ResultStatusCode.TimedOut, result.Status);
        }

        [Trait("Unit Tests", "CompanyClient - GetOneAsync")]
        [Fact(DisplayName = "GetOneAsync when InternalServerError return error")]
        public async Task GetOneAsync_WhenInternalServerError_ReturnsError()
        {
            // Arrange
            var mockHttp = TestHelper.CreateMockHttp(HttpMethod.Post, httpStatusCode: HttpStatusCode.InternalServerError);

            var companyClient = new CompanyClient(TestHelper.apiKey, mockHttp);

            // Act
            var result = await companyClient.GetOneAsync(TestHelper.apiKey, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ResultStatusCode.Error, result.Status);
        }

        [Trait("Unit Tests", "CompanyClient - GetOneAsync")]
        [Theory(DisplayName = "GetOneAsync when send invalid invoice return badRequest")]
        [InlineData(default(HttpStatusCode))]
        [InlineData(HttpStatusCode.NotExtended)]
        [InlineData(HttpStatusCode.NotFound)]
        [InlineData(HttpStatusCode.NotAcceptable)]
        [InlineData(HttpStatusCode.RedirectKeepVerb)]
        [InlineData(HttpStatusCode.PreconditionFailed)]
        public async Task GetOneAsync_WhenHttpStatusCodeIsUnexpected_ReturnsError(HttpStatusCode status)
        {
            // Arrange
            var mockHttp = TestHelper.CreateMockHttp(HttpMethod.Post, httpStatusCode: status);

            var companyClient = new CompanyClient(TestHelper.apiKey, mockHttp);

            // Act
            var result = await companyClient.GetOneAsync(TestHelper.apiKey, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ResultStatusCode.Error, result.Status);
        }
    }
}
