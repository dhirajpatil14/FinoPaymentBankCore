using Utility.Attributes;

namespace Common.Enums
{
    public enum MessageTypeId
    {
        [IntValueAttribute(1)]
        LoginSuccess = 1,
        [IntValueAttribute(2)]
        LoginUnSuccess = 2,
        [IntValueAttribute(3)]
        Exception = 3,
        [IntValueAttribute(4)]
        CustomerAccountExists = 4,
        [IntValueAttribute(5)]
        CustomerAccountDoesNotExists = 5,
        [IntValueAttribute(6)]
        BeneficiaryDetailsFound = 6,
        [IntValueAttribute(7)]
        BeneficiaryDetailsNotFound = 7,
        [IntValueAttribute(8)]
        BeneficiaryAdded = 8,
        [IntValueAttribute(9)]
        BeneficiaryCouldNotBeAdded = 9,
        [IntValueAttribute(10)]
        IFSCDetailsFound = 10,
        [IntValueAttribute(11)]
        IFSCDetailsNotFound = 11,
        [IntValueAttribute(12)]
        BiometricVerificationSuccess = 12,
        [IntValueAttribute(13)]
        BiometricVerificationFailed = 13,
        [IntValueAttribute(14)]
        AccountToAccountFundTransferSuccess = 14,
        [IntValueAttribute(15)]
        AccountToAccountFundTransferFailed = 15,
        [IntValueAttribute(16)]
        IMPSFundTransferSuccess = 16,
        [IntValueAttribute(17)]
        IMPSFundTransferFailed = 17,
        [IntValueAttribute(18)]
        NEFTFundTransferSuccess = 18,
        [IntValueAttribute(19)]
        NEFTFundTransferFailed = 19,
        [IntValueAttribute(20)]
        RTGSFundTransferSuccess = 20,
        [IntValueAttribute(21)]
        RTGSFundTransferFailed = 21,
        [IntValueAttribute(22)]
        KYCExists = 22,
        [IntValueAttribute(23)]
        KYCDoesNotExists = 23,
        [IntValueAttribute(24)]
        CustomerDocumentsUploadedSuccessfully = 24,
        [IntValueAttribute(25)]
        CustomerDocumentsCouldNotbeUploadedSuccessfully = 25,
        [IntValueAttribute(26)]
        FingerPrintDetailsisSaved = 26,
        [IntValueAttribute(27)]
        FingerPrintDetailsisnotSaved = 27,
        [IntValueAttribute(28)]
        CustomerAccountNumberIsCreated = 28,
        [IntValueAttribute(361)]
        AccountOpeningCardLinkedSuccess = 361,
        [IntValueAttribute(29)]
        CustomerAccountNumberIsNotCreated = 29,
        [IntValueAttribute(30)]
        CashDepositSuccess = 30,
        [IntValueAttribute(31)]
        CashDepositFailed = 31,
        [IntValueAttribute(731)]
        CASAPLUSFundTransferSuccess = 731,
        [IntValueAttribute(732)]
        CASAPLUSFundTransferFailed = 732,
        [IntValueAttribute(733)]
        CASAPLUSViewBalanceSuccess = 733,
        [IntValueAttribute(734)]
        CASAPLUSViewBalanceFailed = 734,
        [IntValueAttribute(808)]
        CASAPLUSViewStatementSuccess = 808,
        [IntValueAttribute(809)]
        CASAPLUSViewStatementFailed = 809,
        [IntValueAttribute(32)]
        CashWithdrawSuccess = 32,
        [IntValueAttribute(33)]
        CashWithdrawFailed = 33,
        [IntValueAttribute(50)]
        OTPGeneratedSuccessfully = 50,
        [IntValueAttribute(51)]
        OTPGenerationFailed = 51,
        [IntValueAttribute(52)]
        OTPAlreadyUsed = 52,
        [IntValueAttribute(53)]
        OTPVerifiedSuccessfully = 53,
        [IntValueAttribute(54)]
        OTPVerificationFailed = 54,
        [IntValueAttribute(55)]
        OTPHasBeenExpired = 55,
        [IntValueAttribute(56)]
        SMSSentSuccessfully = 56,
        [IntValueAttribute(57)]
        SMSSendingFailed = 57,
        [IntValueAttribute(58)]
        InsertOTPSuccess = 58,
        [IntValueAttribute(59)]
        InsertOTPFailed = 59,
        [IntValueAttribute(60)]
        InsertSMSSuccess = 60,
        [IntValueAttribute(61)]
        InsertSMSFailed = 61,
        [IntValueAttribute(64)]
        ServerError = 64,
        [IntValueAttribute(65)]
        AuthenticateSuccess = 65,
        [IntValueAttribute(66)]
        AuthenticateUnSuccess = 66,
        [IntValueAttribute(67)]
        SessionExpired = 67,
        [IntValueAttribute(68)]
        NotificationSentSuccessfully = 68,
        [IntValueAttribute(69)]
        NotificationSentFailed = 69,
        [IntValueAttribute(70)]
        CustomerDetailsFound = 70,
        [IntValueAttribute(71)]
        CustomerDetailsNotFound = 71,
        [IntValueAttribute(72)]
        BeneficiaryDeleted = 72,
        [IntValueAttribute(73)]
        BeneficiaryCouldNotDeleted = 73,
        [IntValueAttribute(74)]
        EmailloadingSuccessful = 74,
        [IntValueAttribute(75)]
        EmailloadingFailed = 75,
        [IntValueAttribute(76)]
        CashCountSuccess = 76,
        [IntValueAttribute(77)]
        CashCountError = 77,
        [IntValueAttribute(78)]
        MiniStatementSuccessful = 78,
        [IntValueAttribute(79)]
        MiniStatementFailed = 79,
        [IntValueAttribute(1011)]
        InterestCertificateFailed = 1011,
        [IntValueAttribute(1012)]
        InterestCertificateSuccessful = 1012,
        [IntValueAttribute(80)]
        IFSCCodeSuccess = 80,
        [IntValueAttribute(81)]
        IFSCCodeError = 81,
        [IntValueAttribute(82)]
        InstaKitNumberSuccess = 82,
        [IntValueAttribute(83)]
        InstaKitNumberFailed = 83,
        [IntValueAttribute(84)]
        NSDLSuccess = 84,
        [IntValueAttribute(85)]
        NSDLFailed = 85,
        [IntValueAttribute(86)]
        FingerPrintMatchSucess = 86,
        [IntValueAttribute(87)]
        FingerPrintMatchFailed = 87,
        [IntValueAttribute(88)]
        AUADataFetchSucess = 88,
        [IntValueAttribute(89)]
        AUADataFetchFailed = 89,
        [IntValueAttribute(90)]
        UIDFoundSucess = 90,
        [IntValueAttribute(91)]
        UIDFoundFailed = 91,
        [IntValueAttribute(92)]
        LogoutSuccessful = 92,
        [IntValueAttribute(93)]
        LogoutFailed = 93,
        [IntValueAttribute(94)]
        NEFTTransactionTimingSuccess = 94,
        [IntValueAttribute(95)]
        NEFTTransactionTimingFailed = 95,
        [IntValueAttribute(96)]
        AuthContextDetailsSuccess = 96,
        [IntValueAttribute(97)]
        AuthContextDetailsFailed = 97,
        [IntValueAttribute(98)]
        UnableToGetEncryptionKey = 98,
        [IntValueAttribute(99)]
        TellerProofSuccess = 99,
        [IntValueAttribute(100)]
        TellerProofFailed = 100,
        [IntValueAttribute(102)]
        BranchProofSuccess = 102,
        [IntValueAttribute(103)]
        BranchProofFailed = 103,
        [IntValueAttribute(104)]
        AccountHistorySuccess = 104,
        [IntValueAttribute(105)]
        AccountHistoryFailed = 105,
        [IntValueAttribute(106)]
        CustomerUpdateSuccessfully = 106,
        [IntValueAttribute(107)]
        CustomerUpdateFailed = 107,
        [IntValueAttribute(108)]
        ChargesCheckSuccessfully = 108,
        [IntValueAttribute(109)]
        ChargesCheckFailed = 109,
        [IntValueAttribute(110)]
        PostTransactionSuccessfully = 110,
        [IntValueAttribute(111)]
        PostTransactionFailed = 111,
        [IntValueAttribute(112)]
        DeleteBeneficiarySuccessful = 112,
        [IntValueAttribute(113)]
        DeleteBeneficiaryFailed = 113,
        [IntValueAttribute(114)]
        PanValidationSuccess = 114,
        [IntValueAttribute(115)]
        PanValidationFailed = 115,
        [IntValueAttribute(901)]
        SetSMSCommunicationPreferenceSuccess = 901,
        [IntValueAttribute(902)]
        SetSMSCommunicationPreferenceFailed = 902,
        [IntValueAttribute(116)]
        GetCustomerPhotoSuccess = 116,
        [IntValueAttribute(117)]
        GetCustomerPhotoFailed = 117,
        [IntValueAttribute(118)]
        FpVerificationSuccess = 118,
        [IntValueAttribute(119)]
        FpVerificationFailed = 119,
        [IntValueAttribute(120)]
        UpdateCustomerPhotoSuccess = 120,
        [IntValueAttribute(121)]
        UpdateCustomerPhotoFailed = 121,
        [IntValueAttribute(122)]
        TokenValidationSuccess = 122,
        [IntValueAttribute(123)]
        TokenValidationFailed = 123,
        [IntValueAttribute(124)]
        AddBillerSuccesful = 124,
        [IntValueAttribute(125)]
        AddBillerFailed = 125,
        [IntValueAttribute(126)]
        RechargeQuerySuccessful = 126,
        [IntValueAttribute(127)]
        RechargeQueryFailed = 127,
        [IntValueAttribute(128)]
        ValidateRechargeSuccessful = 128,
        [IntValueAttribute(129)]
        ValidateRechargeFailed = 129,
        [IntValueAttribute(130)]
        PaymentandRechargeDetailsSourceDebitSuccessful = 130,
        [IntValueAttribute(131)]
        PaymentandRechargeDetailsSourceDebitFailed = 131,
        [IntValueAttribute(132)]
        DeleteBillersSuccessful = 132,
        [IntValueAttribute(133)]
        DeleteBillersFailed = 133,
        [IntValueAttribute(134)]
        ViewBillsSuccessful = 134,
        [IntValueAttribute(135)]
        ViewBillsFailed = 135,
        [IntValueAttribute(136)]
        PaymentOnlyDetailsSuccesful = 136,
        [IntValueAttribute(137)]
        PaymentOnlyDetailsFailed = 137,
        [IntValueAttribute(138)]
        ViewBillerAccountSuccessful = 138,
        [IntValueAttribute(139)]
        ViewBillerAccountFailed = 139,
        [IntValueAttribute(140)]
        ViewLastPaidBillsSuccessful = 140,
        [IntValueAttribute(141)]
        ViewLastPaidBillsFailed = 141,
        [IntValueAttribute(142)]
        CheckTransactionStatusSuccessful = 142,
        [IntValueAttribute(143)]
        CheckTransactionStatusFailed = 143,
        [IntValueAttribute(144)]
        BillerValidationsSuccessful = 144,
        [IntValueAttribute(145)]
        BillerValidationsFailed = 145,
        [IntValueAttribute(146)]
        SetAutoPaySuccesful = 146,
        [IntValueAttribute(147)]
        SetAutoPayFailed = 147,
        [IntValueAttribute(148)]
        ViewScheduledBillsSuccesful = 148,
        [IntValueAttribute(149)]
        ViewScheduledBillsFailed = 149,
        [IntValueAttribute(150)]
        Modify_DeleteAutoPaySuccessful = 150,
        [IntValueAttribute(151)]
        Modify_DeleteAutoPayFailed = 151,
        [IntValueAttribute(152)]
        StopScheduledTransactionSuccessful = 152,
        [IntValueAttribute(153)]
        StopScheduledTransactionFailed = 153,
        [IntValueAttribute(154)]
        BillFetchDetailsSuccesful = 154,
        [IntValueAttribute(155)]
        BillFetchDetailsFailed = 155,
        [IntValueAttribute(156)]
        FPTemplatenotfound = 156,
        [IntValueAttribute(158)]
        IMPSWalletAccountSuccess = 158,
        [IntValueAttribute(159)]
        IMPSWalletAccountFailed = 159,
        [IntValueAttribute(160)]
        PassbookUpdationSuccessful = 160,
        [IntValueAttribute(161)]
        PassbookUpdationFailed = 161,
        [IntValueAttribute(162)]
        AadhaarLPGSeedingSuccessful = 162,
        [IntValueAttribute(163)]
        AadhaarLPGSeedingFailed = 163,
        [IntValueAttribute(164)]
        NomineeAdditionSuccessful = 164,
        [IntValueAttribute(165)]
        NomineeAdditionFailed = 165,
        [IntValueAttribute(166)]
        NominationupadationSuccessful = 166,
        [IntValueAttribute(167)]
        NominationupadationFailed = 167,
        [IntValueAttribute(168)]
        DBTLSeedingSuccessful = 168,
        [IntValueAttribute(169)]
        DBTLSeedingFailed = 169,
        [IntValueAttribute(170)]
        RevisionDetailsSuccess = 170,
        [IntValueAttribute(171)]
        RevisionDetailsFailed = 171,
        [IntValueAttribute(172)]
        GetDMSdataSuccess = 172,
        [IntValueAttribute(173)]
        GetDMSdataFailed = 173,
        //Added by Vaibhav
        #region [Krazy Bee Loan]
        [IntValueAttribute(700605)]
        KrazybeeDataInsertionSuccess = 700605,
        [IntValueAttribute(700606)]
        KrazybeeDataInsertionFailed = 700606,
        [IntValueAttribute(700607)]
        IIFlCustomerNotExists = 700607,
        [IntValueAttribute(700608)]
        IIFlCustomerExists = 700608,
        #endregion

