using ServiceInvoice.Domain.Common;
using ServiceInvoice.Domain.Interfaces;
using ServiceInvoice.Domain.Models;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace nfe.api.client.Infraestructure
{
    public class InvoiceClient : IInvoiceClient
    {
        private readonly HttpClient _httpClient;

        public InvoiceClient(HttpClient httpClient = null)
        {
            _httpClient = httpClient ?? new HttpClient();
        }
        public Task<Result<Invoice>> PostAsync(string company_id, string apiKey, Invoice item, CancellationToken cancellationToken)
        {
            var err = new ErrorBuilder();

            return null;
        }

        public Task<Result<Invoice>> GetOneAsync(string company_id, string id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Result<Invoice>> GetAsync(string company_id, int? pageCount, int? pageIndex, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Result<string>> DeleteAsync(string company_id, string id, string api_Key, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Result<string>> GetDocumentPdfAsync(string company_id, string id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Result<string>> GetDocumentXmlAsync(string company_id, string id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Result<string>> SendEmailAsync(string company_id, string id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
