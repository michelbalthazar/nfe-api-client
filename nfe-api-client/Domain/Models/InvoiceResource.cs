using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace ServiceInvoice.Domain.Models
{
    public class InvoiceResource
    {
        /// <summary>
        /// Prestador dos serviços
        /// </summary>
        public LegalPerson Provider { get; set; }
        /// <summary>
        /// Tomador dos serviços 
        /// </summary>
        public Person Borrower { get; set; }
        /// <summary>
        /// Código municipal do serviço prestado (cada cidade possuí sua tabela)
        /// </summary>
        public string CityServiceCode { get; set; }
        /// <summary>
        /// Código federal do serviço prestado (cada estado possuí sua tabela)
        /// </summary>
        public string FederalServiceCode { get; set; }
        /// <summary>
        /// Atividades da Empresa (CNAE)
        /// </summary>
        public string EconomicActivitieCode { get; set; }
        /// <summary>
        /// Descrição do serviço prestado
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Número da RPS
        /// </summary>
        public long RpsNumber { get; set; }
        /// <summary>
        /// Número de serie da RPS
        /// </summary>
        public string RpsSerialNumber { get; set; }
        /// <summary>
        /// Valor total do serviço prestado
        /// </summary>
        public double ServicesAmount { get; set; }
        /// <summary>
        /// Identificação
        /// </summary>
        public virtual string Id { get; set; }
        /// <summary>
        /// Ambiente de Processamento
        /// </summary>
        [Required]
        public ApiEnvironment Environment { get; set; }
        /// <summary>
        /// Status do processamento
        /// </summary>
        public NotaFiscalFlowStatus FlowStatus { get; set; }
        /// <summary>
        /// Mensagem de processamento
        /// </summary>
        public string FlowMessage { get; set; }
        /// <summary>
        /// Número do lote da RPS
        /// </summary>
        public long BatchNumber { get; set; }
        /// <summary>
        /// Número do protocolo do lote da RPS
        /// </summary>
        public string BatchCheckNumber { get; set; }
        /// <summary>
        /// Número do NFE
        /// </summary>
        public long Number { get; set; }
        /// <summary>
        /// Código de Verificação da NFE
        /// </summary>
        public string CheckCode { get; set; }
        /// <summary>
        /// Status da NFE
        /// </summary>
        public InvoiceStatus Status { get; set; }
        /// <summary>
        /// Tipo da RPS
        /// </summary>
        public RpsType RpsType { get; set; }
        /// <summary>
        /// Status da RPS
        /// </summary>
        public RpsStatus RpsStatus { get; set; }
        /// <summary>
        /// Tipo da tributação
        /// </summary>
        public TaxationType TaxationType { get; set; }
        /// <summary>
        /// Valor de deduções
        /// </summary>
        public decimal DeductionsAmount { get; set; }
        /// <summary>
        /// Valor do desconto incondicionado
        /// </summary>
        public decimal DiscountUnconditionedAmount { get; set; }
        /// <summary>
        /// Valor do desconto condicionado
        /// </summary>
        public decimal DiscountConditionedAmount { get; set; }
        /// <summary>
        /// Valor da base de calculo de impostos
        /// </summary>
        public decimal BaseTaxAmount { get; set; }
        /// <summary>
        /// Aliquota do ISS
        /// </summary>
        public decimal IssRate { get; set; }
        /// <summary>
        /// Valor do ISS
        /// </summary>
        public decimal IssTaxAmount { get; set; }
        /// <summary>
        /// Valor retido do Imposto de Renda (IR)
        /// </summary>
        public decimal IrAmountWithheld { get; set; }
        /// <summary>
        /// Valor retido do PIS
        /// </summary>
        public decimal PisAmountWithheld { get; set; }
        /// <summary>
        /// Valor retido do COFINS
        /// </summary>
        public decimal CofinsAmountWithheld { get; set; }
        /// <summary>
        /// Valor retido do CSLL
        /// </summary>
        public decimal CsllAmountWithheld { get; set; }
        /// <summary>
        /// Valor retido do INSS
        /// </summary>
        public decimal InssAmountWithheld { get; set; }
        /// <summary>
        /// Valor retido do ISS
        /// </summary>
        public decimal IssAmountWithheld { get; set; }
        /// <summary>
        /// Valor de outras retenções
        /// </summary>
        public decimal OthersAmountWithheld { get; set; }
        /// <summary>
        /// Valor das retenções
        /// </summary>
        public decimal AmountWithheld { get; set; }
        /// <summary>
        /// Valor líquido
        /// </summary>
        public decimal AmountNet { get; set; }
        /// <summary>
        /// Tributos aproximados
        /// </summary>
        public InvoiceApproximateTaxes ApproximateTax { get; set; }
        /// <summary>
        /// Informações Adicionais
        /// </summary>
        public string AdditionalInformation { get; set; }
        /// <summary>
        /// Data de criação
        /// </summary>
        public virtual DateTimeOffset CreatedOn { get; set; }
        /// <summary>
        /// Data da última modificação
        /// </summary>
        public virtual DateTimeOffset? ModifiedOn { get; set; }
        /// <summary>
        /// Data de cancelamento
        /// </summary>
        public virtual DateTimeOffset? CancelledOn { get; set; }
        /// <summary>
        /// Data de emissão
        /// </summary>
        public DateTimeOffset IssuedOn { get; set; }
    }

    public class InvoiceApproximateTaxes
    {
        /// <summary>
        /// Nome da fonte da taxa
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// Versão da taxa baseado na fonte
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Taxa dos tributos aproximados
        /// </summary>
        public decimal TotalRate { get; set; }
    }
}
