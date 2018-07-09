using ServiceInvoice.Domain.Common;
using ServiceInvoice.Domain.Interfaces;
using ServiceInvoice.Domain.Models;
using System;
using System.Collections.Generic;
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
        private readonly string _apiKey;

        public InvoiceClient(string apiKey, HttpClient httpClient = null)
        {
            _httpClient = httpClient ?? new HttpClient();
            _httpClient.BaseAddress = new Uri("http://api.nfe.io");
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/pdf"));
            _apiKey = apiKey;
        }

        public async Task<Result<InvoiceResource>> PostAsync(string company_id, Invoice item, CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {
                var url = $"/v1/companies/{company_id}/serviceinvoices";
                _httpClient.DefaultRequestHeaders.Add("Authorization", _apiKey);

                var response = await _httpClient.PostAsync(url, new StringContent(item.ToJson(), Encoding.UTF8, "application/json"));

                var result = await HttpResponseConvert<InvoiceResource>.ResponseReadAsStringAsync(response);

                return result;
            }
            catch (Exception ex)
            {
                return new Result<InvoiceResource>(ResultStatusCode.Error, ex.Message);
            }
        }

        public async Task<Result<InvoiceResource>> GetOneAsync(string company_id, string invoiceId, CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {
                var url = $"/v1/companies/{company_id}/serviceinvoices/{invoiceId}";
                _httpClient.DefaultRequestHeaders.Add("Authorization", _apiKey);

                var response = await _httpClient.GetAsync(url, cancellationToken);

                var result = await HttpResponseConvert<InvoiceResource>.ResponseReadAsStringAsync(response);

                return result;
            }
            catch (Exception ex)
            {
                return new Result<InvoiceResource>(ResultStatusCode.Error, ex.Message);
            }
        }

        public Task<Result<InvoiceResource>> GetAsync(string company_id, int? pageCount, int? pageIndex, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public async Task<Result<string>> DeleteAsync(string company_id, string invoiceId, CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {
                var url = $"/v1/companies/{company_id}/serviceinvoices/{invoiceId}";
                _httpClient.DefaultRequestHeaders.Add("Authorization", _apiKey);

                var response = await _httpClient.DeleteAsync(url, cancellationToken);

                var result = await HttpResponseConvert<string>.ResponseReadAsStringAsync(response);

                return result;
            }
            catch (Exception ex)
            {
                return new Result<string>(ResultStatusCode.Error, ex.Message);
            }
        }

        public async Task<Result<string>> GetDocumentPdfUrlAsync(string company_id, string invoiceId, CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {
                var url = $"/v1/companies/{company_id}/serviceinvoices/{invoiceId}/pdf";
                _httpClient.DefaultRequestHeaders.Add("Authorization", _apiKey);

                var response = await _httpClient.GetAsync(url, cancellationToken);

                var result = await HttpResponseConvert<string>.ResponseReadAsByteAsync(response);

                return result;
            }
            catch (Exception ex)
            {
                return new Result<string>(ResultStatusCode.Error, ex.Message);
            }
        }

        public async Task<Result<byte[]>> GetDocumentPdfBytesAsync(string company_id, string invoiceId, CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {
                var url = $"/v1/companies/{company_id}/serviceinvoices/{invoiceId}/pdf";
                _httpClient.DefaultRequestHeaders.Add("Authorization", _apiKey);

                var response = await _httpClient.GetAsync(url, cancellationToken);

                var result = await HttpResponseConvert<byte[]>.ResponseReadAsByteAsync(response);

                return result;
            }
            catch (Exception ex)
            {
                return new Result<byte[]>(ResultStatusCode.Error, ex.Message);
            }
        }

        public Task<Result<string>> GetDocumentXmlAsync(string company_id, string invoiceId, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<Result<string>> SendEmailAsync(string company_id, string invoiceId, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }
    }
}
