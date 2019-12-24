namespace nfe.api.client.Domain.Models.Product.Tax
{
    public class IITax
    {
        /// <summary>
        /// Valor BC do Imposto de Importação (vBC)
        /// </summary>
        public string BaseTax { get; set; }

        /// <summary>
        /// Valor despesas aduaneiras (vDespAdu)
        /// </summary>
        public string CustomsExpenditureAmount { get; set; }

        /// <summary>
        /// Valor Imposto de Importação (vII)
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Valor Imposto sobre Operações Financeiras (vIOF)
        /// </summary>
        public decimal IOFAmount { get; set; }
    }
}