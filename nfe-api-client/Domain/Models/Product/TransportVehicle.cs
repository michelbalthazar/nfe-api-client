namespace nfe.api.client.Domain.Models.Product
{
    public class TransportVehicle
    {
        /// <summary>
        /// Placa do Veiculo (placa)
        /// </summary>
        public string Plate { get; set; }

        /// <summary>
        /// Sigla da UF (UF)
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Registro Nacional de Transportador de Carga (ANTT) (RNTC)
        /// </summary>
        public string RNTC { get; set; }
    }
}