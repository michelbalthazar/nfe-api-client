using ServiceInvoice.Domain.Models;

namespace nfe.api.client.Domain.Models.Product
{
    public class TransportGroup : Person
    {
        /// <summary>
        /// Inscrição Estadual do Transportador (IE)
        /// </summary>
        public string StateTaxNumber { get; set; }

        /// <summary>
        /// Grupo de Retenção do ICMS do transporte
        /// </summary>
        public string TransportRetention { get; set; }
    }
}