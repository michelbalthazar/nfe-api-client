namespace ServiceInvoice.Domain.Models
{
    public class Address
    {
        /// <summary>
        /// Estado
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Nome da Cidade
        /// </summary>
        public string CityName { get; set; }

        /// <summary>
        /// Código IBGE da Cidade
        /// </summary>
        public string CityCode { get; set; }

        /// <summary>
        /// Bairro (xBairro)
        /// </summary>
        public string District { get; set; }

        /// <summary>
        /// Complemento (xCpl)
        /// </summary>
        public string AdditionalInformation { get; set; }

        /// <summary>
        /// Logradouro do Endereco
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// Número (nro)
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Código Endereço Postal (CEP)
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// País
        /// </summary>
        public virtual string Country { get; set; }
    }
}