        #region [Digital Loan]
        [IntValueAttribute(700615)]
        Loantokencreationfailed = 700615,
        [IntValueAttribute(700616)]
        DocumentMasterfound = 700616,
        [IntValueAttribute(700617)]
        DocumentMasterNotfound = 700617,
        [IntValueAttribute(700618)]
        LoanRequestSubmittedSuccessfully = 700618,
        [IntValueAttribute(700619)]
        LoanRequestFailed = 700619,
        [IntValueAttribute(700200)]
        Lenderfielddetailsfound = 700620,
        [IntValueAttribute(700621)]
        Lenderfielddetailsnotfound = 700621,
        [IntValueAttribute(700622)]
        Loanstatusavailable = 700622,
        [IntValueAttribute(700623)]
        Loanstatusnotavailable = 700623,
        [IntValueAttribute(700624)]
        Lenderdetailsfound = 700624,
        [IntValueAttribute(700625)]
        Lenderdetailsnotfound = 700625,
        [IntValueAttribute(700630)]
        Eligible = 700630,
        [IntValueAttribute(700631)]
        NotEligible = 700631,
        [IntValueAttribute(700632)]
        LoanDetailsFound = 700632,
        [IntValueAttribute(700633)]
        LoanDetailsNotFound = 700633,
        [IntValueAttribute(700634)]
        WithdrawalSuccessfull = 700634,
        [IntValueAttribute(700635)]
        WithdrawalFailed = 700635,
        [IntValueAttribute(700636)]
        AccountStatementGenerate = 700636,
        [IntValueAttribute(700637)]
        AccountStatementFailed = 700637,
        [IntValueAttribute(700638)]
        RepaymentDone = 700638,
        [IntValueAttribute(700639)]
        RepaymentFails = 700639,
        #endregion

        #region [Cleaver Tap Myprofile]
        [IntValueAttribute(700609)]
        PreferredlanguageSelected = 700609,
        [IntValueAttribute(700610)]
        PreferredlanguageNotAvailable = 700610,
        [IntValueAttribute(700611)]
        PreferredlanguageSaved = 700611,
        [IntValueAttribute(700612)]
        PreferredlanguageNotSaved = 700612,
        #endregion
        //
        [IntValueAttribute(174)]
        SimpleWalletCreationSuccess = 174,
        [IntValueAttribute(175)]
        SimpleWalletCreationUnSuccess = 175,
        [IntValueAttribute(176)]
        AccountRelationshipAddSuccess = 176,
        [IntValueAttribute(177)]
        AccountRelationshipAddFailed = 177,
        [IntValueAttribute(178)]
        AccountRelationshipDeleteSuccess = 178,
        [IntValueAttribute(179)]
        AccountRelationshipDeleteFailed = 179,
        [IntValueAttribute(180)]
        SearchDMSDetailsSuccess = 180,
        [IntValueAttribute(181)]
        SearchDMSDetailsFailed = 181,
        [IntValueAttribute(182)]
        CustomerDataUpdateSuccess = 182,
        [IntValueAttribute(183)]
        CustomerDataUpdateFailed = 183,
        [IntValueAttribute(184)]
        IMPSTransactionUpdateSuccess = 184,
        [IntValueAttribute(185)]
        IMPSTransactionUpdateFailed = 185,
        [IntValueAttribute(186)]
        UserAlreadyExist = 186,
        [IntValueAttribute(187)]
        CustomerDetailsSuccessful = 187,
        [IntValueAttribute(188)]
        CustomerDetailsFailed = 188,
        [IntValueAttribute(189)]
        AccountDetailsSuccessful = 189,
        [IntValueAttribute(190)]
        AccountDetailsFailed = 190,
        [IntValueAttribute(191)]
        EmailSendSuccessfully = 191,
        [IntValueAttribute(192)]
        EmailSendFailed = 192,
        [IntValueAttribute(193)]
        ServiceReqChargesSuccessful = 193,
        [IntValueAttribute(194)]
        ServiceReqChargesFailed = 194,
        [IntValueAttribute(197)]
        EsbOtpGenerationSuccessful = 197,
        [IntValueAttribute(198)]
        EsbOtpGenerationFailed = 198,
        [IntValueAttribute(199)]
        EsbOtpVerifySuccessful = 199,
        [IntValueAttribute(200)]
        EsbOtpVerifyFailed = 200,
        [IntValueAttribute(201)]
        EsbEsbSMSTemplateSuccessful = 201,
        [IntValueAttribute(202)]
        EsbEsbSMSTemplateFailed = 202,
        [IntValueAttribute(203)]
        OperatorandPlanDetailsFetchSuccessful = 203,
        [IntValueAttribute(204)]
        OperatorandPlanDetailsFetchFailed = 204,
        [IntValueAttribute(205)]
        MasterDataFound = 205,
        [IntValueAttribute(206)]
        MasterDataCouldNotFound = 206,
        [IntValueAttribute(207)]
        TransactionProfileDetailsSuccessful = 207,
        [IntValueAttribute(208)]
        TransactionProfileDetailsFailed = 208,
        [IntValueAttribute(209)]
        MasterVersionReturnSuccessFul = 209,
        [IntValueAttribute(210)]
        MasterVersionReturnFailed = 210,
        [IntValueAttribute(211)]
        MasterCacheResetSuccessful = 211,
        [IntValueAttribute(212)]
        MasterCacheResetfailed = 212,
        [IntValueAttribute(215)]
        GetGLAccountBalanceSuccess = 215,
        [IntValueAttribute(216)]
        GetGLAccountBalanceFailed = 216,
        [IntValueAttribute(217)]
        RemoveAccountRestrictionSuccess = 217,
        [IntValueAttribute(218)]
        RemoveAccountRestrictionFailed = 218,
        [IntValueAttribute(219)]
        GetTransactionAuthProfileSuccess = 219,
        [IntValueAttribute(220)]
        GetTransactionAuthProfileFailed = 220,
        [IntValueAttribute(221)]
        UserUnlockSuccess = 221,
        [IntValueAttribute(222)]
        UserUnlockFailed = 222,
        //UnBlockUser
        [IntValueAttribute(800)]
        UnblockAuthFailed = 800,
        [IntValueAttribute(801)]
        UnblockUserSuccess = 801,
        [IntValueAttribute(802)]
        UnblockUserFailed = 802,
        [IntValueAttribute(803)]
        UnblockUserAlreadyActive = 803,
        [IntValueAttribute(804)]
        UnblockUnabletoProcess = 804,
        [IntValueAttribute(805)]
        UnblockRequestError = 805,
        [IntValueAttribute(806)]
        UnblockUserFound = 806,
        [IntValueAttribute(807)]
        UnblockUserR1NotFound = 807,
        [IntValueAttribute(810)]
        UnblockUserPasswordChangedSuccess = 810,
        [IntValueAttribute(815)]
        UnblockUserMerchantDeviceNotAllowed = 815,
        [IntValueAttribute(818)]
        UnblockUserMerchantPANDoesnotMatch = 818,
        [IntValueAttribute(819)]
        UnblockUserMerchantDOBDoesnotMatch = 819,
        [IntValueAttribute(820)]
        UnblockUserMerchantDOBandPANDoesnotMatch = 820,
        [IntValueAttribute(823)]
        UnblockUserMerchantPANNotFound = 823,
        [IntValueAttribute(824)]
        UnblockUserMerchantContacthelpdesk = 824,
        [IntValueAttribute(825)]
        UnblockUserMerchantExceedsLoginLimit = 825,

