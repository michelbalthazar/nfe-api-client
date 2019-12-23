namespace nfe.api.client.Domain.Models.Product
{
    public class TaxDocumentsReference
    {
        public TaxCouponInformation TaxCouponInformation { get; set; }
        public DocumentInvoiceReference DocumentInvoiceReference { get; set; }

        public DocumentElectronicInvoice DocumentElectronicInvoice { get; set; }
    }

    public class TaxCouponInformation
    {
        /// Informações do Cupom Fiscal

        /// <summary>
        /// Modelo de Documento Fiscal (mod)
        /// </summary>
        public string ModelDocumentFiscal { get; set; }

        /// <summary>
        /// Número de Ordem Sequencial do ECF (nECF)
        /// </summary>
        public string OrderECF { get; set; }

        /// <summary>
        /// Número do Contador de Ordem de Operação (nCOO)
        /// </summary>
        public int OrderCountOperation { get; set; }
    }

    public class DocumentInvoiceReference
    {
        /// Nota Fiscal

        /// <summary>
        /// Código da UF (cUF)
        /// </summary>
        public decimal? State { get; set; }

        /// <summary>
        /// Ano / Mês (AAMM)
        /// </summary>
        public string YearMonth { get; set; }

        /// <summary>
        /// CNPJ (CNPJ)
        /// </summary>
        public string FederalTaxNumber { get; set; }

        /// <summary>
        /// Modelo (mod)
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Série (serie)
        /// </summary>
        public string Series { get; set; }

        /// <summary>
        /// Número (nNF)
        /// </summary>
        public string Number { get; set; }
    }

    public class DocumentElectronicInvoice
    {
        ///Nota Fiscal Eletrônica

        /// <summary>
        /// Chave de Acesso (refNFe)
        /// </summary>
        public string AccessKey { get; set; }

    }
}