]
namespace nfe.api.client.Domain.Models.Product
{
    public class Payment
    {
        /// <summary>
        /// YA01a - Grupo Detalhamento da Forma de Pagamento (detPag)
        /// VERSÃO 4.00
        /// </summary>
        public List<PaymentDetailResource> PaymentDetail { get; set; }

        /// <summary>
        /// Valor do troco (vTroco)
        /// VERSÃO 4.00
        /// </summary>
        public decimal? PayBack { get; set; }
    }
}