using System;

namespace nfe.api.client.Domain.Models.Product
{
    public class Duplicate
    {
        /// <summary>
        /// Número da Duplicata (nDup)
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Data de vencimento (dVenc)
        /// </summary>
        public DateTime? ExpirationOn { get; set; }

        /// <summary>
        /// Valor da duplicata (vDup)
        /// </summary>
        public decimal Amount { get; set; }
    }
}