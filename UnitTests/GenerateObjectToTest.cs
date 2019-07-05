using ServiceInvoice.Domain.Models;

namespace Tests.UnitTests
{
    public static class GenerateObjectToTest
    {
        public static Invoice Invoice()
        {
            return new Invoice
            {
                CityServiceCode = "3093",
                Description = "TESTE EMISSAO",
                ServicesAmount = 0.01,
                CnaeCode = "12315454",
                IssuedOn = new System.DateTime(2018, 12, 31),
                Borrower = new Person
                {
                    FederalTaxNumber = 191,
                    Name = "BANCO DO BRASIL SA",
                    Email = "email@deTest.com.br", // If set a valid email, this email will receive this one nfse's xml and pdf.
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

        public static Invoice InvoiceBH()
        {
            return new Invoice
            {
                CityServiceCode = "010100188",
                Description = "Consultoria esportiva",
                ServicesAmount = 0.01,
                Borrower = new Person
                {
                    Type = PersonType.LegalPerson,
                    FederalTaxNumber = 191,
                    Name = "BANCO DO BRASIL SA",
                    Email = "email@deTest.com.br", // If set a valid email, this email will receive this one nfse's xml and pdf.
                    Address = new Address
                    {
                        Country = "BRA",
                        PostalCode = "31980065",
                        Street = "Rua ana pereina meneses",
                        Number = "127",
                        AdditionalInformation = "ap 314",
                        District = "São gabriel",
                        State = "MG",
                        City = new City { Code = "32145", Name = "Belo Horizonte" }
                    },
                },
            };
        }

        public static LegalPerson Company()
        {
            return new LegalPerson
            {
                FederalTaxNumber = 191,
                Name = "BANCO DO BRASIL SA",
                TradeName = "BANCO DO BRASIL SA",
                MunicipalTaxNumber = "12345",
                TaxRegime = TaxRegime.SimplesNacional,
                SpecialTaxRegime = SpecialTaxRegime.Nenhum,
                Email = "email@deTest.com.br", // If set a valid email, this email will receive this one nfse's xml and pdf.
                Address = new Address
                {
                    Country = "BRA",
                    PostalCode = "70073901",
                    Street = "Outros Quadra 1 Bloco G Lote 32",
                    Number = "S/N", // optional
                    AdditionalInformation = "QUADRA 01 BLOCO G", // optional
                    District = "Asa Sul",
                    City = new City { Code = "5300108", Name = "Brasília" },
                    State = "DF"
                },
            };
        }
    }
}
