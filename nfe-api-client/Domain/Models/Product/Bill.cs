namespace nfe.api.client.Domain.Models.Product
{
    public class Bill
    {
        /// <summary>
        /// Número da Fatura (nFat)
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Valor Original da Fatura (vOrig)
        /// </summary>
        public decimal? OriginalAmount { get; set; }

        /// <summary>
        /// Valor do desconto (vDesc)
        /// </summary>
        public decimal? DiscountAmount { get; set; }

        /// <summary>
        /// Valor Líquido da Fatura (vLiq)
        /// </summary>
        public decimal? NetAmount { get; set; }
    }
}