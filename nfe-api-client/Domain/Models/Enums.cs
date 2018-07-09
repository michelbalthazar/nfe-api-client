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

    public enum Status
    {
        /// <summary>
        /// Valor padrão quando estiver null
        /// </summary>
        None = 0,

        /// <summary>
        /// Quando uma pessoa for deletada
        /// </summary>
        Inactive = 1,

        /// <summary>
        /// Quando for cadastrada
        /// </summary>
        Active = 2,
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

    /// <summary>
    /// Status da invoice no processamento do sistema
    /// </summary>
    public enum NotaFiscalFlowStatus
    {
        CancelFailed = -2,
        IssueFailed = -1,
        Issued = 1,
        Cancelled = 2,
        PullFromCityHall = 3,

        WaitingCalculateTaxes = 10,
        WaitingDefineRpsNumber = 11,
        WaitingSend = 12,
        WaitingSendCancel = 13,
        WaitingReturn = 14,
        WaitingDownload = 15
    }

    /// <summary>
    /// Status da invoice 
    /// </summary>
    public enum InvoiceStatus
    {
        Error = -1,
        None = 0,
        Created = 1,
        Issued = 2,
        Cancelled = 3
    }

    /// <summary>
    /// RPS   = Recibo Provisório de Serviços
    /// RPS-M = Recibo Provisório de Serviços proveniente de Nota Fiscal Conjugada (Mista)
    /// RPS-C = Cupom
    /// </summary>
    public enum RpsType
    {
        /// <summary>
        /// Recibo Provisório de Serviços
        /// </summary>
        Rps = 1,

        /// <summary>
        /// Recibo Provisório de Serviços proveniente de Nota Fiscal Conjugada (Mista)
        /// </summary>
        RpsMista = 2,

        /// <summary>
        /// Cupom
        /// </summary>
        Cupom = 4
    }

    /// <summary>
    /// N = Normal
    /// C = Cancelada
    /// E = Extraviada
    /// </summary>
    public enum RpsStatus
    {
        /// <summary>
        /// Normal
        /// </summary>
        Normal = 1,

        /// <summary>
        /// Cancelada
        /// </summary>
        Canceled = 2,

        /// <summary>
        /// Extraviada
        /// </summary>
        Lost = 4
    }

    /// <summary>
    /// T = Tributação no município
    /// F = Tributação fora do município
    /// E = Exportação
    /// I = Isento
    /// I = Imune
    /// J = Exigibilidade suspensa por decisão judicial
    /// A = Exigibilidade suspensa por procedimento administrativo
    /// </summary>
    public enum TaxationType
    {
        /// <summary>
        /// Nenhum
        /// </summary>
        [Display(Name = "Nenhum")]
        None = 0,

        /// <summary>
        /// Tributação dentro do mesmo município
        /// </summary>
        [Display(Name = "Tributação dentro do mesmo município")]
        WithinCity = 1,

        /// <summary>
        /// Tributação fora do município
        /// </summary>
        [Display(Name = "Tributação fora do município")]
        OutsideCity = 2,

        /// <summary>
        /// Exportação
        /// </summary>
        [Display(Name = "Exportação")]
        Export = 4,

        /// <summary>
        /// Isento
        /// </summary>
        [Display(Name = "Isento")]
        Free = 8,

        /// <summary>
        /// Imune
        /// </summary>
        [Display(Name = "Imune")]
        Immune = 16,

        /// <summary>
        /// Exigibilidade suspensa por decisão judicial
        /// </summary>
        [Display(Name = "Suspensa por decisão judicial")]
        SuspendedCourtDecision = 32,

        /// <summary>
        /// Exigibilidade suspensa por procedimento administrativo
        /// </summary>
        [Display(Name = "Suspensa por procedimento administrativo")]
        SuspendedAdministrativeProcedure = 64,

        /// <summary>
        /// Tributação fora do município porém isento
        /// </summary>
        [Display(Name = "Tributação fora do município porém isento")]
        OutsideCityFree = OutsideCity | Free,

        /// <summary>
        /// Tributação fora do município porém imune
        /// </summary>
        [Display(Name = "Tributação fora do município porém imune")]
        OutsideCityImmune = OutsideCity | Immune,

        /// <summary>
        /// Tributação fora do município porém suspensa
        /// </summary>
        [Display(Name = "Tributação fora do município porém suspensa")]
        OutsideCitySuspended = SuspendedCourtDecision | Free,

        /// <summary>
        /// Tributação fora do município porém suspensa
        /// </summary>
        [Display(Name = "Tributação fora do município porém suspensa por procedimento administrativo")]
        OutsideCitySuspendedAdministrativeProcedure = SuspendedAdministrativeProcedure | Free,
    }

    public enum ApiEnvironment
    {
        [Display(Name = "Development")]
        Development = 0,
        [Display(Name = "Production")]
        Production = 1,
        [Display(Name = "Staging")]
        Staging = 2
    }
}