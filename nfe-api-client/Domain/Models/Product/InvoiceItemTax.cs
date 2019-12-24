using nfe.api.client.Domain.Models.Product.Tax;
using System.ComponentModel.DataAnnotations;

namespace nfe.api.client.Domain.Models.Product
{
    public class InvoiceItemTax
    {
        /// <summary>
        /// Valor aproximado total de tributos federais, estaduais e municipais (vTotTrib)
        /// </summary>
        [Required]
        public decimal TotalTax { get; set; }
        [Required]
        public IcmsTax ICMS { get; set; }
        public IPITax IPI { get; set; }
        public IITax II { get; set; }
        [Required]
        public PISTax PIS { get; set; }
        [Required]
        public CofinsTax COFINS { get; set; }
        public ICMSUFDestination ICMSDestination { get; set; }
    }
}