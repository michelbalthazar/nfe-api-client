using System.ComponentModel.DataAnnotations;

namespace nfe.api.client.Domain.Models.Product.Tax
{
    public class CofinsTax
    {
        /// <summary>
        /// Código de Situação Tributária da COFINS
        /// </summary>
        [Required]
        public string CST { get; set; }

        /// <summary>
        /// Valor da Base de Cálculo da COFINS (vBC)
        /// </summary>
        public decimal? BaseTax { get; set; }

        /// <summary>
        /// Alíquota da COFINS (em percentual) (pCOFINS)
        /// </summary>
        public decimal? Rate { get; set; }

        /// <summary>
        /// Valor da COFINS (vCOFINS)
        /// </summary>
        public decimal? Amount { get; set; }

        /// <summary>
        /// Quantidade Vendida (qBCProd)
        /// </summary>
        public decimal? BaseTaxProductQuantity { get; set; }

        /// <summary>
        /// Alíquota da COFINS (em reais) (vAliqProd)
        /// </summary>
        public decimal? ProductRate { get; set; }
    }
}