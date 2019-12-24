namespace nfe.api.client.Domain.Models.Product.Tax
{
    public class ICMSUFDestination
    {
        /// <summary>
        /// Valor da Base de Cálculo do ICMS na UF de destino (vBCUFDest)
        /// </summary>
        public decimal vBCUFDest { get; set; }
        /// <summary>
        /// Percentual adicional inserido na alíquota interna da UF de destino, relativo ao Fundo de Combate à Pobreza (FCP) naquela UF (pFCPUFDest)
        /// </summary>
        public decimal pFCPUFDest { get; set; }
        /// <summary>
        /// Alíquota adotada nas operações internas na UF de destino para o produto / mercadoria (pICMSUFDest)
        /// </summary>
        public decimal pICMSUFDest { get; set; }
        /// <summary>
        /// Alíquota interestadual das UF envolvidas (pICMSInter)
        /// </summary>
        public decimal pICMSInter { get; set; }
        /// <summary>
        /// Percentual de ICMS Interestadual para a UF de destino (pICMSInterPart)
        /// </summary>
        public decimal pICMSInterPart { get; set; }
        /// <summary>
        ///  Valor do ICMS relativo ao Fundo de Combate à Pobreza (FCP) da UF de destino (vFCPUFDest
        /// </summary>
        public decimal vFCPUFDest { get; set; }
        /// <summary>
        /// Valor do ICMS Interestadual para a UF de destino (vICMSUFDest)
        /// </summary>
        public decimal vICMSUFDest { get; set; }
        /// <summary>
        /// Valor do ICMS Interestadual para a UF do remetente (vICMSUFRemet)
        /// </summary>
        public decimal vICMSUFRemet { get; set; }

        // Additional field for NFE 4.0

        /// <summary>
        /// Valor da BC FCP na UF de destino (vBCFCPUFDest)
        /// </summary>
        public decimal vBCFCPUFDest { get; set; }
    }
}