        //End-UnBlockUser
        [IntValueAttribute(223)]
        setMobileBankingPINSuccess = 223,
        [IntValueAttribute(224)]
        setMobileBankingPINFailed = 224,
        [IntValueAttribute(225)]
        RegisterMBCustomerSuccess = 225,
        [IntValueAttribute(226)]
        RegisterMBCustomerFailed = 226,
        [IntValueAttribute(227)]
        changemobilebankingpinsuccess = 227,
        [IntValueAttribute(228)]
        changemobilebankingpinfailed = 228,
        [IntValueAttribute(229)]
        GetSecretQuestionSuccess = 229,
        [IntValueAttribute(230)]
        GetSecretQuestionFailed = 230,
        [IntValueAttribute(231)]
        UpdateSecretQuestionSuccess = 231,
        [IntValueAttribute(232)]
        UpdateSecretFailed = 232,
        [IntValueAttribute(641)]
        SetMerchantStatusSuccess = 641,
        [IntValueAttribute(642)]
        SetMerchantStatusFailed = 642,
        [IntValueAttribute(643)]
        GetMerchantStatusSuccess = 643,
        [IntValueAttribute(644)]
        GetMerchantStatusFailed = 644,
        [IntValueAttribute(235)]
        ValidUserSuccess = 235,
        [IntValueAttribute(236)]
        ValidUserFailed = 236,
        [IntValueAttribute(237)]
        EncryptedKeySuccess = 237,
        [IntValueAttribute(238)]
        EmcryptedKeyFailed = 238,
        [IntValueAttribute(252)]
        BillPaymentTransactionFailed = 252,
        [IntValueAttribute(253)]
        BillPaymentTransactionSuccess = 253,
        [IntValueAttribute(615)]
        BillPayTransactioninProcesskindlycheckministatement = 615,
        [IntValueAttribute(616)]
        RechargeTransactioninProcesskindlycheckministatement = 616,
        [IntValueAttribute(254)]
        ValidateUserSecretQuestionSuccess = 254,
        [IntValueAttribute(255)]
        ValidateUserSecretQuestionFailed = 255,
        [IntValueAttribute(266)]
        RechargeTransactionFailed = 266,
        [IntValueAttribute(267)]
        RechargeTransactionSuccess = 267,
        [IntValueAttribute(270)]
        PasswordResetSuccess = 270,
        [IntValueAttribute(271)]
        PasswordResetFailed = 271,
        [IntValueAttribute(272)]
        PasswordChangeSuccess = 272,
        [IntValueAttribute(273)]
        PasswordChangeFailed = 273,
        [IntValueAttribute(274)]
        SecretQuestionListSuccess = 274,
        [IntValueAttribute(275)]
        SecretQuestionListFailed = 275,
        [IntValueAttribute(213)]
        ExtraBeneficiaryDetailsFound = 213,
        [IntValueAttribute(214)]
        ExtraBeneficiaryDetailsNotFound = 214,
        [IntValueAttribute(215)]
        InvalidRequest = 215,
        [IntValueAttribute(256)]
        GLAccountBalanceDetailsFound = 256,
        [IntValueAttribute(257)]
        GLAccountBalanceDetailsNotFound = 257,

        //BillPaymentTransactionFailed = 252,
        //BillPaymentTransactionSuccess = 253,

        [IntValueAttribute(264)]
        InterBankTransferSuccess = 264,
        [IntValueAttribute(265)]
        InterBankTransferFailed = 265,

        //RechargeTransactionFailed = 266,
        //RechargeTransactionSuccess = 267,

        [IntValueAttribute(268)]
        RemitanceAccountOpeningSuccess = 268,
        [IntValueAttribute(269)]
        RemitanceAccountOpeningFailed = 269,
        [IntValueAttribute(298)]
        InsurancePremiumPaidSuccessful = 298,
        [IntValueAttribute(299)]
        InsurancePremiumPaidFailed = 299,
        [IntValueAttribute(613)]
        InsuranceClaimSuccessful = 613,
        [IntValueAttribute(614)]
        InsuranceClaimFailed = 614,
        [IntValueAttribute(743)]
        PrintFormatDataFound = 743,
        [IntValueAttribute(744)]
        PrintFormatDataNotFound = 744,
        [IntValueAttribute(745)]
        ResetPrintFormatMasterDataSuccess = 745,
        [IntValueAttribute(746)]
        ResetPrintFormatMasterDataFailed = 746,
        [IntValueAttribute(600)]
        GetExternalAccountDetailsSuccessful = 600,
        [IntValueAttribute(601)]
        GetExternalAccountDetailsFailed = 601,
        [IntValueAttribute(300)]
        BeneVerificationChargesSuccess = 300,
        [IntValueAttribute(301)]
        BeneVerificationChargesFailed = 301,
        [IntValueAttribute(278)]
        SequenceListReturnSuccessful = 278,
        [IntValueAttribute(279)]
        SequenceListReturnfailed = 279,
        [IntValueAttribute(280)]
        TabControlsReturnSuccessFul = 280,
        [IntValueAttribute(281)]
        TabControlsReturnFailed = 281,
        [IntValueAttribute(282)]
        CreateCustomerWalletSuccess = 282,
        [IntValueAttribute(283)]
        CreateCustomerWalletFailed = 283,
        [IntValueAttribute(284)]
        FindCustomerSuccess = 284,
        [IntValueAttribute(285)]
        FindCustomerFailed = 285,
        [IntValueAttribute(286)]
        AuthProfileSuccess = 286,
        [IntValueAttribute(287)]
        AuthProfileFailed = 287,
        [IntValueAttribute(288)]
        AuthenticateSuccesss = 288,
        [IntValueAttribute(289)]
        AuthenticateFailed = 289,
        [IntValueAttribute(290)]
        PublicKeySendSuccess = 290,
        [IntValueAttribute(291)]
        PublicKeySendFailed = 291,
        [IntValueAttribute(292)]
        MenuListByChannelSentSuccess = 292,
        [IntValueAttribute(293)]
        MenuListByChannelFailed = 293,
        [IntValueAttribute(294)]
        ProfileTypeTransByChannelSuccess = 294,
        [IntValueAttribute(295)]
        ProfileTypeTransByChannelFailed = 295,
        [IntValueAttribute(296)]
        ProductTransByChannelSuccess = 296,
        [IntValueAttribute(297)]
        ProductTransByChannelFailed = 297,
        [IntValueAttribute(302)]
        ProductWiseTransactionListSuccess = 302,
        [IntValueAttribute(303)]
        ProductWiseTransactionListFailed = 303,
        [IntValueAttribute(304)]
        BeneUpdateSuccess = 304,
        [IntValueAttribute(305)]
        BeneUpdateFailed = 305,
        [IntValueAttribute(306)]
        WalkInCustomerDetailsSuccess = 306,
        [IntValueAttribute(307)]
        WalkInCustomerDetailsFailed = 307,
        [IntValueAttribute(308)]
        WalkInTransactionDetailsSuccess = 308,
        [IntValueAttribute(309)]
        WalkInTransactionDetailsFailed = 309,
        [IntValueAttribute(310)]
        AccountLimitDetailsSuccess = 310,
        [IntValueAttribute(311)]
        AccountLimitDetailsFailed = 311,
        [IntValueAttribute(312)]
        SupervisiorDetailsSuccess = 312,
        [IntValueAttribute(313)]
        SupervisiorDetailsFailed = 313,
        [IntValueAttribute(314)]
        AccountRestrictionInfoSuccess = 314,
        [IntValueAttribute(315)]
        AccountRestrictionInfoFailed = 315,
        [IntValueAttribute(362)]
        AccountOpeningRequestDetailsSuccess = 362,
        [IntValueAttribute(363)]
        AccountOpeningRequestDetailsFailed = 363,
        [IntValueAttribute(715)]
        AccountOpeningEsignSuccess = 715,
        [IntValueAttribute(716)]
        AccountOpeningEsignFailed = 716,
        [IntValueAttribute(617)]
        AccountDetailsSuccess = 617,
        [IntValueAttribute(618)]
        AccountDetailsFail = 618,
        [IntValueAttribute(629)]
        DebitkitDetailsSuccess = 629,
        [IntValueAttribute(630)]
        DebitKitdetailsFailed = 630,
        [IntValueAttribute(633)]
        ServiceRequestCountSuccess = 633,
        [IntValueAttribute(634)]
        ServiceRequestCountFailed = 634,
        [IntValueAttribute(377)]
        LMSAccountBalHoldInfoSuccess = 377,
        [IntValueAttribute(378)]
        LMSAccountBalHoldInfoFailed = 378,
        [IntValueAttribute(316)]
        BeneVerificationSuccess = 316,
        [IntValueAttribute(317)]
        BeneVerificationFailed = 317,
        [IntValueAttribute(318)]
        UserDetailSuccess = 318,
        [IntValueAttribute(319)]
        UserDetailUnSuccess = 319,
        [IntValueAttribute(320)]
        ResetMenuCacheSuccessful = 320,
        [IntValueAttribute(321)]
        ResetMenuCacheFailed = 321,
        [IntValueAttribute(322)]
        ResetProfileSuccessful = 322,
        [IntValueAttribute(323)]
        ResetProfileFailed = 323,
        [IntValueAttribute(324)]
        FavouriteTransactionSuccessful = 324,
        [IntValueAttribute(325)]
        FavouriteTransactionFailed = 325,
        [IntValueAttribute(326)]
        GetAccountStatementSuccessful = 326,
        [IntValueAttribute(327)]
        GetAccountStatementFaliled = 327,
        [IntValueAttribute(328)]
        ManagementHealthAPIsuccessful = 328,
        [IntValueAttribute(329)]
        UpdateKitStatussuccessfull = 329,
        [IntValueAttribute(330)]
        UpdateKitStatusUnsuccessfull = 330,
        [IntValueAttribute(741)]
        WelcomeKITAcknowlegementStatusSuccess = 741,
        [IntValueAttribute(742)]
        WelcomeKITAcknowlegementStatusFailed = 742,
        [IntValueAttribute(821)]
        DMSGetAccountStatusSuccess = 821,
        [IntValueAttribute(822)]
        DMSGetAccountStatusFailed = 822,
        [IntValueAttribute(836)]
        DMSAdharVaultStatusSuccess = 836,
        [IntValueAttribute(837)]
        DMSAdharVaultStatusFailed = 837,
        [IntValueAttribute(842)]
        GetWorkingAddressSuccess = 842,
        [IntValueAttribute(843)]
        GetWorkingAddressFailed = 843,
        [IntValueAttribute(844)]
        GetForm60StatusSuccess = 844,
        [IntValueAttribute(845)]
        GetForm60StatusFailed = 845,
        [IntValueAttribute(846)]
        GetAadhaarLinkStatusSuccess = 846,
        [IntValueAttribute(847)]
        GetAadhaarLinkStatusFailed = 847,
        [IntValueAttribute(870)]
        GetAdharSeedingEnquirySuccess = 870,
        [IntValueAttribute(871)]
        GetAdharSeedingEnquiryFailed = 871,
        [IntValueAttribute(872)]
        GetDMSMobileDedupeSuccess = 872,
        [IntValueAttribute(873)]
        GetDMSMobileDedupeFailed = 873,
        [IntValueAttribute(331)]
        Branchreportsuccess = 331,
        [IntValueAttribute(332)]
        Branchreportfailed = 332,
        [IntValueAttribute(333)]
        Branchchannelreportsuccess = 333,
        [IntValueAttribute(334)]
        Branchchannelreportfailed = 334,
        [IntValueAttribute(335)]
        BranchProductreportsuccess = 335,
        [IntValueAttribute(336)]
        BranchProductreportfailed = 336,
        [IntValueAttribute(337)]
        BranchTranstypereportsuccess = 337,
        [IntValueAttribute(338)]
        BranchTranstypereportfailed = 338,
        [IntValueAttribute(339)]
        Channelreportsuccess = 339,
        [IntValueAttribute(340)]
        Channelreportfailed = 340,
        [IntValueAttribute(341)]
        ChannelProductreportsuccess = 341,
        [IntValueAttribute(342)]
        ChannelProductreportfailed = 342,
        [IntValueAttribute(343)]
        ChannelTranstypereportsuccess = 343,
        [IntValueAttribute(344)]
        ChannelTranstypereportfailed = 344,
        [IntValueAttribute(345)]
        Customerreportsuccess = 345,
        [IntValueAttribute(346)]
        Customerreportfailed = 346,
        [IntValueAttribute(347)]
        Productreportsuccess = 347,
        [IntValueAttribute(348)]
        Productreporfailed = 348,
        [IntValueAttribute(349)]
        Transtypereportsuccess = 349,
        [IntValueAttribute(350)]
        Transtypereportfailed = 350,
        [IntValueAttribute(352)]
        Userreportsuccess = 351,
        [IntValueAttribute(352)]
        Userreportfailed = 352,
        [IntValueAttribute(353)]
        UserProductreportsuccess = 353,
        [IntValueAttribute(354)]
        UserProductreportfailed = 354,
        [IntValueAttribute(355)]
        UserTranstypereportsuccess = 355,
        [IntValueAttribute(356)]
        UserTranstypereportfailed = 356,
        [IntValueAttribute(357)]
        TransListreportsuccess = 357,
        [IntValueAttribute(358)]
        TransListreportfailed = 358,
        [IntValueAttribute(359)]
        Ministatementreportsuccess = 359,
        [IntValueAttribute(360)]
        Ministatementreportfailed = 360,
        [IntValueAttribute(361)]
        UserWiseProductListSuccess = 361,
        [IntValueAttribute(362)]
        UserWiseProductListFailed = 362,
        [IntValueAttribute(363)]
        ServiceRequestStatusSuccess = 363,
        [IntValueAttribute(364)]
        ServiceRequestStatusFailed = 364,
        [IntValueAttribute(365)]
        CashCollectionVerificationSuccessful = 365,
        [IntValueAttribute(366)]
        CashCollectionVerificationFailed = 366,
        [IntValueAttribute(611)]
        CashCollectionTransactionSuccessful = 611,
        [IntValueAttribute(612)]
        CashCollectionTransactionFailed = 612,
        [IntValueAttribute(649)]
        CashCollectionAdhaarValidationSuccessful = 649,
        [IntValueAttribute(650)]
        CashCollectionAdhaarValidationFailed = 650,
        [IntValueAttribute(371)]
        SupervisorUserDetailsSuccess = 371,
        [IntValueAttribute(372)]
        SupervisorUserDetailsFailed = 372,
        [IntValueAttribute(373)]
        LockUserDetailsSuccess = 373,
        [IntValueAttribute(374)]
        LockUserDetailsFailed = 374,
        [IntValueAttribute(375)]
        UnLockUserDetailsSuccess = 375,
        [IntValueAttribute(376)]
        UnLockUserDetailsFailed = 376,
        [IntValueAttribute(377)]
        RemoveAccountRestrictSuccess = 377,
        [IntValueAttribute(378)]
        RemoveAccountRestrictFailed = 378,
        [IntValueAttribute(379)]
        KeyExchangedSuccessful = 379,
        [IntValueAttribute(380)]
        CardTransactionSuccessful = 380,
        [IntValueAttribute(381)]
        BalanceEnquirySuccessful = 381,
        [IntValueAttribute(604)]
        cardtransactionBalanceEnquiryFailed = 604,
        [IntValueAttribute(605)]
        CardTransactioncashwithdrawalFailed = 605,
        [IntValueAttribute(606)]
        KeyExchangedFailed = 606,
        [IntValueAttribute(382)]
        SetCardPinSuccessfull = 382,
        [IntValueAttribute(912)]
        Invaliduserid = 912,
        [IntValueAttribute(913)]
        InvalidTerminal = 913,
        [IntValueAttribute(914)]
        Transactionfailed = 914,
        [IntValueAttribute(403)]
        verifyTPINSuccess = 403,
        [IntValueAttribute(404)]
        verifyTPINFailed = 404,
        [IntValueAttribute(405)]
        GetclosureAmountSuccess = 405,
        [IntValueAttribute(406)]
        GetclosureAmountFailed = 406,
        [IntValueAttribute(700540)]
        EJLogsSuccess = 700540,
        [IntValueAttribute(700541)]
        EJLogsFailure = 700541,

