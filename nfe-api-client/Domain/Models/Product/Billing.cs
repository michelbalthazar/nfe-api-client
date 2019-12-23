namespace nfe.api.client.Domain.Models.Product
{
    public class Billing
    {
        /// <summary>
        /// Grupo Fatura (fat)
        /// </summary>
        public Bill Bill { get; set; }

        /// <summary>
        /// Grupo Duplicata (dup)
        /// </summary>
        public List<Duplicate> Duplicates { get; set; }
    }
}