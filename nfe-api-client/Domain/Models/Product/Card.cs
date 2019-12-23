using ServiceInvoice.Domain.Models;

namespace nfe.api.client.Domain.Models.Product
{
    public class Card
    {
        /// <summary>
        /// CNPJ da Credenciadora de cartão de crédito e/ou débito (CNPJ)
        /// </summary>
        public string FederalTaxNumber { get; set; }

        /// <summary>
        /// Bandeira da operadora de cartão de crédito e/ou débito (tBand)
        /// <remarks>
        ///     01 - Visa (Visa)
        ///     02 - Mastercard (Mastercard)
        ///     03 - AmericanExpress (AmericanExpress)
        ///     04 - Sorocred (Sorocred)
        ///     99 - Other (Other)
        /// </remarks>
        /// </summary>
        public FlagCard Flag { get; set; }

        /// <summary>
        ///Número de autorização da operação cartão de crédito e/ou débito (cAut)
        /// </summary>
        public string Authorization { get; set; }

        /// <summary>
        ///     YA04a - Tipo de Integração para pagamento (tpIntegra)
        ///     <remarks>
        ///     01 - Integrado (Integrated)
        ///     02 - Não Integrado (NotIntegrated)
        ///     </remarks>
        /// </summary>
        public IntegrationPaymentType IntegrationPaymentType { get; set; }
    }
}