        [IntValueAttribute(747)]
        Croselfaild = 747,
        [IntValueAttribute(748)]
        Croselsucess = 748,
        [IntValueAttribute(700615)]
        AccountRistrictionSuccess = 700615,
        [IntValueAttribute(700616)]
        AccountRistrictionFailed = 700616,
        // Customer Grievance Data Get mesages
        [IntValueAttribute(603)]
        CustomerGrievanceDataGetFailed = 603,
        [IntValueAttribute(602)]
        CustomerGrievanceDataGetSuccessful = 602,
        [IntValueAttribute(635)]
        TrackSuryesSuccess = 635,
        [IntValueAttribute(636)]
        TrackSurveysFailed = 636,
        [IntValueAttribute(637)]
        AccountCheckSuccess = 637,
        [IntValueAttribute(638)]
        AccountCheckFailed = 638,
        [IntValueAttribute(811)]
        DMSChequeIssuanceValidationSuccess = 811,
        [IntValueAttribute(812)]
        DMSChequeIssuanceValidationFailed = 812,
        [IntValueAttribute(813)]
        DMSChequeIssuanceAPISuccess = 813,
        [IntValueAttribute(814)]
        DMSChequeIssuanceAPIFailed = 814,
        [IntValueAttribute(697)]
        DMSKitRequestSuccess = 697,
        [IntValueAttribute(698)]
        DMSKitRequestFailed = 698,
        [IntValueAttribute(647)]
        DMSKitStatusUpdatedSuccess = 647,
        [IntValueAttribute(648)]
        DMSKitStatusUpdatedFailed = 648,
        [IntValueAttribute(701)]
        DMSKitSearchSuccess = 701,
        [IntValueAttribute(702)]
        DMSKitSearchFailed = 702,
        [IntValueAttribute(651)]
        UpdateSISuccess = 651,
        [IntValueAttribute(652)]
        UpdateSIFailed = 652,
        [IntValueAttribute(653)]
        ViewSIListSuccess = 653,
        [IntValueAttribute(654)]
        ViewSIListFailed = 654,
        [IntValueAttribute(655)]
        CreateSIRequestSuccess = 655,
        [IntValueAttribute(656)]
        CreateSIRequestFailed = 656,
        [IntValueAttribute(657)]
        DeleteSISuccess = 657,
        [IntValueAttribute(658)]
        DeleteSIFailed = 658,
        [IntValueAttribute(707)]
        TagDetailsSuccess = 707,
        [IntValueAttribute(708)]
        TagDetailFailed = 708,
        [IntValueAttribute(709)]
        TagDetailsGetSuccess = 709,
        [IntValueAttribute(710)]
        TagDetailsGetFailed = 710,
        [IntValueAttribute(717)]
        IFTFileApprovedSuccess = 717,
        [IntValueAttribute(718)]
        IFTFileApprovedFailed = 718,
        [IntValueAttribute(719)]
        GetFileDetailsSuccess = 719,
        [IntValueAttribute(720)]
        GetFileDetailsFailed = 720,
        [IntValueAttribute(747)]
        GetCheckerDashboardDataSuccess = 747,
        [IntValueAttribute(748)]
        GetCheckerDashboardDataFailed = 748,
        [IntValueAttribute(749)]
        GetApproverDashboardDataSuccess = 749,
        [IntValueAttribute(750)]
        GetApproverDashboardDataFailed = 750,

        //DMT PPI Transaction Messages
        [IntValueAttribute(367)]
        SearchWalkingCustomersSuccess = 367,
        [IntValueAttribute(368)]
        WalkinCustomerLimitSuccess = 368,
        [IntValueAttribute(430)]
        WalkinDMTImpsNeftSuccess = 430,
        [IntValueAttribute(370)]
        SearchWalkingCustomersFailed = 370,
        [IntValueAttribute(371)]
        WalkinCustomerLimitFailed = 371,
        [IntValueAttribute(431)]
        WalkinDMTImpsNeftFailed = 431,

        //Lending Acc
        [IntValueAttribute(434)]
        HHVDownloadSuccess = 434,
        [IntValueAttribute(435)]
        HHVDownloadFailed = 435,
        [IntValueAttribute(436)]
        CGTUploadSuccess = 436,
        [IntValueAttribute(437)]
        CGTUploadFailed = 437,
        [IntValueAttribute(438)]
        RCGTUploadSuccess = 438,
        [IntValueAttribute(439)]
        RCGTUploadFailed = 439,
        [IntValueAttribute(440)]
        SaralHHVUploadSuccess = 440,
        [IntValueAttribute(441)]
        SaralHHVUploadfailed = 441,
        [IntValueAttribute(442)]
        LUCSolarDownloadSuccess = 442,
        [IntValueAttribute(443)]
        LUCSolarDownloadFailed = 443,
        [IntValueAttribute(444)]
        LUCSolarUploadSuccess = 444,
        [IntValueAttribute(445)]
        LUCSolarUploadfailed = 445,
        [IntValueAttribute(446)]
        HolidayDemandDownloadSuccess = 446,
        [IntValueAttribute(447)]
        HolidayDemandDownloadFailed = 447,
        [IntValueAttribute(448)]
        MaturityDemandDownloadSuccess = 448,
        [IntValueAttribute(449)]
        MaturityDemandDownloadFailed = 449,
        [IntValueAttribute(450)]
        RegularDemandDownloadSuccess = 450,
        [IntValueAttribute(451)]
        RegularDemandFailed = 451,
        [IntValueAttribute(452)]
        GroupCenterAttendanceSuccess = 452,
        [IntValueAttribute(453)]
        GroupCenterAttendanceFailed = 453,
        [IntValueAttribute(454)]
        LoanTxnDataSuccess = 454,
        [IntValueAttribute(456)]
        LoanTxnDataFailed = 456,
        [IntValueAttribute(457)]
        GTRDownLoadwebServiceSuccess = 457,
        [IntValueAttribute(458)]
        GTRDownLoadwebServiceFailed = 458,
        [IntValueAttribute(459)]
        RECGTDownloadwebServiceSuccess = 459,
        [IntValueAttribute(460)]
        RECGTDownloadwebServiceFailed = 460,
        [IntValueAttribute(461)]
        HHVDownLoadwebServiceSuccess = 461,
        [IntValueAttribute(462)]
        HHVDownLoadwebServiceFailed = 462,
        [IntValueAttribute(471)]
        GRTUploadDataSuccess = 471,
        [IntValueAttribute(472)]
        GRTUploadDataFailed = 472,
        [IntValueAttribute(473)]
        CreditinquiryServiceSuccess = 473,
        [IntValueAttribute(474)]
        CreditinquiryServiceFailed = 474,
        [IntValueAttribute(475)]
        AdvanceNForeClosureSuccess = 475,
        [IntValueAttribute(476)]
        AdvanceNForeClosureFailed = 476,
        [IntValueAttribute(477)]
        ESBCustomSearchSuccess = 477,
        [IntValueAttribute(478)]
        ESBCustomSearchFailed = 478,
        [IntValueAttribute(479)]
        GetCenterGroupDataSuccess = 479,
        [IntValueAttribute(480)]
        GetCenterGroupDataFailed = 480,
        [IntValueAttribute(481)]
        DisbursementCustomersDataSuccess = 481,
        [IntValueAttribute(482)]
        DisbursementCustomersDataFailed = 482,
        [IntValueAttribute(483)]
        GetEnrollmentDetailSuccess = 483,
        [IntValueAttribute(484)]
        GetEnrollmentDetailFailed = 484,
        [IntValueAttribute(485)]
        PostcustomerDisbursementSuccess = 485,
        [IntValueAttribute(486)]
        PostcustomerDisbursementFailed = 486,
        [IntValueAttribute(487)]
        Esb25LegTransactionRepaySuccess = 487,
        [IntValueAttribute(488)]
        Esb25LegTransactionRepayFailed = 488,
        [IntValueAttribute(489)]
        EsbHOApprovalSuccess = 489,
        [IntValueAttribute(490)]
        EsbHOApprovalFailed = 490,
        [IntValueAttribute(491)]
        EsbProbableCenterDownloadSuccess = 491,
        [IntValueAttribute(492)]
        EsbProbableCenterDownloadFailed = 492,
        [IntValueAttribute(515)]
        EsbAdvanceAndForeClosureSuccess = 515,
        [IntValueAttribute(516)]
        EsbAdvanceAndForeClosureFailed = 516,
        [IntValueAttribute(517)]
        EsbTransactionUpdateHoverSuccess = 517,
        [IntValueAttribute(518)]
        EsbTransactionUpdateHoverFailed = 518,
        [IntValueAttribute(519)]
        EsbTransactionRepaymentHoverSuccess = 519,
        [IntValueAttribute(520)]
        EsbTransactionRepaymentHoverFailed = 520,
        [IntValueAttribute(521)]
        EsbEODCompletionSuccess = 521,
        [IntValueAttribute(522)]
        EsbEODCompletionFailed = 522,
        [IntValueAttribute(509)]
        CardStatusUpdateSuscess = 509,
        [IntValueAttribute(510)]
        CardStatusUpdateFailed = 510,
        [IntValueAttribute(511)]
        CardIssuanceSuccess = 511,
        [IntValueAttribute(512)]
        CardIssuanceFailed = 512,
        [IntValueAttribute(639)]
        JayamMMiniStmtSuccess = 639,
        [IntValueAttribute(640)]
        JayamMiniStmtFailed = 640,
        [IntValueAttribute(645)]
        RivigoDisbursementSuccess = 645,
        [IntValueAttribute(646)]
        RivigoDisbursementFailed = 646,
        [IntValueAttribute(659)]
        UserSurveySuccess = 659,
        [IntValueAttribute(660)]
        UserSurveyFailed = 660,
        [IntValueAttribute(665)]
        JayamEnrollmentAccountOpeningSuccess = 665,
        [IntValueAttribute(666)]
        JayamEnrollmentAccountOpeningFailed = 666,

