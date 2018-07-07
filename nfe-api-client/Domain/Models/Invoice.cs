namespace ServiceInvoice.Domain.Models
{
    public class Invoice
    {
        /// <summary>
        /// Emitente da NFS-e
        /// </summary>
        public Issuer Issuer { get; set; }
        /// <summary>
        /// <summary>Tomador do serviço</summary>
        /// </summary>
        public Borrower Borrower { get; set; }
        /// <summary>
        /// Código municipal do serviço prestado (cada cidade possuí sua tabela)
        /// </summary>
        public string CityServiceCode { get; set; }
        /// <summary>
        /// Código federal do serviço prestado (cada estado possuí sua tabela)
        /// </summary>
        public string FederalServiceCode { get; set; }
        /// <summary>
        /// Atividades da Empresa (CNAE)
        /// </summary>
        public string EconomicActivitieCode { get; set; }
        /// <summary>
        /// Descrição do serviço prestado
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Valor total do serviço prestado
        /// </summary>
        public double ServicesAmount { get; set; }
    }
}
