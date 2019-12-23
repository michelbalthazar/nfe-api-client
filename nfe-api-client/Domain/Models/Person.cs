using Brazil.Data;
using Newtonsoft.Json;
using System;
using System.Text.RegularExpressions;

namespace ServiceInvoice.Domain.Models
{
    public class Person
    {
        #region properties
        public string ParentId { get; set; }
        /// <summary>
        /// Código de identificação
        /// </summary>
        public string Id { get; set; }
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
        /// <summary>
        /// Data de criação
        /// </summary>
        public DateTime CreatedOn { get; set; }
        /// <summary>
        /// Data de modificação
        /// </summary>
        public DateTime modifiedOn { get; set; }
        /// <summary>
        /// Status do cadastro no sistema (Ativa ou Inativa)
        /// </summary>
        public Status Status { get; set; }
        #endregion properties

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

        #endregion helpers methods
    }
}