        #region Fast Tag
        [IntValueAttribute(669)]
        FasttagVehicleregSucessful = 669,
        [IntValueAttribute(670)]
        FasttagVehicleregFailed = 670,
        [IntValueAttribute(671)]
        FasttagregistrationdetailsFound = 671,
        [IntValueAttribute(673)]
        FasttagregistrationdetailsnotFound = 673,

        [IntValueAttribute(8012)]
        FastagBarcodeMappingSuccessful = 8012,
        [IntValueAttribute(8013)]
        FastagBarcodeMappingFailed = 8013,
        [IntValueAttribute(8014)]
        registeredVehicleStatusSuccessful = 8014,
        [IntValueAttribute(8015)]
        registeredVehicleStatusFailed = 8015,
        [IntValueAttribute(8016)]
        BpayPrefilledVehicleDetailssuccess = 8016,
        [IntValueAttribute(8017)]
        BpayPrefilledVehicleDetailsFailed = 8017,
        [IntValueAttribute(8018)]
        BpayRegistrationDeletionSucessful = 8018,
        [IntValueAttribute(8019)]
        BpayRegistrationDeletionfailed = 8019,



        [IntValueAttribute(675)]
        VehicleTagIssuranceSuccessful = 675,
        [IntValueAttribute(676)]
        VehicleTagIssuranceFailed = 676,
        [IntValueAttribute(674)]
        VehiclePostTransactionSuccessful = 674,
        [IntValueAttribute(672)]
        VehiclePostTransactionFailed = 672,
        [IntValueAttribute(679)]
        VehicleVerificationCodeSuccessful = 679,
        [IntValueAttribute(680)]
        VehicleVarificationCodeFailed = 680,
        [IntValueAttribute(681)]
        VerificationCodeSendSucessfully = 681,
        [IntValueAttribute(682)]
        VerificationCodeSendFailed = 682,
        [IntValueAttribute(685)]
        TagblockSucessfully = 685,
        [IntValueAttribute(686)]
        TagblockFailed = 686,
        [IntValueAttribute(687)]
        TagUnblockSucessfully = 687,
        [IntValueAttribute(688)]
        TagUnblockFailed = 688,
        [IntValueAttribute(689)]
        DMSTagVerificationSuccessful = 689,
        [IntValueAttribute(690)]
        DMSTagVerificationFailed = 690,
        [IntValueAttribute(691)]
        ExceptionAmountSuccessful = 691,
        [IntValueAttribute(692)]
        ExceptionAmountFailed = 692,
        [IntValueAttribute(693)]
        TagCloseSucessful = 693,
        [IntValueAttribute(694)]
        TagCloseFailed = 694,
        [IntValueAttribute(699)]
        TagReissuanceSucessful = 699,
        [IntValueAttribute(700)]
        TagReissuanceFailed = 700,
        [IntValueAttribute(711)]
        GetTransactionDetailsSuccessful = 711,
        [IntValueAttribute(712)]
        GetTransactionDetailsFailed = 712,
        [IntValueAttribute(713)]
        UpdateCBSStatusSuccess = 713,
        [IntValueAttribute(714)]
        UpdateCBSStatusFailed = 714,
        [IntValueAttribute(1371)]
        FasttaInvalidRequest = 1371,
        [IntValueAttribute(1372)]
        FasttaInvalidVehicleDetails = 1372,
        [IntValueAttribute(1373)]
        FasttagWalletisalreadyOpen = 1373,
        [IntValueAttribute(1374)]
        Fasttagcustcustomeraccountdetailfailed = 1374,
        [IntValueAttribute(1375)]
        Fasttagvehiclisblacklist = 1375,
        [IntValueAttribute(1376)]
        FasttagUnabletoconnectremotserver = 1376,
        [IntValueAttribute(1377)]
        FasttagMinistatment = 1377,
        [IntValueAttribute(1378)]
        FasttagVehiclealredyregister = 1378,
        [IntValueAttribute(1379)]
        FasttagVehiclealnotregister = 1379,
        [IntValueAttribute(1380)]
        FasttagUPADetailFound = 1380,
        [IntValueAttribute(1381)]
        FasttagUPADetailnotFound = 1381,
        [IntValueAttribute(1382)]
        FasttagDetailnotFound = 1382,
        [IntValueAttribute(1383)]
        FasttagServernotresponding = 1383,
        [IntValueAttribute(1384)]
        Fasttagupaaccnoupdatesuccess = 1384,
        [IntValueAttribute(1385)]
        Fasttagupaaccnoupdatefailed = 1385,
        [IntValueAttribute(1386)]
        Fasttagvirtualaddnotfound = 1386,
        [IntValueAttribute(1387)]
        FasttagSuccess = 1387,
        [IntValueAttribute(1388)]
        FasttagFailed = 1388,
        [IntValueAttribute(1389)]
        FasttagRecordnotfound = 1389,
        [IntValueAttribute(1390)]
        FasttagVehicletypeupdatesucessfully = 1390,
        [IntValueAttribute(1391)]
        FasttagVehicletypeupdatefailed = 1391,
        [IntValueAttribute(1393)]
        FasttagOTPverifyfailed = 1393,
        [IntValueAttribute(1393)]
        FasttagFPverifyfailed = 1394,
        [IntValueAttribute(1395)]
        Fasttagotpexpired = 1395,
        [IntValueAttribute(1396)]
        Fasttagverifycodesucess = 1396,
        [IntValueAttribute(1397)]
        Fasttagverifycodefailed = 1397,
        [IntValueAttribute(1398)]
        Fasttaginternalservererror = 1398,
        [IntValueAttribute(1399)]
        Fasttagverifycodesucessti = 1399,
        [IntValueAttribute(1400)]
        Fasttagverifycodefailedti = 1400,


        #endregion

        [IntValueAttribute(735)]
        GetIINMasterDataSuccess = 735,
        [IntValueAttribute(736)]
        GetIINMasterDataFailed = 736,
        [IntValueAttribute(737)]
        ResetIINMasterDataSuccess = 737,
        [IntValueAttribute(738)]
        ResetIINMasterDataFailed = 738,

        #region CashProcess message
        [IntValueAttribute(407)]
        CashProcessUserDetailsSuccess = 407,
        [IntValueAttribute(408)]
        CashProcessUserDetailsFailed = 408,
        [IntValueAttribute(409)]
        CashProcessVaultDetailsSuccess = 409,
        [IntValueAttribute(410)]
        CashProcessVaultDetailsFailed = 410,
        [IntValueAttribute(413)]
        CashProcessVaultBalanceSuccess = 413,
        [IntValueAttribute(414)]
        CashProcessVaultBalanceFailed = 414,
        [IntValueAttribute(625)]
        EodProcessUserdetailsSuccess = 625,
        [IntValueAttribute(626)]
        EodUserDetailsFailed = 626,
        [IntValueAttribute(627)]
        EodProcessTransactionSuccess = 627,
        [IntValueAttribute(628)]
        EodProcessTransactionFailed = 628,
        [IntValueAttribute(631)]
        EodBranchcloseProcessSuccess = 631,
        [IntValueAttribute(632)]
        EodBranchcloseProcessFailed = 632,
        [IntValueAttribute(918)]
        EodUserDetailsfailed = 918,
        [IntValueAttribute(725)]
        CBSPostingGetUserDtailsSuccess = 725,
        [IntValueAttribute(726)]
        CBSPostingGetUserDtailsFailed = 726,
        [IntValueAttribute(727)]
        CBSPostTransactionSuccess = 727,
        [IntValueAttribute(728)]
        CBSPostTransactionFailed = 728,
        [IntValueAttribute(729)]
        DMSTrackRevisionSuccess = 729,
        [IntValueAttribute(730)]
        DMSTrackRevisionFailed = 730,

        #endregion

        #region Reversal Transaction
        [IntValueAttribute(411)]
        ReversalTransactionSuccess = 411,
        [IntValueAttribute(412)]
        ReversalTransactionFailed = 412,
        #endregion

        #region Bucket
        [IntValueAttribute(415)]
        UpdateBucketBalanceSuccess = 415,
        [IntValueAttribute(416)]
        UpdateBucketBalanceFailed = 416,
        #endregion

