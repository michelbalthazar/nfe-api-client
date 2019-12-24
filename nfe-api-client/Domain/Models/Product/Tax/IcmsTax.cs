using ServiceInvoice.Domain.Models;

namespace nfe.api.client.Domain.Models.Product.Tax
{
    public class IcmsTax
    {
        /// <summary>
        /// Origem da mercadoria (orig)
        /// </summary>
        [Required]
        public string Origin { get; set; }

        /// <summary>
        /// Tributação do ICMS (CST)
        /// </summary>
        public string CST { get; set; }

        /// <summary>
        /// Modalidade de determinação da BC do ICMS (modBC)
        /// <remarks>
        ///     Margem Valor Agregado (%) = 0
        ///     Pauta (valor) = 1
        ///     Preço Tabelado Máximo (valor) = 2
        ///     Valor da Operação = 3
        /// </remarks>
        /// </summary>
        public string BaseTaxModality { get; set; }

        /// <summary>
        /// Valor da BC do ICMS (vBC)
        /// </summary>
        public decimal? BaseTax { get; set; }

        ///<summary>
        /// Modalidade de determinação da BC do ICMS ST (modBCST)
        /// </summary>
        public string BaseTaxSTModality { get; set; }

        ///<summary>
        /// pRedBCST
        /// Percentual da Redução de BC do ICMS ST (pRedBCST)
        /// </summary>
        public string BaseTaxSTReduction { get; set; }

        ///<summary>
        /// Valor da BC do ICMS ST (vBCST)
        /// </summary>
        public decimal? BaseTaxST { get; set; }

        ///<summary>
        ///Percentual da Redução de BC (pRedBC)
        /// </summary>
        public decimal? BaseTaxReduction { get; set; }

        ///<summary>
        /// Alíquota do imposto do ICMS ST (pICMSST)
        /// </summary>
        public decimal? STRate { get; set; }

        /// <summary>
        /// Valor do ICMS ST (vICMSST)
        /// </summary>
        public decimal? STAmount { get; set; }

        ///<summary>
        /// pMVAST
        /// Percentual da margem de valor Adicionado do ICMS ST (pMVAST)
        /// </summary>
        public decimal? STMarginAmount { get; set; }

        /// <summary>
        /// 101- Tributada pelo Simples Nacional com permissão de crédito. (v.2.0) (CSOSN)
        /// Código de Situação da Operação – Simples Nacional
        /// </summary>
        public string CSOSN { get; set; }

        /// <summary>
        /// pICMS
        /// Alíquota do imposto (pICMS)
        /// </summary>
        public decimal? Rate { get; set; }

        /// <summary>
        /// Valor do ICMS (vICMS)
        /// 
        ///O valor do ICMS desonerado será informado apenas nas operações:
        ///a) com produtos beneficiados com a desoneração condicional do ICMS.
        ///b) destinadas à SUFRAMA, informando-se o valor que seria devido se não houvesse isenção.
        ///c) de venda a órgãos da administração pública direta e suas fundações e
        ///autarquias com isenção do ICMS. (NT 2011/004)
        /// </summary>
        public decimal? Amount { get; set; }

        ///<summary>
        /// Percentual da Redução de BC (pICMS)
        /// </summary>
        public decimal? Percentual { get; set; }

        /// <summary>
        /// Alíquota aplicável de cálculo do crédito (Simples Nacional). (pCredSN)
        /// </summary>
        public decimal SNCreditRate { get; set; }

        /// <summary>
        /// Valor crédito do ICMS que pode ser aproveitado nos termos do art. 23 da LC 123 Simples Nacional (vCredICMSSN)
        /// </summary>
        public decimal SNCreditAmount { get; set; }

        /// <summary>
        /// Percentual da margem de valor Adicionado do ICMS ST (pMVAST)
        /// </summary>
        public string STMarginAddedAmount { get; set; }

        ///<summary>
        /// Valor do ICMS ST retido (vICMSSTRet)
        /// </summary>
        public string STRetentionAmount { get; set; }

        ///<summary>
        /// Valor da BC do ICMS ST retido (vBCSTRet)
        /// </summary>
        public string BaseSTRetentionAmount { get; set; }

        ///<summary>
        /// Percentual  da BC operação própria  (pBCOp)
        /// Percentual para determinação do valor  da Base de Cálculo da operação própria. (v2.0) 
        /// </summary>
        public string BaseTaxOperationPercentual { get; set; }

        ///<summary>
        /// UF para qual é devido o ICMS ST (UFST)
        /// Sigla da UF para qual é devido o ICMS ST da operação. (v2.0) 
        /// </summary>
        public string UFST { get; set; }

        ///<summary>
        /// Motivo Desoneração ICMS
        /// </summary>
        public string AmountSTReason { get; set; }

        ///<summary>
        /// Valor da BC do ICMS ST retido (vBCSTRet)
        /// </summary>
        public string BaseSNRetentionAmount { get; set; }

        ///<summary>
        /// Valor do ICMS ST retido (vICMSSTRet)
        /// </summary>
        public string SNRetentionAmount { get; set; }

        ///<summary>
        /// Valor do ICMS da Operação (vICMSOp)
        /// </summary>
        public string AmountOperation { get; set; }

        ///<summary>
        /// Percentual do Diferimento (pDif)
        /// </summary>
        public string PercentualDeferment { get; set; }

        ///<summary>
        /// Valor do ICMS Diferido (vICMSDif)
        /// </summary>
        public string BaseDeferred { get; set; }

        // Additional fields for NFe 4.0 

        ///<summary>
        ///Valor ICMS Desonerado
        /// </summary>
        public decimal? ExemptAmount { get; set; }

        ///<summary>
        ///Motivo Desoneração ICMS
        /// </summary>
        public ExemptReason? ExemptReason { get; set; }

        /// <summary>
        /// Percentual do FCP - Valor do ICMS relativo ao Fundo de Combate à Pobreza (pFCP)
        /// </summary>
        public decimal? FCPRate { get; set; }

        /// <summary>
        /// Valor Total do FCP - Valor do ICMS relativo ao Fundo de Combate à Pobreza (vFCP)
        /// </summary>
        public decimal? FCPAmount { get; set; }

        /// <summary>
        /// Percentual do FCP retido por ST - Valor do ICMS relativo ao Fundo de Combate à Pobreza retido por substituição tributária (pFCPST)
        /// </summary>
        public decimal FCPSTRate { get; set; }

        /// <summary>
        /// Valor Total do FCP retido por ST - Valor do ICMS relativo ao Fundo de Combate à Pobreza retido por substituição tributária (vFCPST)
        /// </summary>
        public decimal FCPSTAmount { get; set; }

        /// <summary>
        /// Percentual do FCP retido por anteriormente por ST - Valor do ICMS relativo ao Fundo de Combate à Pobreza retido anteriormente por substituição tributária (pFCPSTRet)
        /// </summary>
        public decimal FCPSTRetRate { get; set; }

        /// <summary>
        /// Valor Total do FCP retido por anteriormente por ST - Valor do ICMS relativo ao Fundo de Combate à Pobreza retido anteriormente por substituição tributária (vFCPSTRet)
        /// </summary>
        public decimal FCPSTRetAmount { get; set; }

        /// <summary>
        /// Informar o valor da Base de Cálculo do FCP (vBCFCPST)
        /// </summary>
        public decimal BaseTaxFCPSTAmount { get; set; }

        /// <summary>
        ///     Valor do ICMS próprio do Substituto (tag: vICMSSubstituto)
        /// </summary>
        public decimal? SubstituteAmount { get; set; }
    }
}