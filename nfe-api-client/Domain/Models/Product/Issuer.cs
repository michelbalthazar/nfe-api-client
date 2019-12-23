using ServiceInvoice.Domain.Models;

namespace nfe.api.client.Domain.Models.Product
{
    public class Issuer : LegalPerson
    {
        /// <summary>
        /// IE do Substituto Tributário (IEST)
        /// </summary>
        public string STStateTaxNumber { get; set; }

        public Issuer() { } 
    }
}