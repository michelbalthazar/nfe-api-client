using System.Collections.Generic;

namespace nfe.api.client.Domain.Models.Product
{
    public class InvoiceEvents
    {
        /// <summary>
        /// Lista de Eventos ocorridos na Nota Fiscal
        /// </summary>
        public List<ActivityResource> Events { get; set; }

        /// <summary>
        /// Identificador de possibilidade de mais itens.
        /// </summary>
        public bool HasMore { get; set; }

        ///// <summary>
        ///// Links informativos sobre os eventos
        ///// </summary>
        //public LinksResource Links { get; set; }
    }

    public class ActivityResource
    {
        /// <summary>
        /// Detalhes do Evento
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// Nome do Evento gerado
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Número sequencial do Evento
        /// </summary>
        public int Sequence { get; set; }
    }
}