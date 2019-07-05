using nfe.api.client.Domain.Interfaces;
using ServiceInvoice.Domain.Common;
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
    public class CompanyClient : ICompanyClient
    {
        private readonly HttpClient _httpClient;

        public CompanyClient(string apiKey, HttpClient httpClient = null)
        {
            _httpClient = httpClient ?? new HttpClient();
            _httpClient.BaseAddress = new Uri("http://api.nfe.io");
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Add("Authorization", apiKey);
        }

        public async Task<Result<LegalPerson>> PostAsync(LegalPerson item, CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {
                var url = $"/v1/companies";

                var response = await _httpClient.PostAsync(url, new StringContent(item.ToJson<LegalPerson>(), Encoding.UTF8, "application/json"), cancellationToken);

                var result = await HttpResponseConvert<LegalPerson>.ResponseReadAsStringAsync(response, true);

                return result;
            }
            catch (Exception ex)
            {
                return new Result<LegalPerson>(ResultStatusCode.Error, ex.Message);
            }
        }

        public async Task<Result<LegalPerson>> GetOneAsync(string company_id_or_tax_number, CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {
                var url = $"/v1/companies/{company_id_or_tax_number}";

                var response = await _httpClient.GetAsync(url, cancellationToken);

                var result = await HttpResponseConvert<LegalPerson>.ResponseReadAsStringAsync(response, true);

                return result;
            }
            catch (Exception ex)
            {
                return new Result<LegalPerson>(ResultStatusCode.Error, ex.Message);
            }
        }

        public Task<IEnumerable<Result<LegalPerson>>> GetAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<Result<LegalPerson>> PutAsync(string company_id, LegalPerson item, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public async Task<Result<LegalPerson>> DeleteAsync(string company_id, CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {
                var url = $"/v1/companies/{company_id}";

                var response = await _httpClient.DeleteAsync(url, cancellationToken);

                var result = await HttpResponseConvert<LegalPerson>.ResponseReadAsStringAsync(response);

                return result;
            }
            catch (Exception ex)
            {
                return new Result<LegalPerson>(ResultStatusCode.Error, ex.Message);
            }
        }

        public Task<Result<string>> CertificateUploadAsync(string company_id, byte[] file, string password, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }
    }
}
