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

        [Trait("Unit Tests", "CompanyClient - PostAsync")]
        [Fact(DisplayName = "PostAsync test about exception")]
        public async Task PostAsync_WhenRequestResponseReturnNull_ReturnsError()
        {
            // Arrange
            var mockHttp = TestHelper.CreateMockHttpGet("testToException");

            var companyClient = new CompanyClient(TestHelper.apiKey, mockHttp.Object);

            // Act
            var result = await companyClient.PostAsync(_company, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ResultStatusCode.Error, result.Status);
            Assert.Equal("Object reference not set to an instance of an object.", result.Value.ToString());
        }

        [Trait("Unit Tests", "CompanyClient - PostAsync")]
        [Fact(DisplayName = "PostAsync when send invalid invoice return badRequest")]
        public async Task PostAsync_WhenSendInvalidInvoice_ReturnsBadRequest()
        {
            // Arrange
            var mockHttp = TestHelper.CreateMockHttp(HttpMethod.Post, httpStatusCode: HttpStatusCode.BadRequest);

            var companyClient = new CompanyClient(TestHelper.apiKey, mockHttp);

            // Act
            var result = await companyClient.PostAsync(_company, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ResultStatusCode.BadRequest, result.Status);
        }

        [Trait("Unit Tests", "CompanyClient - PostAsync")]
        [Fact(DisplayName = "PostAsync when send invalid apiKey return Unauthorized")]
        public async Task PostAsync_WhenSendInvalidApiKey_ReturnsUnauthorized()
        {
            // Arrange
            var mockHttp = TestHelper.CreateMockHttp(HttpMethod.Post, httpStatusCode: HttpStatusCode.Unauthorized);

            var companyClient = new CompanyClient("InvalidApiKey", mockHttp);

            // Act
            var result = await companyClient.PostAsync(_company, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ResultStatusCode.Unauthorized, result.Status);
        }

        [Trait("Unit Tests", "CompanyClient - PostAsync")]
        [Fact(DisplayName = "PostAsync when RequestTimeout return timeout")]
        public async Task PostAsync_WhenRequestTimeout_ReturnsTimeout()
        {
            // Arrange
            var mockHttp = TestHelper.CreateMockHttp(HttpMethod.Post, httpStatusCode: HttpStatusCode.RequestTimeout);

            var companyClient = new CompanyClient(TestHelper.apiKey, mockHttp);

            // Act
            var result = await companyClient.PostAsync(_company, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ResultStatusCode.TimedOut, result.Status);
        }

        [Trait("Unit Tests", "CompanyClient - PostAsync")]
        [Fact(DisplayName = "PostAsync when InternalServerError return error")]
        public async Task PostAsync_WhenInternalServerError_ReturnsError()
        {
            // Arrange
            var mockHttp = TestHelper.CreateMockHttp(HttpMethod.Post, httpStatusCode: HttpStatusCode.InternalServerError);

            var companyClient = new CompanyClient(TestHelper.apiKey, mockHttp);

            // Act
            var result = await companyClient.PostAsync(_company, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ResultStatusCode.Error, result.Status);
        }

        [Trait("Unit Tests", "CompanyClient - PostAsync")]
        [Theory(DisplayName = "PostAsync when send invalid invoice return badRequest")]
        [InlineData(default(HttpStatusCode))]
        [InlineData(HttpStatusCode.NotExtended)]
        [InlineData(HttpStatusCode.NotFound)]
        [InlineData(HttpStatusCode.NotAcceptable)]
        [InlineData(HttpStatusCode.RedirectKeepVerb)]
        [InlineData(HttpStatusCode.PreconditionFailed)]
        public async Task PostAsync_WhenHttpStatusCodeIsUnexpected_ReturnsError(HttpStatusCode status)
        {
            // Arrange
            var mockHttp = TestHelper.CreateMockHttp(HttpMethod.Post, httpStatusCode: status);

            var companyClient = new CompanyClient(TestHelper.apiKey, mockHttp);

            // Act
            var result = await companyClient.PostAsync(_company, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ResultStatusCode.Error, result.Status);
        }
    }
}
