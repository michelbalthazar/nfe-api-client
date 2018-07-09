namespace ServiceInvoice.Domain.Models
{
    /// <summary>
    /// Emitente da NFS-e
    /// </summary>
    public class LegalPerson : Person
    {
        /// <summary>
        /// Nome Fantasia (esse nome será usado no assunto do e-mail)
        /// </summary>
        public string TradeName { get; set; }

        /// <summary>
        /// Inscrição Municipal para Pessoas Jurídicas
        /// </summary>
        public string MunicipalTaxNumber { get; set; }

        /// <summary>
        /// Regime de tributação
        /// </summary>
        public TaxRegime TaxRegime { get; set; }

        /// <summary>
        /// Regime especial de tributação
        /// </summary>
        public SpecialTaxRegime SpecialTaxRegime { get; set; }

        public 
    }
}
