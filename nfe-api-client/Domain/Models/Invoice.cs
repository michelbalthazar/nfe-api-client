namespace nfe.api.client.Domain.Models
{
    public class Invoice
    {
        /// <summary>
        /// Emitente da NFS-e
        /// </summary>
        private Issuer Issuer { get; set; }
        /// <summary>
        /// <summary>Tomador do serviço</summary>
        /// </summary>
        private Borrower Borrower { get; set; }
        /// <summary>
        /// Código municipal do serviço prestado (cada cidade possuí sua tabela)
        /// </summary>
        private string CityServiceCode { get; set; }
        /// <summary>
        /// Código federal do serviço prestado (cada estado possuí sua tabela)
        /// </summary>
        private string FederalServiceCode { get; set; }
        /// <summary>
        /// Atividades da Empresa (CNAE)
        /// </summary>
        private string EconomicActivitieCode { get; set; }
        /// <summary>
        /// Descrição do serviço prestado
        /// </summary>
        private string Description { get; set; }
        /// <summary>
        /// Valor total do serviço prestado
        /// </summary>
        private double ServicesAmount { get; set; }
    }
}