        #region AEPS transaction
        [IntValueAttribute(417)]
        AEPStransactionSuccess = 417,
        [IntValueAttribute(418)]
        AEPSTransactionFailed = 418,
        [IntValueAttribute(424)]
        AEPSBalanceEnquirySuccess = 424,
        [IntValueAttribute(427)]
        AEPSBalanceEnquiryFailed = 427,

        #endregion

        #region Petty Transaction
        [IntValueAttribute(419)]
        PettyCashDepositSuccess = 419,
        [IntValueAttribute(420)]
        PettyCashDepositFailed = 420,
        [IntValueAttribute(421)]
        PettyCashWithdrawSuccess = 421,
        [IntValueAttribute(422)]
        PettyCashWithdrawFailed = 422,
        [IntValueAttribute(423)]
        PettyGlBalanceSuccess = 423,
        [IntValueAttribute(426)]
        PettyGlBalanceFailed = 426,
        [IntValueAttribute(917)]
        PettyLimitexpense = 917,
        #endregion

        #region Reversal Transaction
        [IntValueAttribute(428)]
        CashOutTransactionSuccess = 428,
        [IntValueAttribute(429)]
        CashOutTransactionFailed = 429,
        #endregion

        #region Maker Checker Message
        [IntValueAttribute(493)]
        GetMakerSuccess = 493,
        [IntValueAttribute(494)]
        GetMakerFailed = 494,
        [IntValueAttribute(495)]
        GetCheckerSuccess = 495,
        [IntValueAttribute(496)]
        GetCheckerFailed = 496,
        [IntValueAttribute(497)]
        MakerPostSuccess = 497,
        [IntValueAttribute(498)]
        MakerPostFailed = 498,
        [IntValueAttribute(499)]
        MakerCancelSuccess = 499,
        [IntValueAttribute(500)]
        MakerCancelFailed = 500,
        [IntValueAttribute(501)]
        CheckerApprovedSuccess = 501,
        [IntValueAttribute(502)]
        CheckerApprovedFailed = 502,
        [IntValueAttribute(503)]
        CheckerRejectSuccess = 503,
        [IntValueAttribute(504)]
        CheckerRejectFailed = 504,
        #endregion

        #region IMPS/NEFT
        [IntValueAttribute(607)]
        IMPSTransactionSuccess = 607,
        [IntValueAttribute(608)]
        IMPSTransactionFailed = 608,
        [IntValueAttribute(609)]
        NEFTTransactionSuccess = 609,
        [IntValueAttribute(610)]
        NEFTTranscationFailed = 610,
        #endregion

        #region RTGS
        [IntValueAttribute(505)]
        RTGSChargesSuccess = 505,
        [IntValueAttribute(506)]
        RTGSChargesFailed = 506,
        [IntValueAttribute(507)]
        RTGSTransactionSuccess = 507,
        [IntValueAttribute(508)]
        RTGSTransactionFailed = 508,
        #endregion RTGS

        #region CDM
        [IntValueAttribute(622)]
        CDMVerificationFailed = 622,
        [IntValueAttribute(620)]
        CDMTransactionFailed = 620,

        #endregion

        #region Shopkeeper Policy Insurance
        [IntValueAttribute(739)]
        IPRUShubrakshaFetchDetailsFailed = 739,
        [IntValueAttribute(740)]
        IPRUShubrakshaFetchDetailsSuccessfully = 740,
        #endregion

        #region Shopkeeper Policy Insurance
        [IntValueAttribute(661)]
        ShopkeeperPolicyFetchDetailsSuccessfully = 661,
        [IntValueAttribute(662)]
        ShopkeeperPolicyFetchDetailsFailed = 662,
        [IntValueAttribute(663)]
        ShopkeeperPolicyUpdateDetailsSuccessfully = 663,
        [IntValueAttribute(664)]
        ShopkeeperPolicyUpdateDetailsFailed = 664,

        #endregion

        #region Hospicash Policy Insurance
        [IntValueAttribute(667)]
        HospicashPolicyFetchDetailsSuccessfully = 667,
        [IntValueAttribute(668)]
        HospicashPolicyFetchDetailsFailed = 668,
        [IntValueAttribute(677)]
        HospicashPolicyFetchUHIDStatusDetailsSuccessfully = 677,
        [IntValueAttribute(678)]
        HospicashPolicyFetchUHIDStatusDetailsFailed = 678,

        #endregion

        #region Lombard Two Wheeler
        [IntValueAttribute(721)]
        TWMasterDetailsFetchSuccessfully = 721,
        [IntValueAttribute(722)]
        TWMasterDetailsFetchFailed = 722,
        [IntValueAttribute(723)]
        TWQuoteGenerationSuccessfully = 723,
        [IntValueAttribute(724)]
        TWQuoteGenerationFailed = 724,

        #endregion

        #region Last Action Lead Form
        [IntValueAttribute(683)]
        LastActionLeadFormSuccess = 683,
        [IntValueAttribute(684)]
        LastActionLeadFormFailed = 684,

        #endregion

        [IntValueAttribute(685)]
        CIFKYCDetailsSuccess = 695,
        [IntValueAttribute(696)]
        CIFKYCDetailsFailed = 696,
        [IntValueAttribute(703)]
        SearchAgentSuccess = 703,
        [IntValueAttribute(704)]
        SearchAgentFailed = 704,
        [IntValueAttribute(705)]
        UpdateAgentSuccess = 705,
        [IntValueAttribute(706)]
        UpdateAgentFailed = 706,
        //Max Id (706)
        #region RMF
        [IntValueAttribute(700532)]
        RMFFolioFailed = 700532,
        [IntValueAttribute(700533)]
        RMFFolioSuccess = 700533,
        [IntValueAttribute(700534)]
        RMFTxnSuccess = 700534,
        [IntValueAttribute(700535)]
        RMFTxnFailed = 700535,
        [IntValueAttribute(700536)]
        RMFSchemeDetailsSuccess = 700536,
        [IntValueAttribute(700537)]
        RMFSchemeDetailsFailed = 700537,
        [IntValueAttribute(700538)]
        RMFRedemptionSuccess = 700538,
        [IntValueAttribute(700539)]
        RMFRedemptionFailed = 700539,
        #endregion RMF

        [IntValueAttribute(816)]
        GLZeroizationSuccess = 816,
        [IntValueAttribute(817)]
        GLZeroizationFailed = 817,
        [IntValueAttribute(826)]
        TransactionReporst_StatementSRTaken = 826,
        [IntValueAttribute(827)]
        TransactionReporst_StatementSRUnabletoProcess = 827,
        [IntValueAttribute(828)]
        TransactionReporst_StatementSREmailVerifyLinkSent = 828,
        [IntValueAttribute(829)]
        TransactionReporst_StatementSREmailVerifyLinkSentFailed = 829,
        [IntValueAttribute(830)]
        TransactionReporst_StatementSREmailUpdationFailed = 830,
        [IntValueAttribute(831)]
        TransactionReporst_StatementSREmailNotUpdated = 831,
        [IntValueAttribute(832)]
        TransactionReporst_StatementSREmailVerified = 832,
        [IntValueAttribute(833)]
        TransactionReporst_StatementSREmailVPending = 833,
        [IntValueAttribute(834)]
        TransactionReporst_StatementSREmailUpdatedSuccess = 834,
        [IntValueAttribute(835)]
        TransactionReporst_StatementSREmailVerifyLinkExpired = 835,
        [IntValueAttribute(838)]
        TransactionReporst_StatementSREmailAlredyVerified = 838,
        [IntValueAttribute(839)]
        TransactionReporst_StatementSRInvalid = 839,


        #region "Cashin bank"
        [IntValueAttribute(8007)]
        Cashinbanklocationfound = 8007,
        [IntValueAttribute(8008)]
        Cashinbanklocationnotfound = 8008,
        [IntValueAttribute(8009)]
        CashinbankImagefound = 8009,
        [IntValueAttribute(8010)]
        CashinbankImagenotfound = 8010,
        [IntValueAttribute(8011)]
        CashinbankInvalidRequest = 8011,

        #endregion

        #region "Digital Passbook"
        [IntValueAttribute(700542)]
        DigitalPassbookSuccess = 700542,
        [IntValueAttribute(700543)]
        DigitalPassbookFailed = 700543,
        [IntValueAttribute(700544)]
        DigitalPassbookPDFFailed = 700544,
        #endregion

        #region "Sms Details"
        [IntValueAttribute(800702)]
        SmsDetailskSuccess = 800702,
        [IntValueAttribute(800703)]
        SmsDetailsFailed = 800703,
        #endregion

        #region "Suryoday Account Close"
        [IntValueAttribute(840)]
        SuryodayAcnCloseSuccess = 840,
        [IntValueAttribute(841)]
        SuryodayAcnCloseFail = 841,
        #endregion

        #region "Cash in Match data"
        [IntValueAttribute(848)]
        CashInInsertBankStnmtSuccess = 848,
        [IntValueAttribute(849)]
        CashInInsertBankStnmtFailuer = 849,
        [IntValueAttribute(850)]
        CashInMatchBankStnmtSuccess = 850,
        [IntValueAttribute(851)]
        CashInMatchBankStnmtFailuer = 851,
        [IntValueAttribute(852)]
        CashInUpdateBankStnmtSuccess = 852,
        [IntValueAttribute(853)]
        CashInUpdateBankStnmtFailuer = 853,
        [IntValueAttribute(854)]
        CashInViewBankStnmtSuccess = 854,
        [IntValueAttribute(855)]
        CashInBankStnmtFileFailuer = 855,
        [IntValueAttribute(856)]
        CashInBankStnmtMatchBalanceFailuer = 856,

        #endregion

        #region ReferalLoan
        [IntValueAttribute(857)]
        ReferalLoanVerificationSuccess = 857,
        [IntValueAttribute(858)]
        ReferalLoanVerificationFailed = 858,

        #endregion

        #region merchant payouts
        [IntValueAttribute(857)]
        GetPayoutdata = 857,
        [IntValueAttribute(858)]
        GetPayoutdataFailure = 858,
        #endregion

        #region self declared kits
        [IntValueAttribute(859)]
        GetSelfdeclaredkitdata = 859,
        [IntValueAttribute(860)]
        GetSelfdeclaredkitdataFailure = 860,
        [IntValueAttribute(861)]
        Selfdeclaredkitsave = 861,
        [IntValueAttribute(862)]
        SelfdeclaredkitsaveFailure = 862,
        [IntValueAttribute(863)]
        GetKitdataapproval = 863,
        [IntValueAttribute(864)]
        GetKitdataapprovalFailure = 864,
        [IntValueAttribute(865)]
        Approvekitdata = 865,
        [IntValueAttribute(866)]
        ApprovekitdataFailure = 866,

        #endregion

        [IntValueAttribute(867)]
        PincodeValidateSuccess = 867,
        [IntValueAttribute(868)]
        PincodeValidateFailedWithRestriction = 868,
        [IntValueAttribute(869)]
        PincodeValidateFailed = 869,

