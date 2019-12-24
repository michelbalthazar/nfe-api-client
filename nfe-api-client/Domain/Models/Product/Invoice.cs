using ServiceInvoice.Domain.Models;
using System;
using System.Collections.Generic;

namespace nfe.api.client.Domain.Models.Product
{
    public class Invoice
    {
        /// <summary>
        /// Identificador único
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Série do Documento Fiscal (serie)
        /// </summary>
        public int Serie { get; set; }

        /// <summary>
        /// Número do Documento Fiscal (nNF)
        ///  </summary>
        public long Number { get; set; }

        /// <summary>
        /// Status da Nota Fiscal
        /// </summary>
        public ProductInvoiceStatus Status { get; set; }

        /// <summary>
        /// Descrição da Natureza da Operação (natOp)
        /// </summary>
        public string OperationNature { get; set; }

        /// <summary>
        /// Data de criação
        /// </summary>
        public DateTimeOffset? CreatedOn { get; set; }

        /// <summary>
        /// Data de modificação
        /// </summary>
        public DateTimeOffset? ModifiedOn { get; set; }

        /// <summary>
        /// Data e Hora de Saída ou da Entrada da Mercadoria/Produto (dhSaiEnt)
        /// <remarks>
        ///     Data e hora no formato UTC (Universal Coordinated Time): AAAA-MM-DDThh:mm:ssTZD.
        /// </remarks>
        /// </summary>
        public DateTimeOffset? OperationOn { get; set; }

        /// <summary>
        /// Tipo de Operação (tpNF)
        /// <remarks>
        ///     0 - Entrada (Incoming)
        ///     1 - Saída (Outgoing)
        /// </remarks>
        /// </summary>
        public OperationType OperationType { get; set; }

        /// <summary>
        /// Identificador de local de destino da operação (idDest)s
        /// <remarks>
        ///     1 - Operação interna (Internal_Operation)
        ///     2 - Operação interestadual (Interstate_Operation)
        ///     3 - Operação com exterior (International_Operation)
        /// </remarks>
        /// </summary>
        public Destination Destination { get; set; }

        /// <summary>
        /// Formato de Impressão do DANFE (tpImp)
        /// <remarks>
        ///     0 - Sem geração de DANFE (None)
        ///     1 - DANFE normal, Retrato (NFeNormalPortrait)
        ///     2 - DANFE normal, Paisagem (NFeNormalLandscape)
        ///     3 - DANFE Simplificado (NFeSimplified)
        ///     4 - DANFE NFC-e (DANFE_NFC_E)
        ///     5 - DANFE NFC-e em mensagem eletrônica (DANFE_NFC_E_MSG_ELETRONICA)
        /// </remarks>
        /// </summary>
        public PrintType PrintType { get; set; }

        /// <summary>
        /// Identificação do Ambiente (tpAmb)
        /// </summary>
        public EnvironmentType EnvironmentType { get; set; }

        /// <summary>
        /// Finalidade de emissão da NF-e (finNFe)
        /// <remarks>
        ///     1 - NF-e normal (Normal)
        ///     2 - NF-e complementar (Complement)
        ///     3 - NF-e de ajuste (Adjustment)
        ///     4 - Devolução de mercadoria (Devolution)
        /// </remarks>
        /// </summary>
        public PurposeType PurposeType { get; set; }

        /// <summary>
        /// Indica operação com Consumidor final  (indFinal)
        /// <remarks>
        ///     0 - Normal (Normal)
        ///     1 - Consumidor final (FinalConsumer)
        /// </remarks>
        /// </summary>
        public ConsumerType ConsumerType { get; set; }

        /// <summary>
        /// Indicador de presença do comprador no estabelecimento comercial no momento da operação (indPres)
        /// <remarks>
        ///     0 - Não se aplica (por exemplo, Nota Fiscal complementar ou de ajuste)
        ///     1 - Operação presencial
        ///     2 - Operação não presencial, pela Internet
        ///     3 - Operação não presencial, Teleatendimento
        ///     4 - NFC-e em operação com entrega a domicílio
        ///     9 - Operação não presencial, outros
        /// </remarks>
        /// </summary>
        public ConsumerPresenceType PresenceType { get; set; }

        /// <summary>
        /// Data e Hora da entrada em contingência (dhCont)
        /// <remarks>
        ///     Data e hora no formato UTC (Universal Coordinated Time): AAAA-MM-DDThh:mm:ssTZD
        /// </remarks>
        /// </summary>
        public DateTimeOffset? ContingencyOn { get; set; }

        /// <summary>
        /// Justificativa da entrada em contingência (xJust)
        /// </summary>
        public string ContingencyJustification { get; set; }

        /// <summary>
        /// Emitente (emit)
        /// </summary>
        public Issuer Issuer { get; set; }

        /// <summary>
        /// Destinatario (dest)
        /// </summary>
        public Buyer Buyer { get; set; }

        /// <summary>
        /// ICMS Totals (total)
        /// </summary>
        public Total Totals { get; set; }

        /// <summary>
        /// Transportadora (transp)
        /// </summary>
        public TransportInformation Transport { get; set; }

        /// <summary>
        /// Informacoes Adicionais (infAdic)
        /// </summary>
        public AdditionalInformation AdditionalInformation { get; set; }

        /// <summary>
        /// Detalhamento de Produtos e Serviços (det)
        /// </summary>
        public List<InvoiceItem> Items { get; set; }

        /// <summary>
        ///  Grupo Cobrança (cobr)
        /// </summary>
        public Billing Billing { get; set; }

        /// <summary>
        ///  Grupo de Formas de Pagamento (pag)
        /// </summary>
        public List<Payment> Payment { get; set; }
    }
}