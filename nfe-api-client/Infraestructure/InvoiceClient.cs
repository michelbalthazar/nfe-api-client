using ServiceInvoice.Domain.Common;
using ServiceInvoice.Domain.Interfaces;
using ServiceInvoice.Domain.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
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
            _httpClient.BaseAddress = new Uri("http://api.nfe.io");
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

        public async Task<Result<InvoiceResource>> PostAsync(string company_id, string apiKey, Invoice item, CancellationToken cancellationToken = default(CancellationToken))
        {
            var url = $"/v1/companies/{company_id}/serviceinvoices";
            _httpClient.DefaultRequestHeaders.Add("Authorization", apiKey);

            var response = await _httpClient.PostAsync(url, new StringContent(item.ToJson(), Encoding.UTF8, "application/json"));

            var result = await HttpResponseCheck.ResponseValidate(response);

            return result;
        }

        public Task<Result<InvoiceResource>> GetOneAsync(string company_id, string id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Result<InvoiceResource>> GetAsync(string company_id, int? pageCount, int? pageIndex, CancellationToken cancellationToken)
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
