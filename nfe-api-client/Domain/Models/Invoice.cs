﻿using System;

namespace ServiceInvoice.Domain.Models
{
    public class Invoice
    {
        /// <summary>
        /// Prestador dos serviços
        /// </summary>
        public LegalPerson Provider { get; set; }
        /// <summary>
        /// Tomador dos serviços 
        /// </summary>
        public Person Borrower { get; set; }
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
        public string CnaeCode { get; set; }
        /// <summary>
        /// Descrição do serviço prestado
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Valor total do serviço prestado
        /// </summary>
        public double ServicesAmount { get; set; }

        /// <summary>
        /// Data de emissão (competência)
        /// </summary>
        public DateTime IssuedOn { get; set; }
    }
}
