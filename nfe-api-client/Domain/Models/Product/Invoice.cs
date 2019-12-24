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
        /// Tipo de Operação (tpNF)
        /// <remarks>
        ///     0 - Entrada (Incoming)
        ///     1 - Saída (Outgoing)
        /// </remarks>
        /// </summary>
        public OperationType OperationType { get; set; }

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
        ///  Grupo Cobrança (cobr)
        /// </summary>
        public Billing Billing { get; set; }

        /// <summary>
        ///  Grupo de Formas de Pagamento (pag)
        /// </summary>
        public List<Payment> Payment { get; set; }

        /// <summary>
        /// Eventos do processamento
        /// </summary>
        public InvoiceEvents LastEvents { get; set; }
    }
}