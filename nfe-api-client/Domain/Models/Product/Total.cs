namespace nfe.api.client.Domain.Models.Product
{
    public class Total
    {
        public ICMSTotal ICMS { get; set; }
    }

    /// <summary>
    /// Grupo de Valores Totais referentes ao ICMS
    /// </summary>
    public class ICMSTotal
    {
        /// <summary>
        /// Base de Cálculo do ICMS (vBC)
        /// </summary>
        public decimal? BaseTax { get; set; }

        /// <summary>
        /// Valor Total do ICMS (vICMS)
        /// </summary>
        public decimal? ICMSAmount { get; set; }

        /// <summary>
        /// Valor ICMS Total desonerado (vICMSDeson)
        /// </summary>
        public decimal? ICMSExemptAmount { get; set; }

        /// <summary>
        /// Base de Cálculo do ICMS Substituição Tributária (vBCST)
        /// </summary>
        public decimal? STCalculationBasisAmount { get; set; }

        /// <summary>
        /// Valor Total do ICMS ST (vST)
        /// </summary>
        public decimal? STAmount { get; set; }

        /// <summary>
        /// Valor Total dos produtos e serviços (vProd)
        /// </summary>
        public decimal ProductAmount { get; set; }

        /// <summary>
        /// Valor Total do Frete (vFrete)
        /// </summary>
        public decimal? FreightAmount { get; set; }

        /// <summary>
        /// Valor Total do Seguro (vSeg)
        /// </summary>
        public decimal? InsuranceAmount { get; set; }

        /// <summary>
        /// Valor Total do Desconto (vDesc)
        /// </summary>
        public decimal? DiscountAmount { get; set; }

        /// <summary>
        /// Valor Total do Imposto de Importação (vII)
        /// </summary>
        public decimal? IIAmount { get; set; }

        /// <summary>
        /// Valor Total do IPI (vIPI)
        /// </summary>
        public decimal? IPIAmount { get; set; }

        /// <summary>
        /// Valor do PIS (vPIS)
        /// </summary>
        public decimal? PISAmount { get; set; }

        /// <summary>
        /// Valor do COFINS (vCOFINS)
        /// </summary>
        public decimal? COFINSAmount { get; set; }

        /// <summary>
        /// Outras Despesas acessórias (vOutro)
        /// </summary>
        public decimal? OthersAmount { get; set; }

        /// <summary>
        /// Valor Total da NF-e (vNF)
        /// </summary>
        public decimal InvoiceAmount { get; set; }

        /// <summary>
        /// Valor Total ICMS FCP UF Destino (vFCPUFDest)
        /// </summary>
        public decimal? FCPUFDestinationAmount { get; set; }

        /// <summary>
        /// Valor Total ICMS Interestadual UF Destino (vICMSUFDest)
        /// </summary>
        public decimal? ICMSUFDestinationAmount { get; set; }

        /// <summary>
        /// Valor Total ICMS Interestadual UF Remetente (vICMSUFRemet)
        /// </summary>
        public decimal? ICMSUFSenderAmount { get; set; }

        /// <summary>
        /// Valor aproximado total de tributos federais, estaduais e municipais. (vTotTrib)
        /// </summary>
        public decimal FederalTaxesAmount { get; set; }

        // Additional fields for NFE 4.0

        /// <summary>
        /// Valor Total do FCP - Valor do ICMS relativo ao Fundo de Combate à Pobreza (vFCP)
        /// </summary>
        public decimal? FCPAmount { get; set; }

        /// <summary>
        /// Valor Total do FCP retido por ST - Valor do ICMS relativo ao Fundo de Combate à Pobreza retido por substituição tributária (vFCP)
        /// </summary>
        public decimal? FCPSTAmount { get; set; }

        /// <summary>
        /// Valor Total do FCP retido por anteriormente por ST - Valor do ICMS relativo ao Fundo de Combate à Pobreza retido anteriormente por substituição tributária (vFCP)
        /// </summary>
        public decimal? FCPSTRetAmount { get; set; }

        /// <summary>
        /// Valor total do IPI devolvido (vIPIDevol)
        /// </summary>
        public decimal? IPIDevolAmount { get; set; }
    }
}
