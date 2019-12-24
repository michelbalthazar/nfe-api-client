namespace nfe.api.client.Domain.Models.Product.Tax
{
    public class IPITax
    {
        /// <summary>
        /// clEnq
        /// Classe de enquadramento do IPI para Cigarros e Bebidas (clEnq)
        /// </summary>
        public string Classification { get; set; }

        /// <summary>
        /// CNPJ do produtor da mercadoria, quando diferente do emitente. Somente para os casos de exportação direta ou indireta (CNPJProd)
        /// </summary>
        public string ProducerCNPJ { get; set; }

        /// <summary>
        /// Código do selo de controle IPI (cSelo)
        /// </summary>
        public string StampCode { get; set; }

        /// <summary>
        /// Quantidade de selo de controle (qSelo)
        /// </summary>
        public decimal? StampQuantity { get; set; }

        /// <summary>
        /// Código de Enquadramento Legal do IPI (cEnq)
        /// </summary>
        public string ClassificationCode { get; set; }

        /// <summary>
        /// Código da situação tributária do IPI (CST)
        /// </summary>
        public string CST { get; set; }

        /// <summary>
        /// Valor da BC do IPI (vBC)
        /// </summary>
        public decimal? Base { get; set; }

        /// <summary>
        /// Alíquota do IPI (pIPI)
        /// </summary>
        public decimal? Rate { get; set; }

        /// <summary>
        /// Quantidade total na unidade padrão para tributação (somente para os produtos tributados por unidade) (qUnid)
        /// </summary>
        public decimal? UnitQuantity { get; set; }

        /// <summary>
        /// Valor por Unidade Tributável (vUnid)
        /// </summary>
        public decimal? UnitAmount { get; set; }

        /// <summary>
        /// Valor IPI (vIPI)
        /// </summary>
        public decimal? Amount { get; set; }
    }
}