using Brazil.Data;
using System;
using System.Text.RegularExpressions;

namespace ServiceInvoice.Domain.Models
{
    public class Person
    {
        /// <summary>
        /// Nome ou Razão Social
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// CNPJ ou CPF
        /// </summary>
        public long? FederalTaxNumber { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Endereço
        /// </summary>
        public Address Address { get; set; }

        /// <summary>
        /// Tipo da pessoa: Jurídica ou Física
        /// </summary>
        public PersonType Type { get; set; }

        #region helpers methods
        public static readonly Lazy<Regex> CheckLegalFederalTaxNumber =
                new Lazy<Regex>(() => new Regex("(\\/0\\d\\d\\d)|(\\/00\\d\\d)|(\\/000\\d)", RegexOptions.Compiled));

        public static bool IsLegalPerson(long taxNumber)
        {
            return taxNumber > 0 &&
                   Cnpj.Validate(taxNumber) &&
                   CheckLegalFederalTaxNumber.Value.IsMatch(taxNumber.ToString(Cnpj.Format));
        }

        public bool IsLegalPerson()
        {
            return (this.Type & PersonType.LegalEntity) == PersonType.LegalEntity;
        }

        public Borrower ToBorrower()
        {
            return new Borrower()
            {
                Name = this.Name,
                FederalTaxNumber = this.FederalTaxNumber.GetValueOrDefault(),
                Email = this.Email,
                Address = this.Address
            };
        }
        #endregion helpers methods
    }
}
