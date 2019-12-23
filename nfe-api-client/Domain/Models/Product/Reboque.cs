namespace nfe.api.client.Domain.Models.Product
{
    public class Reboque
    {
        /// <summary>
        /// Placa do Veiculo (placa)
        /// </summary>
        public string Plate { get; set; }

        /// <summary>
        /// UF Veiculo Reboque (UF)
        /// </summary>
        public string UF { get; set; }

        /// <summary>
        /// Registro Nacional de Transportador de Carga (ANTT) (RNTC)
        /// </summary>
        public string RNTC { get; set; }

        /// <summary>
        /// Identificação do Vagão (vagao)
        /// </summary>
        public string Wagon { get; set; }

        /// <summary>
        /// Identificação da Balsa (balsa)
        /// </summary>
        public string Ferry { get; set; }
    }
}