        #region bbps cust comp 1846
        [IntValueAttribute(876)]
        checkbbpscomplaintstatusSuccess = 876,
        [IntValueAttribute(877)]
        checkbbpscomplaintstatusFailed = 877,
        [IntValueAttribute(878)]
        checkbbpscomplaintdataSuccess = 878,
        [IntValueAttribute(879)]
        checkbbpscomplaintdataFailed = 879,
        [IntValueAttribute(874)]
        SubmitbbpscomplaintdataSuccess = 874,
        [IntValueAttribute(875)]
        SubmitbbpscomplaintdataFailed = 875,
        #endregion

        #region Foreign Remittance
        [IntValueAttribute(1600)]
        AgentCreationSuccess = 1600,
        [IntValueAttribute(1601)]
        AgentCreationFailed = 1601,
        [IntValueAttribute(1602)]
        FRTransactionSuccess = 1602,
        [IntValueAttribute(1603)]
        FRTransactionFailed = 1603,
        [IntValueAttribute(1604)]
        FRGetTransactionSuccess = 1604,
        [IntValueAttribute(1605)]
        FRGetTransactionFailed = 1605,
        [IntValueAttribute(1606)]
        FRJVVerificationSuccess = 1606,
        [IntValueAttribute(1607)]
        FRJVVerificationFailed = 1607,
        [IntValueAttribute(1608)]
        FRMasterdataSuccess = 1608,
        [IntValueAttribute(1609)]
        FRMasterdataFailed = 1609,
        [IntValueAttribute(1610)]
        FRAgentSuccess = 1610,
        [IntValueAttribute(1611)]
        FRAgentFailed = 1611,
        [IntValueAttribute(1612)]
        FRUpdateagentSuccess = 1612,
        [IntValueAttribute(1613)]
        FRUpdateagentFailed = 1613,
        [IntValueAttribute(1614)]
        FRRevisiondataSuccess = 1614,
        [IntValueAttribute(1615)]
        FRRevisiondataFailed = 1615,
        [IntValueAttribute(1616)]
        FRRevisionSuccess = 1616,
        [IntValueAttribute(1617)]
        FRRevisionFailed = 1617,
        [IntValueAttribute(1618)]
        FRDocDmsSuccess = 1618,
        [IntValueAttribute(1619)]
        FRDocDmsFailed = 1619,
        [IntValueAttribute(1620)]
        FRAckPdfSuccess = 1620,
        [IntValueAttribute(1621)]
        FRAckPdfFailed = 1621,
        [IntValueAttribute(1622)]
        FRCAReportPdfSuccess = 1622,
        [IntValueAttribute(1623)]
        FRCAReportPdfFailed = 1623,
        [IntValueAttribute(1624)]
        FRMerAgreementSuccess = 1624,
        [IntValueAttribute(1625)]
        FRMerAgreementFailed = 1625,
        #endregion

        [IntValueAttribute(2001)]
        PanUpdateInCBsSuccess = 2001,
        [IntValueAttribute(2002)]
        PanUpdateInCBSFailed = 2002,
        [IntValueAttribute(904)]
        AccountClosureChargesSuccess = 904,
        [IntValueAttribute(905)]
        AccountClosureChargesFailed = 905,
        [IntValueAttribute(1001)]
        DMSGuardianNumberFound = 1001,
        [IntValueAttribute(1002)]
        DMSGuardianNumberNotFound = 1002,
        [IntValueAttribute(1003)]
        LatLongUpdateSuccessfully = 1003,
        [IntValueAttribute(1004)]
        LatLongUpdateFailed = 1004,
        [IntValueAttribute(1005)]
        DMSSRCounterSuccess = 1005,
        [IntValueAttribute(1006)]
        DMSSRCounterFailed = 1006,
        [IntValueAttribute(906)]
        ITRStatusSuccess = 906,
        [IntValueAttribute(907)]
        ITRStatusFailed = 907,

        #region CustomerSupport
        [IntValueAttribute(908)]
        custSupportSuccess = 908,
        [IntValueAttribute(909)]
        custSupportFailed = 909,
        #endregion

        #region ForBillPayService
        [IntValueAttribute(910)]
        FingerPrintAuthenFailed = 910,
        [IntValueAttribute(911)]
        AadharAuthenFailed = 911,
        [IntValueAttribute(915)]
        operationtimeOutMiniStatement = 915,
        [IntValueAttribute(916)]
        operationtimeOut = 916,
        #endregion

        #region Insurance
        [IntValueAttribute(1111)]
        InsurancePremiumMismatch = 1111,
        [IntValueAttribute(1112)]
        InsuranceInvalidBadRequest = 1112,
        [IntValueAttribute(1113)]
        InsuranceBuildLatestVr = 1113,
        [IntValueAttribute(1114)]
        InsuranceOVDDetails = 1114,
        [IntValueAttribute(1115)]
        InsuranceCloseExternalAccFalied = 1115,
        [IntValueAttribute(1116)]
        InsuranceOtpAuthFailed = 1116,
        [IntValueAttribute(1117)]
        InsuranceFPverificationFalied = 1117,
        [IntValueAttribute(1118)]
        InsuranceTranTypeMismatch = 1118,

        #endregion

        #region FPBFinancial RestService
        [IntValueAttribute(1111)]
        AccountOverrideChargesSuccess = 1111,
        [IntValueAttribute(1112)]
        AccountOverrideChargesFailed = 1112,
        [IntValueAttribute(1113)]
        AnalysisFlagIs1 = 1113,
        [IntValueAttribute(1114)]
        InvalidErrorTxnLimitService = 1114,
        [IntValueAttribute(1115)]
        TxnLimitDetailsNotAvailable = 1115,
        [IntValueAttribute(1116)]
        UnableToParseTxnLimitRequest = 1116,
        [IntValueAttribute(1117)]
        InvalidErrorInGetAccountOverrideChargesAPI = 1117,
        [IntValueAttribute(1118)]
        ChargeOverrideDetailsNotAvailable = 1118,
        [IntValueAttribute(1119)]
        UnableToParseChargeOverrideRequest = 1119,
        [IntValueAttribute(1120)]
        TxnNotAllowedForSelectedProduct = 1120,
        [IntValueAttribute(1121)]
        TransactionAllowed = 1121,
        [IntValueAttribute(1122)]
        InvalidErrorInRestrictTxnByProductService = 1122,
        [IntValueAttribute(1123)]
        UnableToParseRequestData = 1123,
        #endregion

        #region BusinessLogic TransactionLimit Contract
        [IntValueAttribute(1124)]
        TxnLimitExceededTransactionFailed = 1124,
        [IntValueAttribute(1125)]
        Success = 1125,
        [IntValueAttribute(1126)]
        TxnLimitsDetailsNotFound = 1126,
        [IntValueAttribute(1127)]
        RecordNotFound = 1127,
        [IntValueAttribute(1128)]
        UnableToPerformTxnnCustomerNotExists = 1128,
        [IntValueAttribute(1129)]
        OverrideChargesCalculationFailed = 1129,
        [IntValueAttribute(1130)]
        OverrideConditionNotMatchedFetchChargesFromFIS = 1130,
        [IntValueAttribute(1131)]
        OverrideChargesNotConfigured = 1131,
        [IntValueAttribute(1132)]
        AccountChargesOverrideDetailsNotFound = 1132,
        [IntValueAttribute(1133)]
        TxnNotAllowedForWallet = 1133,
        #endregion

        #region FPBNonFinancial RestService
        [IntValueAttribute(1134)]
        UserNotAuthorizedToProceedTransaction = 1134,
        [IntValueAttribute(1135)]
        NEFTTransactionNotAllowed = 1135,
        [IntValueAttribute(1136)]
        BeneIFSCOrAccNumberCannotBeNullorEmpty = 1136,
        [IntValueAttribute(1137)]
        Mobilenumbershouldnotbenullorempty = 1137,
        [IntValueAttribute(1138)]
        TxnDetailsNotAvailableRequestData = 1138,
        [IntValueAttribute(1139)]
        WalkinTransaction = 1139,
        [IntValueAttribute(1140)]
        TxnTypeNotConfiguredForRestrictionProductCode = 1140,
        [IntValueAttribute(1370)]
        ProductCodeNotConfigured = 1370,
        #endregion

        #region BusinessLogic NonFinancial Contract
        [IntValueAttribute(1141)]
        NotalwdprfrmCshnaprvl = 1141,
        [IntValueAttribute(1142)]
        trnsctnbtwnctoftime = 1142,
        [IntValueAttribute(1143)]
        DearCstmrAplgsincnvnceplstrysvcaftr = 1143,
        [IntValueAttribute(1144)]
        Rcrdnotfndfr = 1144,
        [IntValueAttribute(1145)]
        Unbletofndcutoftime = 1145,
        [IntValueAttribute(1146)]
        PostTrnsctnnotfound = 1146,
        #endregion

