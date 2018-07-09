using ServiceInvoice.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.UnitTests
{
    public static class GenerateInvoiceToTest
    {
        public static Invoice Invoice()
        {
            return new Invoice
            {
                CityServiceCode = "3093",
                Description = "TESTE EMISSAO",
                ServicesAmount = 0.01,
                Borrower = new Person
                {
                    FederalTaxNumber = 191,
                    Name = "BANCO DO BRASIL SA",
                    Email = "email@remetente",
                    Address = new Address
                    {
                        Country = "BRA",
                        PostalCode = "70073901",
                        Street = "Outros Quadra 1 Bloco G Lote 32",
                        Number = "S/N",
                        AdditionalInformation = "QUADRA 01 BLOCO G",
                        District = "Asa Sul",
                        City = new City { Code = "5300108", Name = "Brasilia" },
                        State = "DF"
                    },
                },
            };
        }
    }
}
