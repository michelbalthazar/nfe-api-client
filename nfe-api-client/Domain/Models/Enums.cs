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
        NaturalPerson = 2,

        /// <summary>
        /// Pessoa Jurídica
        /// </summary>
        LegalEntity = 4,

        /// <summary>
        /// Pessoa Jurídica (obsoleto)
        /// </summary>
        LegalPerson = 4,

        /// <summary>
        /// Prestador de serviço (uso interno)
        /// </summary>
        Company = 8,

        /// <summary>
        /// Cliente (uso interno)
        /// </summary>
        Customer = 16
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

    public enum LegalNature
    {
        [Display(Name = "201-1 Empresa Pública")]
        EmpresaPublica = 2011,
        [Display(Name = "203-8 Sociedade de Economia Mista")]
        SociedadeEconomiaMista = 2038,
        [Display(Name = "204-6 Sociedade Anônima Aberta")]
        SociedadeAnonimaAberta = 2046,
        [Display(Name = "205-4 Sociedade Anônima Fechada")]
        SociedadeAnonimaFechada = 2054,
        [Display(Name = "206-2 Sociedade Empresária Limitada")]
        SociedadeEmpresariaLimitada = 2062,
        [Display(Name = "207-0 Sociedade Empresária em Nome Coletivo")]
        SociedadeEmpresariaEmNomeColetivo = 2070,
        [Display(Name = "208-9 Sociedade Empresária em Comandita Simples")]
        SociedadeEmpresariaEmComanditaSimples = 2089,
        [Display(Name = "209-7 Sociedade Empresária em Comandita por Ações")]
        SociedadeEmpresariaEmComanditaporAcoes = 2097,
        [Display(Name = "212-7 Sociedade em Conta de Participação")]
        SociedadeemContaParticipacao = 2127,
        [Display(Name = "213-5 Empresário (Individual)")]
        Empresario = 2135,
        [Display(Name = "214-3 Cooperativa")]
        Cooperativa = 2143,
        [Display(Name = "215-1 Consórcio de Sociedades")]
        ConsorcioSociedades = 2151,
        [Display(Name = "216-0 Grupo de Sociedades")]
        GrupoSociedades = 2160,
        [Display(Name = "221-6 Empresa Domiciliada no Exterior")]
        EmpresaDomiciliadaExterior = 2216,
        [Display(Name = "222-4 Clube/Fundo de Investimento")]
        ClubeFundoInvestimento = 2224,
        [Display(Name = "223-2 Sociedade Simples Pura")]
        SociedadeSimplesPura = 2232,
        [Display(Name = "224-0 Sociedade Simples Limitada")]
        SociedadeSimplesLimitada = 2240,
        [Display(Name = "225-9 Sociedade Simples em Nome Coletivo")]
        SociedadeSimplesEmNomeColetivo = 2259,
        [Display(Name = "226-7 Sociedade Simples em Comandita Simples")]
        SociedadeSimplesEmComanditaSimples = 2267,
        [Display(Name = "227-5 Empresa Binacional")]
        EmpresaBinacional = 2275,
        [Display(Name = "228-3 Consórcio de Empregadores")]
        ConsorcioEmpregadores = 2283,
        [Display(Name = "229-1 Consórcio Simples")]
        ConsorcioSimples = 2291,
        [Display(Name = "230-5 Empresa Individual de Responsabilidade Limitada (de Natureza Empresária)")]
        EireliNaturezaEmpresaria = 2305,
        [Display(Name = "231-3 Empresa Individual de Responsabilidade Limitada (de Natureza Simples)")]
        EireliNaturezaSimples = 2313,
        [Display(Name = "303-4 Serviço Notarial e Registral (Cartório)")]
        ServicoNotarial = 3034,
        [Display(Name = "306-9 Fundação Privada")]
        FundacaoPrivada = 3069,
        [Display(Name = "307-7 Serviço Social Autônomo")]
        ServicoSocialAutonomo = 3077,
        [Display(Name = "308-5 Condomínio Edilício")]
        CondominioEdilicio = 3085,
        [Display(Name = "310-7 Comissão de Conciliação Prévia")]
        ComissaoConciliacaoPrevia = 3107,
        [Display(Name = "311-5 Entidade de Mediação e Arbitragem")]
        EntidadeMediacaoArbitragem = 3115,
        [Display(Name = "312-3 Partido Político")]
        PartidoPolitico = 3123,
        [Display(Name = "313-1 Entidade Sindical")]
        EntidadeSindical = 3131,
        [Display(Name = "320-4 Estabelecimento, no Brasil, de Fundação ou Associação Estrangeiras")]
        EstabelecimentoBrasilFundacaoAssociacaoEstrangeiras = 3204,
        [Display(Name = "321-2 Fundação ou Associação Domiciliada no Exterior")]
        FundacaoAssociacaoDomiciliadaExterior = 3212,
        [Display(Name = "322-0 Organização Religiosa")]
        OrganizacaoReligiosa = 3220,
        [Display(Name = "323-9 Comunidade Indígena")]
        ComunidadeIndigena = 3239,
        [Display(Name = "324-7 Fundo Privado")]
        FundoPrivado = 3247,
        [Display(Name = "399-9 Associação Privada")]
        AssociacaoPrivada = 3999
    }
}