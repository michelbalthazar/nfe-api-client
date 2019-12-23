using ServiceInvoice.Domain.Models;

namespace nfe.api.client.Domain.Models.Product
{
    public class TransportInformation
    {
        /// <summary>
        /// Modalidade do frete (modFrete)
        /// <remarks>
        ///     0 - Por conta do emitente (ByIssuer)
        ///     1 - Por conta do destinatário/remetente (ByReceiver)
        ///     2 - Por conta de terceiros (ByThirdParties)
        ///     9 - Sem frete (Free)
        /// </remarks>
        /// </summary>
        public ShippingModality FreightModality { get; set; }

        /// <summary>
        /// Grupo Transportador (transporta)
        /// </summary>
        public TransportGroup TransportGroup { get; set; }
        /// <summary>
        /// Grupo Reboque (reboque)
        /// </summary>
        public Reboque Reboque { get; set; }

        /// <summary>
        /// Grupo Volumes (vol)
        /// </summary>
        public Volume Volume { get; set; }

        /// <summary>
        /// Grupo Veiculo (veicTransp)
        /// </summary>
        public TransportVehicle TransportVehicle { get; set; }

        /// <summary>
        /// Número dos Lacres
        /// </summary>
        public string SealNumber { get; set; }

        /// <summary>
        /// Grupo Retenção ICMS transporte (retTransp)
        /// </summary>
        public TransportRate TranspRate { get; set; }
    }
}