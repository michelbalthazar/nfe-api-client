using System.ComponentModel.DataAnnotations;

namespace ServiceInvoice.Domain.Models
{
    public enum PersonType
    {
        /// <summary>
        /// Indefinido
        /// </summary>
        Undefined = 0,

        /// <summary>
        /// Pessoa Física
        /// </summary>
        NaturalPerson = 1,

        /// <summary>
        /// Pessoa Jurídica
        /// </summary>
        LegalEntity = 2,
    }

    public enum TaxRegime
    {
        [Display(Name = "Isento")]
        Isento = 5,

        [Display(Name = "Microempreendedor Individual")]
        MicroempreendedorIndividual = 4,

        [Display(Name = "Simples Nacional")]
        SimplesNacional = 3,

        [Display(Name = "Lucro Presumido")]
        LucroPresumido = 2,

        [Display(Name = "Lucro Real")]
        LucroReal = 1,

        None = 0
    }

    public enum SpecialTaxRegime
    {
        /// <summary>
        /// Automatico
        /// </summary>
        [Display(Name = "Automatico")]
        Automatico = -1,

        /// <summary>
        /// Nenhum
        /// </summary>
        [Display(Name = "Nenhum")]
        Nenhum = 0,

        /// <summary>
        /// Microempresa Municipal
        /// </summary>
        [Display(Name = "Microempresa Municipal")]
        MicroempresaMunicipal = 1,

        /// <summary>
        /// Estimativa
        /// </summary>
        [Display(Name = "Estimativa")]
        Estimativa = 2,

        /// <summary>
        /// Sociedade de Profissionais
        /// </summary>
        [Display(Name = "Sociedade de Profissionais")]
        SociedadeDeProfissionais = 3,

        /// <summary>
        /// Cooperativa
        /// </summary>
        [Display(Name = "Cooperativa")]
        Cooperativa = 4,

        /// <summary>
        /// MicroempreendedorIndividual
        /// </summary>
        [Display(Name = "Microempreendedor Individual")]
        MicroempreendedorIndividual = 5,

        /// <summary>
        /// Microempresario e Empresa de Pequeno Porte
        /// </summary>
        [Display(Name = "Microempresario e Empresa de Pequeno Porte")]
        MicroempresarioEmpresaPequenoPorte = 6
    }
}