namespace nfe.api.client.Domain.Models.Product
{
    public class Fuel
    {
        /// <summary>
        /// Código de produto da ANP (cProdANP)
        /// </summary>
        public string CodeANP { get; set; }

        /// <summary>
        /// Percentual de Gás Natural para o produto GLP (cProdANP=210203001) (pMixGN)
        /// </summary>
        public decimal? PercentageNG { get; set; }

        /// <summary>
        /// Descrição do produto conforme ANP (descANP)
        /// </summary>
        public string DescriptionANP { get; set; }

        /// <summary>
        /// Percentual do GLP derivado do petróleo no produto GLP (cProdANP=210203001) (pGLP)
        /// </summary>
        public decimal? PercentageGLP { get; set; }

        /// <summary>
        /// Percentual de Gás Natural Nacional – GLGNn para o produto GLP (cProdANP= 210203001) (pGNn)
        /// </summary>
        public decimal? PercentageNGn { get; set; }

        /// <summary>
        /// Percentual de Gás Natural Importado – GLGNi para o produto GLP (cProdANP= 210203001) (pGNi)
        /// </summary>
        public decimal? PercentageGNi { get; set; }

        /// <summary>
        /// Valor de partida (cProdANP=210203001) (vPart)
        /// </summary>
        public decimal? StartingAmount { get; set; }

        /// <summary>
        /// Código de autorização / registro do CODIF (CODIF)
        /// </summary>
        public string CODIF { get; set; }

        /// <summary>
        /// Quantidade de combustível faturada à temperatura ambiente (qTemp)
        /// </summary>
        public decimal? AmountTemp { get; set; }

        /// <summary>
        /// Sigla da UF de consumo (UFCons)
        /// </summary>
        public string StateBuyer { get; set; }

        /// <summary>
        /// Informações da CIDE (CIDE)
        /// </summary>
        public CIDEResource CIDE { get; set; }

        /// <summary>
        /// Informações do grupo de “encerrante” (encerrante)
        /// </summary>
        public PumpResource Pump { get; set; }
    }

    public class CIDEResource
    {
        /// <summary>
        /// BC da CIDE (qBCProd)
        /// </summary>
        public decimal BC { get; set; }

        /// <summary>
        /// Valor da alíquota da CIDE (vAliqProd)
        /// </summary>
        public decimal Rate { get; set; }

        /// <summary>
        /// Valor da CIDE (vCIDE)
        /// </summary>
        public decimal CIDEAmount { get; set; }
    }

    public class PumpResource
    {
        /// <summary>
        /// Número de identificação do bico utilizado no abastecimento (nBico)
        /// </summary>
        public int SpoutNumber { get; set; }

        /// <summary>
        /// Número de identificação da bomba ao qual o bico está interligado (nBomba)
        /// </summary>
        public int? Number { get; set; }

        /// <summary>
        /// Número de identificação do tanque ao qual o bico está interligado (nTanque)
        /// </summary>
        public int TankNumber { get; set; }

        /// <summary>
        /// Valor do Encerrante no início do abastecimento (vEncIni)
        /// </summary>
        public decimal BeginningAmount { get; set; }

        /// <summary>
        /// Valor do Encerrante no final do abastecimento (vEncFin)
        /// </summary>
        public decimal EndAmount { get; set; }
    }
}