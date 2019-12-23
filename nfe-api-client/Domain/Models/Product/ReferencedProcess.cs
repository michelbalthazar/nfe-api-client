namespace nfe.api.client.Domain.Models.Product
{
    public class ReferencedProcess
    {
        ///summary
        /// Identificador do processo ou ato concessório
        ///summary
        public string IdentifierConcessory { get; set; }

        ///summary
        /// Indicador da origem do processo
        /// <remarks>
        ///     SEFAZ = 0
        ///     Justiça Federal = 1
        ///     Justiça Estadual = 2
        ///     Secex = 3
        ///     Outros = 9
        /// </remarks>
        ///summary
        public int IdentifierOrigin { get; set; }
    }
}