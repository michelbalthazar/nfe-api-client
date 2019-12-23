namespace nfe.api.client.Domain.Models.Product
{
    public class Volume
    {
        /// <summary>
        /// Quantidade de volumes transportados (qVol)
        /// </summary>
        public int? VolumeQuantity { get; set; }

        /// <summary>
        /// Espécie dos volumes transportados (esp)
        /// </summary>
        public string Species { get; set; }

        /// <summary>
        /// Marca dos Volumes Transportados (marca)
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// Numeração dos Volumes Transportados (nVol)
        /// </summary>
        public string VolumeNumeration { get; set; }

        /// <summary>
        /// Peso Liquido(em Kg) (pesoL)
        /// </summary>
        public decimal? NetWeight { get; set; }

        /// <summary>
        /// Peso Bruto(em Kg) (pesoB)
        /// </summary>
        public decimal? GrossWeight { get; set; }
    }
}