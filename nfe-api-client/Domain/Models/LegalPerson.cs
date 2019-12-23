using System;
using System.Collections.Generic;

namespace ServiceInvoice.Domain.Models
{
    /// <summary>
    /// Emitente da NFS-e
    /// </summary>
    public class LegalPerson : Person
    {
        /// <summary>
        /// Nome Fantasia (esse nome será usado no assunto do e-mail)
        /// </summary>
        public string TradeName { get; set; }
        /// <summary>
        /// Inscrição Estadual do Substituto Tributário (IEST)
        /// </summary>
        public long? RegionalSTTaxNumber     { get; set; }
        /// <summary>
        /// Número de Inscricação na Prefeitura (CCM) 
        /// </summary>
        public string MunicipalTaxNumber { get; set; }
        /// <summary>
        /// Regime de tributação
        /// </summary>
        public TaxRegime TaxRegime { get; set; }
        /// <summary>
        /// Regime especial de tributação
        /// </summary>
        public SpecialTaxRegime? SpecialTaxRegime { get; set; }
        /// <summary>
        /// Código da Natureza Jurídica
        /// </summary>
        public LegalNature? LegalNature { get; set; }
        /// <summary>
        /// Data de abertura da empresa
        /// </summary>
        public DateTime OpenningDate { get; set; }
        /// <summary>
        /// CNAEs da empresa
        /// </summary>
        public IEnumerable<EconomicActivities> EconomicActivities { get; set; }
        /// <summary>
        /// Número de Inscricação na Junta Comercial
        /// </summary>
        public long CompanyRegistryNumber { get; set; }
        /// <summary>
        /// Número de Inscricação na SEFAZ (IE)
        /// </summary>
        public long? RegionalTaxNumber { get; set; }
        /// <summary>
        /// Taxa da Aliquota do ISS (Simples Nacional)
        /// </summary>
        public long ISSRate { get; set; }
    }

    public class EconomicActivities
    {
        /// <summary>
        /// Tipo da Atividade da Empresa
        /// <remarks>
        ///     1 - Principal (Main)
        ///     2 - Secundário (Secondary)
        /// </remarks>
        /// </summary>
        public EconomicActivityType Type { get; set; }
        /// <summary>
        /// Código do CNAE
        /// </summary>
        public long Code { get; set; }
    }
}