using System.Collections.Generic;

namespace nfe.api.client.Domain.Models.Product
{
    public class AdditionalInformation
    {
        /// <summary>
        ///Informações Adicionais de Interesse do Fisco (infAdFisco)
        /// </summary>
        public string Fisco;

        /// <summary>
        /// Informações Complementares de interesse do Contribuinte (infCpl)
        /// </summary>
        public string Taxpayer;

        /// <summary>
        /// Informações Complementares de interesse do Contribuinte (infCpl)
        /// </summary>
        public List<long> XMLAuthorized { get; set; }

        public string Effort { get; set; }

        public string Order { get; set; }

        public string Contract { get; set; }

        /// <summary>
        /// Documentos Fiscais Referenciados (refECF)
        /// </summary>
        public List<TaxDocumentsReference> TaxDocumentsReference { get; set; }

        /// <summary>
        /// Observações fiscais (obsCont)
        /// </summary>
        public List<TaxpayerComments> TaxpayerComments { get; set; }

        /// <summary>
        /// Processos referenciados (procRef)
        /// </summary>
        public List<ReferencedProcess> ReferencedProcess { get; set; }
    }
}
