using nfe.api.client.Domain.Interfaces;
using ServiceInvoice.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace nfe.api.client.Infraestructure
{
    public class CompanyClient : ICompanyClient
    {
        public Task<LegalPerson> PostAsync(LegalPerson item, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<LegalPerson> GetOneAsync(string company_id_or_tax_number, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LegalPerson>> GetAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<LegalPerson> PutAsync(string company_id, LegalPerson item, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<object> DeleteAsync(string company_id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> CertificateUploadAsync(string company_id, byte[] file, string password, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
