namespace nfe.api.client.Domain.Models.Product
{
    public class TransportRate
    {
        /// <summary>
        /// Valor do Serviço (vServ)
        /// </summary>
        public decimal? ServiceAmount { get; set; }

        /// <summary>
        /// BC da Retenção do ICMS (vBCRet)
        /// </summary>
        public decimal? BCRetentionAmount { get; set; }

        /// <summary>
        /// Alíquota da Retenção (pICMSRet) //Change to Rate
        /// </summary>
        public decimal? ICMSRetentionRate { get; set; }

        /// <summary>
        /// Valor do ICMS Retido (vICMSRet)
        /// </summary>
        public decimal? ICMSRetentionAmount { get; set; }

        /// <summary>
        /// CFOP de Serviço de Transporte (CFOP)
        /// </summary>
        public long? CFOP { get; set; }

        /// <summary>
        /// Código do Municipio de ocorrencia do fato gerador do ICMS do Transpote (cMunFG)
        /// </summary>
        public long? CityGeneratorFactCode { get; set; }
    }
}