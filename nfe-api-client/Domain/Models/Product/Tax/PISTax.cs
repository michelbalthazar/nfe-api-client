using System.ComponentModel.DataAnnotations;

namespace nfe.api.client.Domain.Models.Product.Tax
{
    public class PISTax
    {
        /// <summary>
        /// Código de Situação Tributária do PIS (CST)
        /// </summary>
        [Required]
        public string CST { get; set; }
        /// <summary>
        /// Valor da Base de Cálculo do PIS (vBC)
        /// </summary>
        public decimal? BaseTax { get; set; }
        /// <summary>
        /// Alíquota do PIS (em percentual) (pPIS)
        /// </summary>
        public decimal? Rate { get; set; }
        /// <summary>
        /// Valor do PIS (vPIS)
        /// </summary>
        public decimal? Amount { get; set; }

        /// <summary>
        /// Quantidade Vendida (qBCProd)
        /// </summary>
        public decimal? BaseTaxProductQuantity { get; set; }

        /// <summary>
        /// Alíquota do PIS (em reais) (vAliqProd)
        /// </summary>
        public decimal? ProductRate { get; set; }
    }
}