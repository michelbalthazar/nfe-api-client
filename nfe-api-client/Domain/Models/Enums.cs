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

    #region Product

    /// <summary>
    /// Status da nota fiscal
    /// </summary>
    public enum ProductInvoiceStatus
    {
        Error = -1,
        None = 0,
        Created = 1,
        Processing = 2,
        Issued = 3,
        Cancelled = 4
    }

    /// <summary>
    /// Tipo de Operação (tpNF)
    /// </summary>
    public enum OperationType
    {
        /// <summary>
        /// 1 - Entrada
        /// </summary>
        Incoming = 1,

        /// <summary>
        /// 0 - Saida
        /// </summary>
        Outgoing = 0
    }

    /// <summary>
    /// Identificação do Ambiente (tpAmb)
    /// </summary>
    public enum EnvironmentType
    {
        None = 0,

        /// <summary>
        /// 1 - Produção
        /// </summary>
        Production = 1,

        /// <summary>
        /// 2 - Homologação (testes)
        /// </summary>
        Test = 2
    }


    /// <summary>
    /// Finalidade de emissão da NF-e (finNFe)
    /// </summary>
    public enum PurposeType
    {
        /// <summary>
        /// 4 - Devolução
        /// </summary>
        Devolution = 4,

        /// <summary>
        /// 3 - Ajuste
        /// </summary>
        Adjustment = 3,

        /// <summary>
        /// 2 - Complementar
        /// </summary>
        Complement = 2,

        /// <summary>
        /// 1 - Normal
        /// </summary>
        Normal = 1,

        /// <summary>
        /// 0 - None
        /// </summary>
        None = 0,
    }

    public enum EconomicActivityType
    {
        Main = 1,
        Secondary = 2
    }

    public enum ReceiverStateTaxIndicator
    {
        /// <summary>
        /// 0=Nenhum
        /// </summary>
        None = 0,

        /// <summary>
        /// 1=Contribuinte ICMS (informar a IE do destinatário);
        /// </summary>
        TaxPayer = 1,

        /// <summary>
        /// 2=Contribuinte isento de Inscrição no cadastro de Contribuintes;
        /// </summary>
        Exempt = 2,

        /// <summary>
        /// 9=Não Contribuinte, que pode ou não possuir Inscrição Estadual no Cadastro de Contribuintes do ICMS.
        /// </summary>
        NonTaxPayer = 9
    }

    public enum PaymentMethod
    {
        /// <summary>
        /// 01 - Dinheiro
        /// </summary>
        Cash = 01,

        /// <summary>
        /// 02 - Cheque
        /// </summary>
        Cheque = 02,

        /// <summary>
        /// 03 - Cartão de Crédito
        /// </summary>
        CreditCard = 03,

        /// <summary>
        /// 04 - Cartão de Débito
        /// </summary>
        DebitCard = 04,

        /// <summary>
        /// 05 - Crédito Loja
        /// </summary>
        StoreCredict = 05,

        /// <summary>
        /// 10 - Vale Alimentação
        ///</summary> 
        FoodVouchers = 10,

        /// <summary>
        /// 11 - Vale Refeição
        /// </summary>
        MealVouchers = 11,

        /// <summary>
        /// 12 - Vale Presente
        /// </summary>
        GiftVouchers = 12,

        /// <summary>
        /// 13 - Vale Combustível
        /// </summary>
        FuelVouchers = 13,

        /// <summary>
        /// 15 - Boleto Bancário
        /// </summary>
        BankBill = 15,

        /// <summary>
        /// 90 - Sem Pagamento
        /// </summary>
        WithoutPayment = 90,

        /// <summary>
        /// 99 - Outros
        /// </summary>
        Others = 99,
    }

    public enum FlagCard
    {
        Visa = 01,
        Mastercard = 02,
        AmericanExpress = 03,
        Sorocred = 04,
        Other = 99
    }

    /// <summary>
    ///     1 - Pagamento integrado com o sistema de automação da empresa(Ex.: equipamento TEF, Comércio Eletrônico)
    ///     2 - Pagamento não integrado com o sistema de automação da empresa(Ex.: equipamento POS);
    ///     
    /// </summary>
    public enum IntegrationPaymentType
    {
        Integrated = 1,
        NotIntegrated = 2
    }

    public enum ShippingModality
    {
        /// <summary>
        /// 0=Por conta do emitente;
        /// </summary>
        ByIssuer = 0,

        /// <summary>
        /// 1=Por conta do destinatário/remetente;
        /// </summary>
        ByReceiver = 1,

        /// <summary>
        /// 2=Por conta de terceiros;
        /// </summary>
        ByThirdParties = 2,

        /// <summary>
        /// 9=Sem frete. (V2.0)
        /// </summary>
        Free = 9,
    }

    public enum StateCode
    {
        RO = 11,
        AC = 12,
        AM = 13,
        RR = 14,
        PA = 15,
        AP = 16,
        TO = 17,
        MA = 21,
        PI = 22,
        CE = 23,
        RN = 24,
        PB = 25,
        PE = 26,
        AL = 27,
        SE = 28,
        BA = 29,
        MG = 31,
        ES = 32,
        RJ = 33,
        SP = 35,
        PR = 41,
        SC = 42,
        RS = 43,
        MS = 50,
        MT = 51,
        GO = 52,
        DF = 53,

        /// <summary>
        /// 99 - Exterior
        ///</summary> 
        EX = 99,
        NA = 0
    }

    /// <summary>
    /// Tipo Transporte Internacional
    /// </summary>
    public enum InternationalTransportType
    {
        /// <summary>
        /// 1=None;
        /// </summary>
        None = 0,

        /// <summary>
        /// 1=Marítima;
        /// </summary>
        Maritime = 1,

        /// <summary>
        /// 2=Fluvial;
        /// </summary>
        River = 2,

        /// <summary>
        /// 3=Lacustre;
        /// </summary>
        Lake = 3,

        /// <summary>
        ///  4=Aérea;
        /// </summary>
        Airline = 4,

        /// <summary>
        /// 5=Postal
        /// </summary>
        Postal = 5,

        /// <summary>
        /// 6=Ferroviária;
        /// </summary>
        Railway = 6,

        /// <summary>
        /// 7=Rodoviária;
        /// </summary>
        Highway = 7,

        /// <summary>
        ///  8=Conduto / Rede Transmissão;
        /// </summary>
        Network = 8,

        /// <summary>
        /// 9=Meios Próprios;
        /// </summary>
        Own = 9,

        /// <summary>
        /// 10=Entrada / Saída ficta;
        /// </summary>
        Ficta = 10,

        /// <summary>
        /// 11=Courier
        /// </summary>
        Courier = 11,

        /// <summary>
        /// 12=Handcarry.
        /// </summary>
        Handcarry = 12
    }


    /// <summary>
    ///   Tipo de Intermediação
    /// </summary>
    public enum IntermediationType
    {
        /// <summary>
        /// 1=None;
        /// </summary>
        None = 0,

        /// <summary>
        ///  1=Importação por conta própria;
        /// </summary>
        ByOwn = 1,

        /// <summary>
        ///  2=Importação por conta e ordem;
        /// </summary>
        ImportOnBehalf = 2,

        /// <summary>
        ///  3=Importação por encomenda;
        /// </summary>
        ByOrder = 3
    }

    /// <summary>
    /// Campo será preenchido quando o campo anterior estiver
    /// preenchido.Informar o motivo da desoneração:
    /// </summary>
    public enum ExemptReason
    {
        /// <summary>
        /// 3=Uso na agropecuária
        /// </summary>
        Agriculture = 3,

        /// <summary>
        /// 9=Outros
        /// </summary>
        Others = 9,

        /// <summary>
        /// 12=Órgão de fomento e desenvolvimento agropecuário
        /// </summary>
        DevelopmentEntities = 12
    }

    /// <summary>
    /// Indicador de Presença (indPres )
    /// </summary>
    public enum ConsumerPresenceType
    {
        /// <summary>
        /// 0 - Não se aplica (ex: nf complementar ou ajuste)
        /// </summary>
        None = 0,

        /// <summary>
        /// 1 - Operação presencial
        /// </summary>
        Presence = 1,

        /// <summary>
        /// 2 - Internet, operação não presencial
        /// </summary>
        Internet = 2,

        /// <summary>
        /// 3 - Teleatendimento, operação não presencial
        /// </summary>
        Telephone = 3,

        /// <summary>
        /// 4 - NFC-e em operação com entrega a domicílio
        /// </summary>
        Delivery = 4,

        /// <summary>
        /// 9 - Outros, operação não presencial
        /// </summary>
        OthersNonPresenceOperation = 9,
    }

    /// <summary>
    /// Indica operação com Consumidor final (indFinal)
    /// </summary>
    public enum ConsumerType
    {
        /// <summary>
        /// Normal (Padrão)
        /// </summary>
        Normal = 1,

        /// <summary>
        /// Consumidor final
        /// </summary>
        FinalConsumer = 0
    }

    public enum PrintType
    {
        /// <summary>
        /// 0 - Sem geração de DANFE
        /// </summary>
        None = 0,

        /// <summary>
        /// 1 - DANFE Normal Retrato
        /// </summary>
        NFeNormalPortrait = 1,

        /// <summary>
        /// 1 - DANFE Normal Paisagem
        /// </summary>
        NFeNormalLandscape = 2,

        /// <summary>
        /// 3 - DANFE Simplificado
        /// </summary>
        NFeSimplified = 3,

        /// <summary>
        /// 4 - DANFE NFC-e
        /// </summary>
        DANFE_NFC_E = 4,

        /// <summary>
        /// 5 - DANFE NFC-e em mensagem eletrônica
        /// </summary>
        DANFE_NFC_E_MSG_ELETRONICA = 5,
    }

    /// <summary>
    /// Identificador de local de destino da operação (idDest)
    /// </summary>
    public enum Destination
    {
        /// <summary>
        /// 3 - Operação com exterior
        /// </summary>
        International_Operation = 3,

        /// <summary>
        /// 2 - Operação interestadual
        /// </summary>
        Interstate_Operation = 2,

        /// <summary>
        /// 1 - Operação interna
        /// </summary>
        Internal_Operation = 1,

        /// <summary>
        /// 0 - Nenhum
        /// </summary>
        None = 0
    }
    #endregion Product
}