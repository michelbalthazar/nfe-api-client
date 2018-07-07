using Newtonsoft.Json;

namespace ServiceInvoice.Domain.Models
{
    /// <summary>
    /// <summary>Tomador do serviço</summary>
    /// </summary>
    public class Borrower : Person
    {
        /// <summary>
        /// Inscrição Municipal para Pessoas Jurídicas
        /// </summary>
        public string MunicipalTaxNumber { get; set; }

        public static Borrower Create(string name, long federalTaxNumber, string email, Address address)
        {
            return new Borrower
            {
                Name = name,
                FederalTaxNumber = federalTaxNumber,
                Email = email,
                Address = address
            };
        }

        public virtual bool IsLegalPerson()
        {
            return Person.IsLegalPerson(this.FederalTaxNumber.Value);
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static Borrower FromJson(string data)
        {
            return JsonConvert.DeserializeObject<Borrower>(data);
        }
    }
}
