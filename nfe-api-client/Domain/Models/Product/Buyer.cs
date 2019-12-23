using ServiceInvoice.Domain.Models;

namespace nfe.api.client.Domain.Models.Product
{
    public class Buyer : Person
    {
        /// <summary>
        /// Indicador Inscrição Estadual (indIEDest)
        /// <remarks>
        ///     0 - Nenhum (None)
        ///     1 - Contribuinte ICMS - informar a IE do destinatário (TaxPayer)
        ///     2 - Contribuinte isento de Inscrição no cadastro de Contribuintes (Exempt)
        ///     9 - Não Contribuinte, que pode ou não possuir Inscrição Estadual no Cadastro de Contribuintes do ICMS (NonTaxPayer)
        /// </remarks>
        /// </summary>
        public ReceiverStateTaxIndicator StateTaxNumberIndicator { get; set; }
        /// <summary>
        /// Nome fantasia
        /// </summary>
        public string TradeName { get; set; }
        /// <summary>
        /// Regime de tributação
        /// <remarks>
        ///     0 - Nenhum (None)
        ///     2 - LucroReal (LucroReal)
        ///     4 - LucroPresumido (LucroPresumido)
        ///     8 - SimplesNacional (SimplesNacional)
        ///     16 - MicroempreendedorIndividual (MicroempreendedorIndividual)
        ///     32 - Isento (Isento)
        /// </remarks>
        /// </summary>
        public TaxRegime TaxRegime { get; set; }
        /// <summary>
        /// Inscrição Estadual (IE)
        /// </summary>
        public string StateTaxNumber { get; set; }
    }
}