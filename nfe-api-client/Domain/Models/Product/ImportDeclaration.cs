using ServiceInvoice.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace nfe.api.client.Domain.Models.Product
{
    public class ImportDeclaration
    {
        /// <summary>
        /// Número do Documento de Importação da DI/DSI/DA (nDI)
        /// </summary>
        [Required]
        public string Code { get; set; }

        /// <summary>
        /// Data de Registro da DI/DSI/DA (dDI)
        /// </summary>
        [Required]
        public DateTimeOffset RegisteredOn { get; set; }

        /// <summary>
        /// Local de desembaraço (xLocDesemb)
        /// </summary>
        [Required]
        public string CustomsClearanceName { get; set; }

        /// <summary>
        /// Sigla da UF onde ocorreu o Desembaraço Aduaneiro (UFDesemb)
        /// </summary>
        [Required]
        public StateCode CustomsClearanceState { get; set; }

        /// <summary>
        /// Data do Desembaraço Aduaneiro (dDesemb)
        /// </summary>
        [Required]
        public DateTimeOffset CustomsClearancedOn { get; set; }

        /// <summary>
        /// Adições (adi)
        /// </summary>
        [Required]
        public IEnumerable<AdditionResource> Additions { get; set; }

        /// <summary>
        /// Código do exportador (cExportador)
        /// </summary>
        [Required]
        public string Exporter { get; set; }

        /// <summary>
        /// Via de transporte internacional informada na Declaração de Importação (DI) (tpViaTransp)
        /// </summary>
        [Required]
        public InternationalTransportType InternationalTransport { get; set; }

        /// <summary>
        /// Valor da AFRMM - Adicional ao Frete para Renovação da Marinha Mercante (vAFRMM)
        /// </summary>
        //public decimal? AFRMM { get; set; }

        /// <summary>
        /// Forma de importação quanto a intermediação (tpIntermedio)
        /// </summary>
        [Required]
        public IntermediationType Intermediation { get; set; }

        /// <summary>
        /// CNPJ do adquirente ou do encomendante (CNPJ)
        /// </summary>
        //public long? FederalTaxNumber { get; set; }

        /// <summary>
        /// Sigla da UF do adquirente ou do encomendante (UFTerceiro)
        /// </summary>
        //public StateCode? StateCode { get; set; }
    }

    /// <summary>
    /// Adições (adi)
    /// </summary>
    public class AdditionResource
    {
        /// <summary>
        /// Numero da adição (nAdicao)
        /// </summary>
        [Required]
        public long Code { get; set; }

        /// <summary>
        /// Numero seqüencial do item dentro da adição (nSeqAdic)
        /// </summary>
        //[Required]
        //public long Sequence { get; set; }

        /// <summary>
        /// Código do fabricante estrangeiro (cFabricante)
        /// </summary>
        [Required]
        public string Manufacturer { get; set; }

        /// <summary>
        /// Valor do desconto do item da DI – Adição (vDescDI)
        /// </summary>
        public decimal? Amount { get; set; }

        /// <summary>
        /// Número do Pedido de Compra (xPed)
        /// </summary>
        //public string PurchaseOrder { get; set; }

        /// <summary>
        /// Número do ato concessório de Drawback (nDraw)
        /// </summary>
        public long? Drawback { get; set; }
    }
}