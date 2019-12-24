using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace nfe.api.client.Domain.Models.Product
{
    public class InvoiceItem
    {
        /// <summary>
        /// Código do produto ou serviço (cProd)
        /// </summary>
        [Required]
        public string Code { get; set; }

        /// <summary>
        /// GTIN (Global Trade Item Number) do produto, 
        /// antigo código EAN ou código de barras (cEAN)
        /// </summary>
        [Required]
        public string CodeGTIN { get; set; }

        /// <summary>
        /// Descrição do produto ou serviço (xProd)
        /// </summary>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Código NCM com 8 dígitos ou 2 dígitos (gênero) (NCM)
        /// </summary>
        [Required]
        public string NCM { get; set; }

        /// <summary>
        /// EX_TIPI (EXTIPI)
        /// </summary>
        //public string EXTIPI { get; set; }

        /// <summary>
        /// Código Fiscal de Operações e Prestações (CFOP)
        /// </summary>
        [Required]
        public long CFOP { get; set; }

        /// <summary>
        /// Unidade Comercial (uCom)
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// Quantidade Comercial (qCom)
        /// </summary>
        [Required]
        public decimal Quantity { get; set; }

        /// <summary>
        /// Valor Unitário de Comercialização (vUnCom)
        /// </summary>
        [Required]
        public decimal UnitAmount { get; set; }

        /// <summary>
        /// Valor Total Bruto dos Produtos ou Serviços (vProd)
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Unidade Tributável (uTrib)
        /// </summary>
        public string UnitTax { get; set; }

        /// <summary>
        /// Quantidade Tributável (qTrib)
        /// </summary>
        public decimal QuantityTax { get; set; }

        /// <summary>
        /// Valor Unitário de tributação (vUnTrib)
        /// </summary>
        public decimal TaxUnitAmount { get; set; }

        /// <summary>
        /// Valor Total do Frete (vFrete)
        /// </summary>
        public decimal? FreightAmount { get; set; }

        /// <summary>
        /// Valor Total do Seguro (vSeg)
        /// </summary>
        public decimal? InsuranceAmount { get; set; }

        /// <summary>
        /// Valor do Desconto (vDesc)
        /// </summary>
        public decimal? DiscountAmount { get; set; }

        /// <summary>
        /// Outras despesas acessórias (vOutro)
        /// </summary>
        public decimal? OthersAmount { get; set; }

        /// <summary>
        /// Indica se valor do Item (vProd) 
        /// entra no valor total da NF-e (vProd) (indTot)
        /// </summary>
        public bool TotalIndicator { get; set; }

        /// <summary>
        /// CEST - Código especificador da substituição tributária
        /// </summary>
        [Required]
        public string CEST { get; set; }

        /// <summary>
        /// Tributos incidentes no Produto ou Serviço (imposto)
        /// </summary>
        [Required]
        public InvoiceItemTax Tax { get; set; }

        /// <summary>
        /// Informações Adicionais do Produto (infAdProd)
        /// </summary>
        public string AdditionalInformation { get; set; }

        /// <summary>
        /// Número do pedido de compra (xPed)
        /// </summary>
        public string NumberOrderBuy { get; set; }

        /// <summary>
        /// Item do Pedido de Compra (nItemPed)
        /// </summary>
        public int? ItemNumberOrderBuy { get; set; }

        /// <summary>
        /// Detalhamento de Combustível (comb)
        /// </summary>
        public Fuel FuelDetail { get; set; }

        /// <summary>
        /// Código de Benefício Fiscal na UF aplicado ao item (cBenef)
        /// </summary>
        public string Benefit { get; set; }

        /// <summary>
        /// Declaração Importação (DI)
        /// </summary>
        public IEnumerable<ImportDeclaration> ImportDeclarations { get; set; }
    }
}