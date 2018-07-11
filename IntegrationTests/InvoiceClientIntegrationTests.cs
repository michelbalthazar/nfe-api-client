using nfe.api.client.Infraestructure;
using ServiceInvoice.Domain.Common;
using ServiceInvoice.Domain.Models;
using System;
using System.IO;
using System.Threading;
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
        private readonly string _pathToSave;
        private readonly string _xmlToTest;

        public InvoiceClientIntegrationTests()
        {
            _settingsApp = new GetAppSettings();
            _companyIdSP = _settingsApp.Configuration["Authentication:CompanyId"];
            _invoiceId = _settingsApp.Configuration["Authentication:InvoiceId"];
            _pathToSave = _settingsApp.Configuration["Authentication:Path"];

            var apiKey = _settingsApp.Configuration["Authentication:ApiKey"];
            _client = new InvoiceClient(apiKey);

            _xmlToTest = File.ReadAllText(@"..\..\..\..\UnitTests\FileToTest\invoiceResource-Example.xml");
        }

        [Trait("Integration Tests", "InvoiceClient - PostAsync")]
        [Fact(DisplayName = "PostAsync when send a invoice valid return OK")]
        public async Task PostAsync_WhenSendValidJson_ReturnsOk()
        {
            // Arrange
            var item = GenerateInvoiceToTest.Invoice();

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
            var item = GenerateInvoiceToTest.Invoice();

            var resultPost = await _client.PostAsync(_companyIdSP, item);

            // waiting nfe.io's server change invoice's NotaFiscalFlowStatus property to ISSUED 
            Thread.Sleep(TimeSpan.FromSeconds(5));

            resultPost.ValueAsSuccess.FlowStatus = NotaFiscalFlowStatus.Issued;

            // Act
             var result = await _client.DeleteAsync(_companyIdSP, resultPost.ValueAsSuccess.Id);

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
            TestHelper.GeneratePdf(result.ValueAsSuccess, _pathToSave);

            // Assert
            byte[] bytes = System.IO.File.ReadAllBytes(_pathToSave);

            Assert.Equal(bytes, result.ValueAsSuccess);
        }

        [Trait("Integration Tests", "InvoiceClient - GetDocumentXmlAsync")]
        [Fact(DisplayName = "GetDocumentXmlAsync when send invoiceId valid return ok and save xml file")]
        public async Task GetDocumentXmlAsync_WhenSendInvoiceIdValid_ReturnsOk()
        {
            // Arrange

            // Act
            var result = await _client.GetDocumentXmlAsync(_companyIdSP, _invoiceId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ResultStatusCode.OK, result.Status);
        }

        [Trait("Integration Tests", "InvoiceClient - SendEmailAsync")]
        [Fact(DisplayName = "SendEmailAsync when send a invoice valid return OK")]
        public async Task SendEmailAsync_WhenSendValidJson_ReturnsOk()
        {
            // Arrange
            var item = GenerateInvoiceToTest.Invoice();

            var resultPost = await _client.PostAsync(_companyIdSP, item);

            // waiting nfe.io's server change invoice's NotaFiscalFlowStatus property to ISSUED 
            Thread.Sleep(TimeSpan.FromSeconds(5));

            resultPost.ValueAsSuccess.FlowStatus = NotaFiscalFlowStatus.Issued;

            // Act
            var result = await _client.SendEmailAsync(_companyIdSP, resultPost.ValueAsSuccess.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ResultStatusCode.OK, result.Status);
        }
    }
}