        [IntValueAttribute(1147)]
        TxnUnderProccessCheckMiniStatment = 1147,
        [IntValueAttribute(1148)]
        AccountClosureFnctnltyNotApplicableWlts = 1148,
        [IntValueAttribute(1149)]
        ChannelIDNotFound = 1149,
        [IntValueAttribute(1150)]
        UserClassNotFound = 1150,
        [IntValueAttribute(1151)]
        ProductTypeNotFound = 1151,
        [IntValueAttribute(1152)]
        DearCustomerFunctionalityInoperativeBtwnCutOffTime = 1152,
        [IntValueAttribute(1153)]
        TxnDeclinedDueCreditRestrictionAccount = 1153,
        [IntValueAttribute(1154)]
        CASAPLUSViewBlnceFailed = 1154,
        [IntValueAttribute(1155)]
        TxnAmountMustLessMerchantLimit = 1155,
        [IntValueAttribute(1156)]
        InvalidAccountNumber = 1156,
        [IntValueAttribute(1157)]
        TxnNotAllowed = 1157,
        [IntValueAttribute(1158)]
        CustomerConsumeLimitFound = 1158,
        [IntValueAttribute(1159)]
        CustomerConsumeLimitNotFound = 1159,
        [IntValueAttribute(1160)]
        CashWithdrawlTxnLimitDtlsNotFoundUser = 1160,
        [IntValueAttribute(1161)]
        ServiceNotRespondingException = 1161,
        [IntValueAttribute(1162)]
        InvalidMerchantDetails = 1162,
        [IntValueAttribute(1163)]
        DearMerchantContactBranchOrSalesOfficerForSupport = 1163,
        [IntValueAttribute(1164)]
        RequestDataNotFound = 1164,
        [IntValueAttribute(1165)]
        MerchentLimitSuccess = 1165,
        [IntValueAttribute(1166)]
        MerchentLimitFail = 1166,
        [IntValueAttribute(1167)]
        GetMerchantLimitFailed = 1167,
        [IntValueAttribute(1168)]
        MerchantNotAsCustomer = 1168,
        [IntValueAttribute(1169)]
        AccountDetailsNotFound = 1169,
        [IntValueAttribute(1170)]
        NotalwdtoprfrmCshnaprvl = 1170,
        [IntValueAttribute(1171)]
        CutOffTimeFndCstmrSuccess = 1171,
        [IntValueAttribute(1172)]
        Acntnbrprdctcdnomtchdinfndcstmr = 1172,
        [IntValueAttribute(1173)]
        Cstmracntisinvld = 1173,
        //InvalidRequest = 1174,
        [IntValueAttribute(1175)]
        UnableProcceedTxnPleaseTryAagain = 1175,
        [IntValueAttribute(1176)]
        SuccessfullyInserted = 1176,
        [IntValueAttribute(1177)]
        YourRequestHasSubmittedSuccessfully = 1177,
        [IntValueAttribute(1178)]
        FailedToInsert = 1178,
        [IntValueAttribute(1179)]
        AlertNameAlreadyPresent = 1179,
        [IntValueAttribute(1180)]
        MerchantNotifictionDetailsSuccess = 1180,
        [IntValueAttribute(1181)]
        NoNewMessage = 1181,
        [IntValueAttribute(1182)]
        ServerNotRespondingPleaseTryAgainLater = 1182,
        [IntValueAttribute(1183)]
        RemoteServerReturnedError = 1183,
        [IntValueAttribute(1184)]
        AutoTxnChargesRequest = 1184,
        [IntValueAttribute(1185)]
        Banknameshuldnotbeempty = 1185,
        [IntValueAttribute(1186)]
        UnablePerformTxnDueIMPSNotAllowedSelectedBank = 1186,
        [IntValueAttribute(1187)]
        ForslctdbankIMPSNEFTtrnsctnnotallowed = 1187,
        [IntValueAttribute(1188)]
        UnblprfrmtrnsctndueTrnsctntypeshuldnotnley = 1188,
        [IntValueAttribute(1189)]
        AutoTxnSuccess = 1189,
        [IntValueAttribute(1190)]
        AutoTxnFailed = 1190,
        [IntValueAttribute(1191)]
        ErrorInSystemWhileApproving = 1191,
        [IntValueAttribute(1192)]
        GLAccountNumberNotFound = 1192,
        [IntValueAttribute(1193)]
        LimitApprovedSuccessfully = 1193,
        [IntValueAttribute(1194)]
        RequestedLimitCancelled = 1194,
        [IntValueAttribute(1195)]
        RecordExistsInCBS = 1195,
        [IntValueAttribute(1196)]
        RecordNotExistsInCBS = 1196,
        [IntValueAttribute(1197)]
        ApproveStatusUpdated = 1197,
        [IntValueAttribute(1198)]
        ErrorUpdatingApproved = 1198,
        [IntValueAttribute(1199)]
        MerchantNameNotFound = 1199,
        [IntValueAttribute(1200)]
        NoRecordFound = 1200,
        [IntValueAttribute(1201)]
        DuplicateRqustNumber = 1201,
        [IntValueAttribute(1202)]
        ModeOfTxnDataFound = 1202,
        [IntValueAttribute(1203)]
        BankDataFound = 1203,
        [IntValueAttribute(1204)]
        BankDataNotFound = 1204,
        [IntValueAttribute(1205)]
        DataFound = 1205,
        [IntValueAttribute(1206)]
        CashInIntntCountFound = 1206,
        [IntValueAttribute(1207)]
        CashInIntntCountNotFound = 1207,
        [IntValueAttribute(1208)]
        DplcteRqustNmbr = 1208,
        [IntValueAttribute(1209)]
        CustomerNumberShouldNotNull = 1209,
        [IntValueAttribute(1210)]
        FngrPrintnotactvtd = 1210,
        [IntValueAttribute(1211)]
        CustomerFPDataAvailable = 1211,
        [IntValueAttribute(1212)]
        CustomerFPDataNotExist = 1212,
        [IntValueAttribute(1213)]
        FngrPrintnotmatched = 1213,
        [IntValueAttribute(1214)]
        CustomerSupportDetailsuccess = 1214,
        [IntValueAttribute(1215)]
        CustomerSupportDtlsDataSelectionFailed = 1215,
        [IntValueAttribute(1216)]
        RequstError = 1216,
        [IntValueAttribute(1217)]
        Merchantrtinginformation = 1217,
        [IntValueAttribute(1218)]
        Merchantrtinginformationnotavailable = 1218,
        [IntValueAttribute(1219)]
        ServiceisRestricted = 1219,
        [IntValueAttribute(1220)]
        DataNotFound = 1220,
        [IntValueAttribute(1221)]
        NoDetailsFound = 1221,
        [IntValueAttribute(1222)]
        RecordNotFoundBLLDB = 1222,
        [IntValueAttribute(1223)]
        RequestNotContainXCorelationID = 1223,
        [IntValueAttribute(1224)]
        RequestDataEmpty = 1224,
        [IntValueAttribute(1225)]
        InvalidJSONTxnResponse = 1225,
        [IntValueAttribute(1226)]
        TxnResponseNotFound = 1226,
        [IntValueAttribute(1227)]
        UnableParseResponse = 1227,
        [IntValueAttribute(1229)]
        TxnDetailsNotFoundThisTxnType = 1229,
        [IntValueAttribute(1230)]
        AEPSTxnLimitDetailsNotFoundThisUser = 1230,
        [IntValueAttribute(1231)]
        InvalidUserId = 1231,
        [IntValueAttribute(1232)]
        InvalidTerminalId = 1232,
        [IntValueAttribute(1233)]
        BAVVerifiedSuccess = 1233,
        [IntValueAttribute(1234)]
        AEPSCashDepositTxnFailed = 1234,
        [IntValueAttribute(1235)]
        AEPSCashDepositSuccess = 1235,
        [IntValueAttribute(1236)]
        AEPSCashDepositFailed = 1236,
        [IntValueAttribute(1237)]
        AepsTwoFactorAuthDataInsertSuccess = 1237,
        [IntValueAttribute(1238)]
        AepsTwoFactorAuthDataInsertFailed = 1238,
        [IntValueAttribute(1239)]
        ESBServerUnavailable = 1239,
        [IntValueAttribute(1240)]
        InvalidBadRequestf = 1240,
        [IntValueAttribute(1241)]
        AEPSMiniStatementFailed = 1241,

        #region Rewards
        [IntValueAttribute(1300)]
        ServerNotRes = 1300,
        [IntValueAttribute(1301)]
        RewardDataFound = 1301,
        [IntValueAttribute(1302)]
        RewardDataNotFound = 1302,
        [IntValueAttribute(1305)]
        ClavaxDataFound = 1305,
        [IntValueAttribute(1306)]
        ClavaxDataNotFound = 1306,
        [IntValueAttribute(1307)]
        RewardStmtFound = 1307,
        [IntValueAttribute(1308)]
        RewardStmtNotFound = 1308,
        #endregion

        #region Registration
        [IntValueAttribute(1320)]
        StrCifID = 1320,
        [IntValueAttribute(1321)]
        StrCifIDNotAvailable = 1321,
        [IntValueAttribute(1322)]
        SuccessFlag = 1322,
        [IntValueAttribute(1323)]
        FailedFlag = 1323,
        [IntValueAttribute(1324)]
        InvalidUserID = 1324,
        [IntValueAttribute(1325)]
        InvalidTerminalID = 1325,
        [IntValueAttribute(1326)]
        PanValidationFailedRequest = 1326,
        [IntValueAttribute(1327)]
        PanValidationFailed_AttemptExceed = 1327,
        [IntValueAttribute(1328)]
        PanValidationFailed_PanCount = 1328,
        [IntValueAttribute(1329)]
        PanValidationFailed_signfailed = 1329,
        [IntValueAttribute(1330)]
        PanValidationFailed_AddressNotFound = 1330,
        [IntValueAttribute(1331)]
        MerlatLongSuccess = 1331,
        [IntValueAttribute(1332)]
        MerlatLongFailed = 1332,
        [IntValueAttribute(1333)]
        RequestdataNotFound = 1333,
        [IntValueAttribute(1334)]
        AcctNoNotFound = 1334,
        [IntValueAttribute(1335)]
        EKYCStatusFound = 1335,
        [IntValueAttribute(1336)]
        EKYCStatusNotFound = 1336,
        [IntValueAttribute(1337)]
        ReqFormatErr = 1337,
        [IntValueAttribute(1338)]
        MerStatusUpdate = 1338,
        [IntValueAttribute(1339)]
        MerStatusUpdateFailed = 1339,
        [IntValueAttribute(1340)]
        AddProd_pincode = 1340,
        [IntValueAttribute(1341)]
        AddProd_AllowCust = 1341,
        [IntValueAttribute(1342)]
        CustDataFound = 1342,
        [IntValueAttribute(1343)]
        CustDataNotFound = 1343,
        #endregion

        #region Lic Billpayment
        [IntValueAttribute(1350)]
        FetchLICBillpaymentDetailSuccess = 1350,
        [IntValueAttribute(1351)]
        FetchLICBillpaymentDetailFailed = 1351,
        [IntValueAttribute(1352)]
        FetchLICBillpaymentChargesSuccess = 1352,
        [IntValueAttribute(1353)]
        FetchLICBillpaymentChargesFailed = 1353,
        [IntValueAttribute(1354)]
        PostLICBillpaymentTransactionSuccess = 1354,
        [IntValueAttribute(1355)]
        PostLICBillpaymentTransactionFailed = 1355,
        #endregion

        #region Cc Billpayment
        [IntValueAttribute(1360)]
        FetchCcBillpaymentDetailSuccess = 1360,
        [IntValueAttribute(1361)]
        FetchCcBillpaymentDetailFailed = 1361,
        [IntValueAttribute(1362)]
        FetchCcBillpaymentChargesSuccess = 1362,
        [IntValueAttribute(1363)]
        FetchCcBillpaymentChargesFailed = 1363,
        [IntValueAttribute(1364)]
        PostCcBillpaymentTransactionSuccess = 1364,
        [IntValueAttribute(1365)]
        PostCcBillpaymentTransactionFailed = 1365,
        #endregion

        #region CMS Cash Collection
        [IntValueAttribute(700600)]
        TokenNotGenerated = 700600,
        [IntValueAttribute(700601)]
        DownloadLatest = 700601,
        [IntValueAttribute(700602)]
        SuspiciousTransactionDetected = 700602,
        [IntValueAttribute(700603)]
        AmtMismatch = 700603,
        [IntValueAttribute(700604)]
        BlankToken = 700604,
        [IntValueAttribute(700613)]
        MagmaCustValidation = 700613,
        #endregion
        [IntValueAttribute(1401)]
        invalidMapperID = 1401,

        #region CMSLogin DNN
        [IntValueAttribute(8020)]
        GetCMSTickerDataSuccess = 8020,
        [IntValueAttribute(8021)]
        GetCMSTickerDataFailed = 8021,
        [IntValueAttribute(8022)]
        GetCMSImageBannerDataSuccess = 8022,
        [IntValueAttribute(8023)]
        GetCMSImageBannerDataFailed = 8023,
        [IntValueAttribute(8024)]
        GetCMSGyankoshDataSuccess = 8024,
        [IntValueAttribute(8025)]
        GetCMSGyankoshDataFailed = 8025,
        [IntValueAttribute(8026)]
        GetCMSLatestSchemesDataSuccess = 8026,
        [IntValueAttribute(8027)]
        GetCMSLatestSchemesDataFailed = 8027,
        [IntValueAttribute(8028)]
        GetCMSSliderImageDataSuccess = 8028,
        [IntValueAttribute(8029)]
        GetCMSSliderImageDataFailed = 8029
        #endregion
    }


}
