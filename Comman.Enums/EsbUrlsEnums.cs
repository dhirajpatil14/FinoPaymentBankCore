using Utility.Attributes;

namespace Common.Enums
{
    public enum EsbUrls
    {
        //Login Service Url
        [IntValueAttribute(28)]
        EsbCheckAuthenticationUrl = 28,
        [IntValueAttribute(46)]
        EsbUserFPAuthentication = 46,
        [IntValueAttribute(29)]
        EsbTokenGenerateUrl = 29,
        [IntValueAttribute(137)]
        EsbNewTokenUrl = 137,
        [IntValueAttribute(1)]
        EsbLoginUrl = 1,
        [IntValueAttribute(2)]
        EsbUserDetailsUrl = 2,
        [IntValueAttribute(3)]
        EsbTelelrProofUrl = 3,
        [IntValueAttribute(30)]
        EsbLogoutUrl = 30,
        [IntValueAttribute(41)]
        EsbAuthContextUrl = 41,
        [IntValueAttribute(46)]
        EsbFpVerificationUrl = 46,
        [IntValueAttribute(47)]
        EsbValidateTokenUrl = 47,
        [IntValueAttribute(107)]
        EsbUserUnlockUrl = 107,
        [IntValueAttribute(545)]
        EsbUserUnBlockValidateTokenUrl = 545,
        [IntValueAttribute(546)]
        EsbUserUnBlockUrl = 546,
        [IntValueAttribute(552)]
        EsbUserUnBlockStatusUrl = 552,
        [IntValueAttribute(553)]
        EsbMerchantUserUnBlockUrl = 553,
        [IntValueAttribute(186)]
        EsbAddAccountRestrictionUrl = 186,
        [IntValueAttribute(123)]
        EsbGetSecretQuestion = 123,
        [IntValueAttribute(116)]
        EsbUpdateSecretQuestion = 116,
        [IntValueAttribute(121)]
        EsbUserValidateSecretQuestion = 121,
        [IntValueAttribute(125)]
        EsbSetPasswordOrchestration = 125,
        [IntValueAttribute(392)]
        EsbSetPasswordOrchestrationwithOtp = 392,
        [IntValueAttribute(128)]
        EsbChangePassword = 128,
        [IntValueAttribute(402)]
        EsbChangePasswordWithAuth = 402,
        [IntValueAttribute(538)]
        EsbUnblockUserPassword = 538,
        [IntValueAttribute(98)]
        EsbGetSecretQuestionsList = 98,
        [IntValueAttribute(151)]
        EsbGetManagementHealth = 151,
        [IntValueAttribute(329)]
        EsbUpdateMerchantStatus = 329,
        // EsbUpdateSecretQuestion = 99,
        //Transaction Service Url
        [IntValueAttribute(11)]
        EsbCashCountUrl = 11,
        [IntValueAttribute(403)]
        EsbLoginSendOTP = 403,
        [IntValueAttribute(404)]
        EsbAuthProfileOTP = 404,
        [IntValueAttribute(405)]
        EsbMasterServiceURL = 405,
        [IntValueAttribute(460)]
        EsbRMFAadharAuth = 460,
        [IntValueAttribute(461)]
        EsbRMFPanAuth = 461,
        [IntValueAttribute(463)]
        EsbRMFFolioCreation = 463,
        [IntValueAttribute(464)]
        EsbRMFPurchase = 464,
        [IntValueAttribute(465)]
        EsbRMFSchemeDetails = 465,
        [IntValueAttribute(466)]
        EsbRMFTxnDetails = 466,

        [IntValueAttribute(10)]
        EsbIntraBeneficiaryUrl = 10,
        [IntValueAttribute(9)]
        EsbAddBeneficiaryUrl = 9,
        [IntValueAttribute(42)]
        EsbAddExternalBeneficiaryUrl = 42,
        [IntValueAttribute(4)]
        EsbCheckChargesUrl = 4,
        [IntValueAttribute(8)]
        EsbPostTransactionUrl = 8,
        [IntValueAttribute(5)]
        EsbDeleteBeneficiaryUrl = 5,
        [IntValueAttribute(722)]
        EsbDeleteBeneficiaryWithAuthUrl = 722,
        [IntValueAttribute(6)]
        EsbMiniStatementUrl = 6,
        [IntValueAttribute(7)]
        EsbIFSCCodeUrl = 7,
        [IntValueAttribute(39)]
        EsbNeftTransactionTimingUrl = 39,
        [IntValueAttribute(68)]
        EsbIMPSTransactionUpdateUrl = 68,
        [IntValueAttribute(106)]
        ESBGetTransactionAuthProfileUrl = 106,
        [IntValueAttribute(108)]
        // NonFinancial and Financial
        EsbFindCustomerNonFinancialUrl = 108,
        [IntValueAttribute(42)]
        EsbExtraBeneficiaryUrl = 42,
        [IntValueAttribute(122)]
        EsbGLAccountBalanceUrl = 122,
        [IntValueAttribute(167)]
        // Financial and NonFinancial
        EsbMarkasFavouriteUrl = 167,
        [IntValueAttribute(168)]
        EsbGetAccountStatement = 168,
        [IntValueAttribute(479)]
        EsbGetAccountStatementPagination = 479,
        [IntValueAttribute(851)]
        EsbGetIntCertpreFinyear = 851,
        [IntValueAttribute(852)]
        EsbGetIntCertpreFinyearSweep = 852,
        [IntValueAttribute(90)]
        EsbA2ATransferUrl = 90,
        //Registration Service Url
        [IntValueAttribute(15)]
        EsbTellerProofUrl = 15,
        [IntValueAttribute(16)]
        EsbBranchProofUrl = 16,
        [IntValueAttribute(17)]
        EsbAccountHistoryUrl = 17,
        [IntValueAttribute(18)]
        EsbUpdateCashCountUrl = 18,
        [IntValueAttribute(19)]
        EsbCustomerUpdateUrl = 19,
        [IntValueAttribute(40)]
        EsbAccountOpeningUrl = 40,
        [IntValueAttribute(290)]
        EsbAccountOpeningCardLinkUrl = 290,
        [IntValueAttribute(294)]
        EsbExistingCustomerGrievanceUrl = 294,
        [IntValueAttribute(1102)]
        EsbExistingCustomerGrievanceViewUrl = 1102,
        [IntValueAttribute(1101)]
        EsbExistingCustomerGrievanceFindUrl = 1101,
        [IntValueAttribute(424)]
        EsbExistingCustomerReamrkUrl = 424,
        [IntValueAttribute(322)]
        EsbUrlTrackSurveys = 322,
        [IntValueAttribute(323)]
        EsbUrlAccountCheck = 323,
        [IntValueAttribute(399)]
        EsburlDMSDMSKitRequest = 399,
        [IntValueAttribute(549)]
        EsburlDMSDMSKitRequestValidation = 549,//added for RN0489
        [IntValueAttribute(556)]
        EsburlDMSDMSKitTransfer = 556,//added for RN0489
        [IntValueAttribute(550)]
        EsbUrlDMSChequeIssuanceAvalidation = 550,
        [IntValueAttribute(551)]
        EsbUrlChequeIssuanceAPI = 551,
        [IntValueAttribute(335)]
        EsburlDmsUpdatekitStatus = 335,
        [IntValueAttribute(336)]
        EsburlDMskitAcknowlegdment = 336,
        [IntValueAttribute(346)]
        EsburlUpdateSI = 346,
        [IntValueAttribute(347)]
        EsburlViewSIList = 347,
        [IntValueAttribute(348)]
        EsburlCreateSIRequest = 348,
        [IntValueAttribute(349)]
        EsburlDeleteSI = 349,
        [IntValueAttribute(60)]
        EsbSimpleWalletCreateUrl = 60,
        [IntValueAttribute(25)]
        LocalFingerPrintUploadUrl = 25,
        [IntValueAttribute(38)]
        EsbSearchCustomerUrl = 38,
        [IntValueAttribute(44)]
        EsbCustomerPhotoUrl = 44,
        [IntValueAttribute(14)]
        EsbCustomerDetailsUrl = 14,
        [IntValueAttribute(45)]
        EsbUpdateCustomerPhotoUrl = 45,
        [IntValueAttribute(12)]
        EsbOtpUrl = 12,
        [IntValueAttribute(20)]
        EsbFindCustomerUrl = 20,
        [IntValueAttribute(138)]
        EsbNewFindCustomerUrl = 138,
        [IntValueAttribute(519)]
        EsbFindCustomerURLBillPayBackendValidation = 519,
        [IntValueAttribute(520)]
        EsbSearchWalkingCustomersUrlBackendValidation = 520,
        [IntValueAttribute(521)]
        EsbFindCustomerURLFTBackendValidation = 521,
        [IntValueAttribute(521)]
        EsbFindCustomerURLUPIService = 521,
        [IntValueAttribute(523)]
        EsbFindCustomerURLCardTransaction = 523,
        [IntValueAttribute(362)]
        EsbNewFindCustomerUrlLogin = 362,
        [IntValueAttribute(27)]
        ESBEKYCUrl = 27,
        [IntValueAttribute(212)]
        EsbLienMarkingUrl = 212,
        [IntValueAttribute(213)]
        EsbGetAccountHold = 213,
        [IntValueAttribute(214)]
        EsbRemoveAccountHold = 214,
        [IntValueAttribute(300)]
        EsbAccountOpeningRequestDetails = 300,
        [IntValueAttribute(310)]
        EsbAccountNumberDetails = 310,
        [IntValueAttribute(457)]
        EsbAccountEsignSaerch = 457,
        [IntValueAttribute(456)]
        EsbAccountEsign = 456,
        [IntValueAttribute(320)]
        ESBGetInstakitDetails = 320,
        [IntValueAttribute(321)]
        ESBServiceRequestCountURL = 321,
        [IntValueAttribute(464)]
        FasttagEsbOtpUrl = 464,
        [IntValueAttribute(822)]
        RasecashinintebtSMS = 822,

        #region "BillDesk"
        [IntValueAttribute(48)]
        EsbBillDeskUrl = 48,
        [IntValueAttribute(120)]
        EsbBillPaymentUrl = 120,
        [IntValueAttribute(131)]
        EsbBillPaymentOrcUrl = 131,
        [IntValueAttribute(171)]
        EsbTransactionDBLogUrl = 171,
        [IntValueAttribute(232)]
        EsbDMTTransactionDBLogUrl = 232,
        [IntValueAttribute(717)]
        ESBBBPSFetchUrl = 717,
        [IntValueAttribute(718)]
        ESBBBPSBillpayURL = 718,
        [IntValueAttribute(719)]
        ESBShigrapayFetchUrl = 719,
        [IntValueAttribute(720)]
        ESBShigrapayBillpayURL = 720,
        #endregion
        [IntValueAttribute(55)]
        EsbIMPSWalletAccountUrl = 55,
        //EsbGLAccountBalanceUrl = 122,
        [IntValueAttribute(104)]
        EsbGetGLAccountBalanceUrl = 104,
        [IntValueAttribute(105)]
        EsbRemoveAccountRestrictionUrl = 105,
        [IntValueAttribute(109)]
        EsbsetMobileBankingPINUrl = 109,
        [IntValueAttribute(110)]
        EsbRegisterMBCustomerUrl = 110,
        [IntValueAttribute(111)]
        EsbchangemobilebankingpinUrl = 111,
        [IntValueAttribute(119)]
        EsbURLGetEncryptKey = 119,
        [IntValueAttribute(149)]
        EsbGetAccountRestrictionDetails = 149,
        [IntValueAttribute(181)]
        EsbGetLMSAccountBalanecDetails = 181,
        [IntValueAttribute(169)]
        EsbUpdateKitStatusUrl = 169,
        [IntValueAttribute(515)]
        EsbWelcomeKITACKStatusUrl = 515,
        [IntValueAttribute(555)]
        EsbDMSGetAccountStatusUrl = 555,
        [IntValueAttribute(608)]
        EsbGetWorkingAddressUrl = 608,
        [IntValueAttribute(609)]
        EsbForm60StatusUrl = 609,
        [IntValueAttribute(738)]
        EsbGetAdharSeedingEnquiryUrl = 738,
        [IntValueAttribute(741)]
        EsbGetMobileDedupeDMSUrl = 741,
        [IntValueAttribute(7007)]
        EsbGetCCCodeDedupeFromDMSUrl = 7007,
        [IntValueAttribute(566)]
        ESBDMSAdharVaultDetails = 566,
        [IntValueAttribute(571)]
        ESBADVDetailsURL = 571,
        [IntValueAttribute(143)]
        EsbURLLoginGetEncryptKey = 143,
        [IntValueAttribute(210)]
        EsbAddAccountRestriction = 210,
        //EsbFindCustomerNonFinancialUrl = 108,
        //FP Upload Service
        [IntValueAttribute(758)]
        EsbUrlMerchantRegistrationPOS = 758,//RN1606
        [IntValueAttribute(21)]
        CustomerSearchESBServiceUrl = 21,
        [IntValueAttribute(23)]
        ESBCustomerCreateURL = 23,
        [IntValueAttribute(24)]
        ESBCustomerAccountCreateURL = 24,

        //UI Service
        [IntValueAttribute(526)]
        LTS_ServiceURL = 526,//RN904

        //RN2145
        [IntValueAttribute(9006)]
        EsbGetSelectingCasaStatusUrl = 9006,
        [IntValueAttribute(9005)]
        EsbGetRevisionStatusUrl = 9005,
        [IntValueAttribute(9004)]
        EsbGetTrackRevisionUrl = 9004,
        //End RN2145
        [IntValueAttribute(528)]
        COLAServiceURL = 528,
        [IntValueAttribute(26)]
        GetProductList_ServiceURL = 26,
        [IntValueAttribute(31)]
        Login_ServiceURL = 31,
        [IntValueAttribute(9033)]
        LoginF_ServiceURL = 9033,
        [IntValueAttribute(9034)]
        LoginS_ServiceURL = 9034,
        [IntValueAttribute(9035)]
        LoginTR_ServiceURL = 9035,
        [IntValueAttribute(607)]
        NonLogin_ServiceURL = 607,
        [IntValueAttribute(32)]
        Registration_ServiceURL = 32,
        [IntValueAttribute(3335)]
        FindCustomer_ServiceURL = 3335,
        [IntValueAttribute(33)]
        Transaction_ServiceURL = 33,
        [IntValueAttribute(34)]
        OtpGeneration_ServiceURL = 34,
        [IntValueAttribute(35)]
        Utility_ServiceURL = 35,
        [IntValueAttribute(36)]
        URLCustomerInbox = 36,
        [IntValueAttribute(130)]
        URLDMSService = 130,
        [IntValueAttribute(136)]
        URLMobileService = 136,
        [IntValueAttribute(118)]
        Login_ServiceURLNEW = 118,
        [IntValueAttribute(462)]
        RMF_ServiceURL = 462,
        [IntValueAttribute(37)]
        URLFPVerification = 37,
        [IntValueAttribute(620)]
        URLFPVerificationProcessRequest = 620,
        [IntValueAttribute(77)]
        URLMasterData = 77,
        [IntValueAttribute(9032)]
        URLMasterDataMB = 9032,
        [IntValueAttribute(9039)]
        URLGetFullMasterData = 9039,
        [IntValueAttribute(9040)]
        URLMasterCategoryData = 9040,
        [IntValueAttribute(9041)]
        URLMasterPrintData = 9041,
        [IntValueAttribute(9042)]
        URLMasterProfileData = 9042,
        [IntValueAttribute(9043)]
        URLMasterRegularKeyData = 9043,
        [IntValueAttribute(117)]
        URLCheckValidUser = 117,
        [IntValueAttribute(112)]
        URLBillPayment = 112,
        [IntValueAttribute(113)]
        URLFPFinancialService = 113,
        [IntValueAttribute(114)]
        URLFPNonFinancialService = 114,
        [IntValueAttribute(603)]
        URLFPCustomerInfoService = 603,
        [IntValueAttribute(604)]
        URlEKYCDataFetch = 604,//added for ekyc data fetch
        [IntValueAttribute(342)]
        URLFPNonFinancialReportService = 342,
        [IntValueAttribute(118)]
        Login_ServiceURLNew = 118,
        [IntValueAttribute(206)]
        URLCardTransactionService = 206,
        [IntValueAttribute(231)]
        URLCashProcessURL = 231,
        [IntValueAttribute(353)]
        URLEmailNotification = 353,

        //Service Request Service
        [IntValueAttribute(43)]
        ESBPanValidationUrl = 43,
        [IntValueAttribute(50)]
        EsbAddBeneficiaryWithAuthUrl = 50,
        [IntValueAttribute(58)]
        EsbAadhaarLpgSeedingUrl = 58,
        [IntValueAttribute(56)]
        EsbDbtlSeedingUrl = 56,
        [IntValueAttribute(57)]
        EsbUpdateAccountUrl = 57,
        [IntValueAttribute(61)]
        EsbServiceRequestServiceUrl = 61,
        [IntValueAttribute(67)]
        EsbUpdateServiceRequestUrl = 67,
        [IntValueAttribute(1000)]
        ESBCASAPLUSCDownloadStatementUrl = 1000,
        [IntValueAttribute(568)]
        EsbServiceRequestOTPVerifyUrl = 568,
        [IntValueAttribute(70)]
        EsbAccountDetailsUrl = 70,
        [IntValueAttribute(69)]
        EsbFetchCustomerInformationUrl = 69,
        [IntValueAttribute(71)]
        EsbCustomerAllDetailsUrl = 71,
        [IntValueAttribute(543)]
        EsbRemoveCreditfrezzRestriction = 543,
        [IntValueAttribute(72)]
        EsbPassbookUpdationUrl = 72,
        [IntValueAttribute(74)]
        EsbEmailIndemnifyUrl = 74,
        [IntValueAttribute(142)]
        EsbSRDMSStatusUrl = 142,
        [IntValueAttribute(823)]
        EsbAccountClosureSRDMSStatusUrl = 823,
        [IntValueAttribute(282)]
        EsbCustomerGrievanceServiceUrl = 282,
        [IntValueAttribute(1100)]
        EsbCustomerGrievanceCreateServiceUrl = 1100,
        [IntValueAttribute(293)]
        EsbFreezingAccountUrl = 293,
        [IntValueAttribute(317)]
        EsbLienMarkingOrchestrationUrl = 317,
        [IntValueAttribute(516)]
        EsbEJLogs = 516,
        //DMS Service Request
        [IntValueAttribute(127)]
        EsbDmsRevisionUrl = 127,
        [IntValueAttribute(49)]
        EsbGetDMSDataUrl = 49,
        [IntValueAttribute(59)]
        EsbSearchInstaKitUrl = 59,
        [IntValueAttribute(62)]
        EsbDMSRevisionDetailsUrl = 62,
        [IntValueAttribute(554)]
        EsbRemovewalletRestriction = 554,
        [IntValueAttribute(7003)]
        EsbaddaccountblockRestriction = 7003,
        [IntValueAttribute(63)]
        EsbFindCustomerByCardNoUrl = 63,
        [IntValueAttribute(64)]
        EsbFindCustomerByAccountNoUrl = 64,
        [IntValueAttribute(65)]
        EsbAddDeleteAccountRelationsheepUrl = 65,
        [IntValueAttribute(66)]
        EsbSearchDMSDataUrl = 66,
        [IntValueAttribute(73)]
        EsbSmsSerivceUrl = 73,
        [IntValueAttribute(101)]
        EsbKibanaLoggerUrl = 101,
        [IntValueAttribute(102)]
        EsbTransactionLoggerUrl = 102,
        [IntValueAttribute(103)]
        EsbRegistrationLoggerUrl = 103,
        [IntValueAttribute(104)]
        EsbFPUploadLoggerUrl = 104,
        [IntValueAttribute(105)]
        EsbUIServiceLoggerUrl = 105,
        [IntValueAttribute(106)]
        EsbServiceRequestLoggerUrl = 106,
        [IntValueAttribute(909)]
        ESBCashInReversalUrl = 909,
        [IntValueAttribute(78)]
        ESBCashDepositUrl = 78,
        [IntValueAttribute(511)]
        ESBCASAPLUSFundTransferUrl = 511,
        [IntValueAttribute(512)]
        ESBCASAPLUSViewBalnceUrl = 512,
        [IntValueAttribute(547)]
        ESBCASAPLUSCViewStatementUrl = 547,
        [IntValueAttribute(472)]
        ESBCashDepositTransLimitUrl = 472,
        [IntValueAttribute(79)]
        EsbCashWithdrawUrl = 79,
        [IntValueAttribute(90)]
        EsbAccountTransfer = 90,
        [IntValueAttribute(50)]
        EsbBeneficiaryWithAuth = 50,
        [IntValueAttribute(124)]
        EsbRemitanceAccountOpeningUrl = 124,
        [IntValueAttribute(126)]
        EsbIMPSNEFTTransaction = 126,
        [IntValueAttribute(129)]
        EsbGLAccountUrl = 129,
        [IntValueAttribute(132)]
        EsbCreatenewCustomerUrl = 132,
        [IntValueAttribute(133)]
        EsbfindcustomerUrl = 133,
        [IntValueAttribute(134)]
        EsbGetAuthProfileUrl = 134,
        [IntValueAttribute(135)]
        EsbAuthenticateUrl = 135,
        [IntValueAttribute(139)]
        EsbMobileOTPGeneration = 139,
        //Insurance
        [IntValueAttribute(517)]
        EsbFetchAadharNoADV = 517,
        [IntValueAttribute(522)]
        EsbUpdateCustomerdetials = 522,
        [IntValueAttribute(298)]
        InsurancePremiumPaidSuccessful = 298,
        [IntValueAttribute(299)]
        InsurancePremiumPaidFailed = 299,
        [IntValueAttribute(140)]
        EsbInsuranceURL = 140,
        [IntValueAttribute(141)]
        EsbInsuranceServiceURL = 141,
        [IntValueAttribute(233)]
        EsbDMTInsuranceServiceURL = 233,
        [IntValueAttribute(143)]
        EsbSendNotificationServiceURL = 143,
        [IntValueAttribute(146)]
        EsbUpdateBeneUrl = 146,
        [IntValueAttribute(145)]
        EsbGetWalkInCustomerUrl = 145,
        [IntValueAttribute(144)]
        EsbGetWalkInTransactionUrl = 144,
        [IntValueAttribute(147)]
        EsbAccountLimitUrl = 147,
        [IntValueAttribute(148)]
        EsbSupervisiorDetailsUrl = 148,
        [IntValueAttribute(218)]
        EsbGetClosureAmountUrl = 218,
        [IntValueAttribute(260)]
        EsbGetExternalAccount = 260,
        [IntValueAttribute(271)]
        EsbUpdateExternalAccount = 271,
        [IntValueAttribute(272)]
        EsbCloseExternalAccount = 272,
        [IntValueAttribute(295)]
        EsbGetCustomerDetailsUrl = 295,
        [IntValueAttribute(299)]
        EsbGetExideClaimsInsurance = 299,
        [IntValueAttribute(465)]
        EsbTwoWheelerQuoteServiceURL = 465,
        [IntValueAttribute(473)]
        EsbProposalAPIInsurance = 473,
        [IntValueAttribute(474)]
        EsbTWSPApprovalAPIInsurance = 474,
        [IntValueAttribute(476)]
        EsbTWCOIAPIInsurance = 476,
        [IntValueAttribute(480)]
        EsbProposalGenerationAPIInsurance = 480,
        [IntValueAttribute(463)]
        fasttagEsbAccountLimitUrl = 463,
        [IntValueAttribute(527)]
        EsbUpdateCustomerdetialsfastag = 527,
        [IntValueAttribute(737)]
        fasttagEsbAccountRestrictionUrl = 737,
        //DashboardReport
        [IntValueAttribute(152)]
        getDashboardbyBranchUrl = 152,
        [IntValueAttribute(153)]
        getdashboardbybranchchannelUrl = 153,
        [IntValueAttribute(154)]
        getdashboardbybranchproductUrl = 154,
        [IntValueAttribute(155)]
        getdashboardbybranchtrantypeUrl = 155,
        [IntValueAttribute(156)]
        getdashboardbychannelUrl = 156,
        [IntValueAttribute(157)]
        getdashboardbychannelproductUrl = 157,
        [IntValueAttribute(158)]
        getdashboardbyuserUrl = 158,
        [IntValueAttribute(159)]
        getdashboardbytrantypeUrl = 159,
        [IntValueAttribute(160)]
        getdashboardbyuserproductUrl = 160,
        [IntValueAttribute(161)]
        getdashboardbyusertrantypeUrl = 161,
        [IntValueAttribute(162)]
        getdashboardtxnlistUrl = 162,
        [IntValueAttribute(784)]
        getdashboardtxnlistpaginationUrl = 784,
        [IntValueAttribute(163)]
        getdashboardbyproductUrl = 163,
        [IntValueAttribute(164)]
        getdashboardbycustomerUrl = 164,
        [IntValueAttribute(165)]
        getdashboardbychanneltrantypeUrl = 165,
        [IntValueAttribute(166)]
        EsbDMSServiceRequestUrl = 166,
        [IntValueAttribute(170)]
        getdashboardbyMinistatementUrl = 170,
        [IntValueAttribute(172)]
        DashBoardsReportsURL = 172,
        [IntValueAttribute(173)]
        gettxnstatusreport = 173,
        //mahes 23082018
        [IntValueAttribute(514)]
        getmerchantcashreport = 514,
        //mahesh

        //Mahesh 23072020
        [IntValueAttribute(782)]
        getneftrtgs = 782,
        [IntValueAttribute(783)]
        getrrnesburl = 783,
        //Mahesh 23072020

        //Cashout 
        [IntValueAttribute(9012)]
        EsbTranCashoutFindUrl = 9012,
        [IntValueAttribute(9013)]
        EsbRegistrationCashoutFindUrl = 9013,
        [IntValueAttribute(9014)]
        EsbRegistrationStatusCashoutFindUrl = 9014,
        [IntValueAttribute(457)]
        GetBonusHubTxnList = 475,
        [IntValueAttribute(174)]
        EsbGetDMSRejectionMobileDataUrl = 174,
        [IntValueAttribute(175)]
        EsbCashCollectionVerificationServiceURL = 175,
        [IntValueAttribute(354)]
        EsbCashCollectionRivigoDisbursementURL = 354,
        [IntValueAttribute(176)]
        EsbCashCollectionTransactionServiceURL = 176,
        [IntValueAttribute(344)]
        EsbCashCollectionTransactionDetails = 344,
        [IntValueAttribute(177)]
        URLCashCollection = 177,
        [IntValueAttribute(652)]
        URLReferalLoan = 652,
        [IntValueAttribute(756)]
        URLMerchantLoanInternal = 756,
        [IntValueAttribute(761)]
        MerchantLoanEsbValidateTokenUrl = 761,
        [IntValueAttribute(910)]
        URLCashinadminserviceurlid = 910,
        [IntValueAttribute(1013)]
        URLCashinalocationserviceurlid = 1013,
        [IntValueAttribute(775)]
        MerchantLoanEsbVerifystatusURL = 775,

        [IntValueAttribute(762)]
        MerchantLoanEsbVerifyOTP = 762,
        [IntValueAttribute(182)]
        EsbResendSMS = 182,
        [IntValueAttribute(183)]
        ESBSupervisorUserDetailsUrl = 183,
        [IntValueAttribute(184)]
        ESBLockUserDetailsUrl = 184,
        [IntValueAttribute(185)]
        ESBUnlockUserDetailsUrl = 185,
        [IntValueAttribute(187)]
        EsbRemoveSupervisorAccountRestrictionUrl = 187,
        [IntValueAttribute(188)]
        EsbPPIWalletImpsNeftUrl = 188,
        [IntValueAttribute(850)]
        EsbNewBeneVerificationUrl = 850,
        [IntValueAttribute(178)]
        EsbSearchWalkingCustomersUrl = 178,
        [IntValueAttribute(179)]
        EsbWalkinCustomerLimitUrl = 179,

        /*CTS Posting*/
        [IntValueAttribute(471)]
        CTSPosting = 471,

        /*Card Transaction */
        [IntValueAttribute(207)]
        EsbCardLogOnkeyExchange = 207,
        [IntValueAttribute(209)]
        EsbCardCreditDebitTransaction = 209,
        [IntValueAttribute(318)]
        ESBEodProcessUserList = 318,
        [IntValueAttribute(319)]
        ESBEodBranchCloseProcess = 319,
        [IntValueAttribute(208)]
        EsbCardBalanceEnquiryTransaction = 208,
        [IntValueAttribute(215)]
        EsbCardSetPIN = 215,
        [IntValueAttribute(216)]
        EsbCreateCardNumber = 216,
        [IntValueAttribute(217)]
        EsbUpdateCardStatus = 217,
        [IntValueAttribute(219)]
        EsbGetCardDetailsWithCVV = 219,
        [IntValueAttribute(220)]
        EsbVerifyCardPin = 220,
        [IntValueAttribute(221)]
        EsbLinkCardToAccount = 221,
        [IntValueAttribute(452)]
        EsbMicroATMLTSUrl = 452,
        [IntValueAttribute(477)]
        EsbMicroATMLast10TxnUrl = 477,
        [IntValueAttribute(567)]
        EsbMicroATMTxnStatusUrl = 567,
        [IntValueAttribute(481)]
        EsbCardTransactionCheckRRNUrl = 481,
        [IntValueAttribute(542)]
        EsbCardEMVReversal = 542,
        [IntValueAttribute(559)]
        EsbCardEMVAck = 559,
        [IntValueAttribute(568)]
        EsbCardCreditDebitTransactionEMV = 568,
        [IntValueAttribute(739)]
        EsbEMVMicroATMLTSUrl = 739,
        [IntValueAttribute(740)]
        EsbEMVMicroATMLast10TxnUrl = 740,
        [IntValueAttribute(560)]
        EsbHsmDownload = 560,
        [IntValueAttribute(561)]
        EsbHsmAck = 561,

        [IntValueAttribute(211)]
        ESBurlVerifyTPIN = 211,
        [IntValueAttribute(222)]
        ESBCashProcessUserDetailsUrl = 222,
        [IntValueAttribute(224)]
        ESBCashProcessVaultDetailsUrl = 224,
        [IntValueAttribute(225)]
        ESBCashProcessVaultBalanceUrl = 225,
        [IntValueAttribute(223)]
        ESBReversalUrl = 223,
        [IntValueAttribute(724)]
        ESBReversalCutOffUrl = 724,
        [IntValueAttribute(226)]
        ESBUpdateBucketBalanceUrl = 226,
        [IntValueAttribute(227)]
        ESBAEPSTransactionUrl = 227,
        [IntValueAttribute(767)]
        ESBAEPSTransactionBAVUrl = 767,
        [IntValueAttribute(768)]
        ESBAEPSVerifyBAVUrl = 768,
        [IntValueAttribute(769)]
        ESBAEPSCDAVUrl = 769,
        [IntValueAttribute(584)]
        ESBAEPSCashDOnusUrl = 584,
        [IntValueAttribute(513)]
        ESBAEPSEnquiryTransactionUrl = 513,
        [IntValueAttribute(583)]
        ESBAEPSONUSTransactionUrl = 583,
        [IntValueAttribute(228)]
        ESBAEPSBalanceEnquiryUrl = 228,
        [IntValueAttribute(626)]
        ESBAEPSBalanceEnquiryUrl_New = 626,
        [IntValueAttribute(390)]
        ESBAEPSLastTransEnquiryUrl = 390,
        [IntValueAttribute(391)]
        ESBAEPSLastTransEnquiryGenericUrl = 391,
        [IntValueAttribute(392)]
        ESBAEPSLastTxnTenEnquiryUrl = 392,
        [IntValueAttribute(565)]
        ESBAEPSTxnStatusEnquiryUrl = 565, //For Rn1020
        [IntValueAttribute(581)]
        ESBAEPSTwoFactorAuthentication = 581,//Two Factot Auth

        [IntValueAttribute(582)]
        ESBAEPSTwoFactorSenOtp = 582,//Two Factot Auth
        [IntValueAttribute(600)]
        ESBAEPSTwoFactorMapperID = 600,//Two Factot Auth
        [IntValueAttribute(229)]
        ESBGetLIMITAPRTxnStatusUrl = 229,
        [IntValueAttribute(230)]
        ESBPettyGlBalanceUrl = 230,
        [IntValueAttribute(232)]
        LocalAEPSUrl = 232,
        [IntValueAttribute(625)]
        LocalAEPSBalServiceUrl = 625,
        [IntValueAttribute(633)]
        LocalAEPSMiniServiceUrl = 633,
        [IntValueAttribute(234)]
        ESBCashOUTUrl = 234,
        [IntValueAttribute(236)]
        EsbAdhocstatementUpdateServiceRequestUrl = 236,
        [IntValueAttribute(268)]
        EsbAdhocChargesUrl = 268,
        [IntValueAttribute(298)]
        EsbGetDMSServiceRequestRejectionMobileDataUrl = 298,
        [IntValueAttribute(467)]
        EsbDMSTrackRevisionUrl = 467,
        [IntValueAttribute(322)]
        ESBEodProcessTransaction = 322,
        [IntValueAttribute(343)]
        ESBAEPSFundTransferUrl = 343,
        [IntValueAttribute(458)]
        ESBAEPSTransactionLimitUrl = 458,

        /*UPI Service */
        [IntValueAttribute(367)]
        FISRegisterMerchant = 367,
        [IntValueAttribute(368)]
        FISValidateVpa = 368,
        [IntValueAttribute(369)]
        FISCollectTxn = 369,
        [IntValueAttribute(370)]
        FISGetSearchByTxnId = 370,
        [IntValueAttribute(371)]
        FISTxnHistory = 371,
        [IntValueAttribute(372)]
        FISTxnListByDate = 372,
        [IntValueAttribute(373)]
        FISGetMerchantVirtualAddr = 373,
        [IntValueAttribute(374)]
        FISGetResponse = 374,
        [IntValueAttribute(398)]
        FISRegisterVPA = 398,
        [IntValueAttribute(399)]
        FISGetBeneByMobileNumber = 399,
        [IntValueAttribute(400)]
        FISRegisterBene = 400,
        [IntValueAttribute(401)]
        FISUpdateBene = 401,
        [IntValueAttribute(402)]
        FISGetAccountPvdList = 402,
        [IntValueAttribute(403)]
        FISGetAccountList = 403,
        [IntValueAttribute(404)]
        FISRegisterAccount = 404,
        [IntValueAttribute(405)]
        FISGetAddressLink = 405,
        [IntValueAttribute(406)]
        FISGetListKey = 406,
        [IntValueAttribute(407)]
        FISGetToken = 407,
        [IntValueAttribute(408)]
        FISGetCustomerVirtualAddr = 408,
        [IntValueAttribute(409)]
        FISGetReqBalEnq = 409,
        [IntValueAttribute(410)]
        FISRegisterUPIN = 410,
        [IntValueAttribute(411)]
        FISReqChangeUPIN = 411,
        [IntValueAttribute(412)]
        FISReqGenerateOTP = 412,
        [IntValueAttribute(413)]
        FISRegisterDevice = 413,
        [IntValueAttribute(414)]
        FISRegisterCustomerDetails = 414,
        [IntValueAttribute(415)]
        FISGetSMSDetails = 415,
        [IntValueAttribute(416)]
        FISSendMoney = 416,
        [IntValueAttribute(417)]
        FISGetCollectTxnDetails = 417,
        [IntValueAttribute(418)]
        FISPayCollectTXn = 418,
        [IntValueAttribute(419)]
        FISGetVirtualAddlinkByMobileNo = 419,
        [IntValueAttribute(726)]
        TagIssueVPARegURL = 726,
        [IntValueAttribute(727)]
        TagIssuenceUpdateVPA = 727,
        [IntValueAttribute(420)]
        FISUpdateVirtualAddr = 420,
        [IntValueAttribute(421)]
        FISUpdateCustomerDetails = 421,
        [IntValueAttribute(560)]
        FISUrlRegisterPSPwithDeviceInit = 560,
        [IntValueAttribute(562)]
        FISUrlRegisterPSPWithDeviceNew = 562,
        [IntValueAttribute(561)]
        FISUrlGetSilentSMSdetailsPost = 561,
        [IntValueAttribute(584)]
        FISUrlListAccountV2 = 584,
        [IntValueAttribute(585)]
        FISUrlManageVaeV2 = 585,
        [IntValueAttribute(586)]
        FISUrlValidateAddressV2 = 586,
        [IntValueAttribute(587)]
        FISUrlCheckTxnV2 = 587,
        [IntValueAttribute(588)]
        FISUrlListVaeV2 = 588,
        [IntValueAttribute(589)]
        FISUrlListAccPvdV2 = 589,
        [IntValueAttribute(590)]
        FISUrlBalEngV2 = 590,
        [IntValueAttribute(591)]
        FISUrlReqOTPV2 = 591,
        [IntValueAttribute(592)]
        FISChangeUPINV2 = 592,
        [IntValueAttribute(593)]
        FISUrlListKeyV2 = 593,
        [IntValueAttribute(594)]
        FISUrlGetTokenV2 = 594,
        [IntValueAttribute(595)]
        FISUrlListPSPKeysV2 = 595,
        [IntValueAttribute(596)]
        FISUrlRegisterMPinV2 = 596,
        [IntValueAttribute(597)]
        FISUrlPaySecureV2 = 597,
        [IntValueAttribute(598)]
        FISUrlCollectSecureV2 = 598,
        [IntValueAttribute(599)]
        FISUrlPayColectTxnSecureV2 = 599,
        [IntValueAttribute(600)]
        FISUrlTxnHistrotyV2 = 600,
        [IntValueAttribute(601)]
        FISUrlTxnHistoryByDateV2 = 601,
        [IntValueAttribute(610)]
        FISUrlGetResponseV2 = 610,
        [IntValueAttribute(611)]
        FISUrlRegisterMerchantV2 = 611,
        [IntValueAttribute(612)]
        FISUrlCreateMandateV2 = 612,
        [IntValueAttribute(613)]
        FISUrlUpdateMandateV2 = 613,
        [IntValueAttribute(614)]
        FISUrlRevokeMandateV2 = 614,
        [IntValueAttribute(615)]
        FISUrlViewMandateV2 = 615,
        [IntValueAttribute(616)]
        FISUrlApproveMandateV2 = 616,
        [IntValueAttribute(617)]
        FISUrlUpdateUPIService = 617,
        [IntValueAttribute(619)]
        FISUrlgetvirtuladdrandlinkbymobilenoV1 = 619,
        [IntValueAttribute(620)]
        FISUrlgetvirtuladdrandlinkbymobilenoV2 = 620,
        [IntValueAttribute(621)]
        FISUrlRegisterMerchantP2M = 621,
        [IntValueAttribute(850)]
        EsbNewBeneVerificationUPIUrl = 850,
        [IntValueAttribute(851)]
        FISUrlGetUPITranscationStatus = 851,
        [IntValueAttribute(852)]
        FISUrlRaisecomplaint = 852,
        [IntValueAttribute(531)]
        COLAGetAccessTokenUrl = 531,
        [IntValueAttribute(532)]
        COLAGetMerchantDetailsUrl = 532,
        [IntValueAttribute(533)]
        COLATxnHistroyUrl = 533,
        [IntValueAttribute(534)]
        COLAUpdateMerchantDetailsUrl = 534,
        [IntValueAttribute(535)]
        COLATxnPostingUrl = 535,
        [IntValueAttribute(536)]
        COLATxnStatusMasterUrl = 536,
        [IntValueAttribute(537)]
        COLAAcceptTxnRequestUrl = 537,
        [IntValueAttribute(541)]
        COLAMerchantTypeMasterUrl = 541,
        [IntValueAttribute(540)]
        COLATransactionTypeMasterUrl = 540,
        [IntValueAttribute(539)]
        COLAWithdrawalTypeMasterUrl = 539,
        [IntValueAttribute(548)]
        COLAMerchantBulkUpload = 548,
        [IntValueAttribute(722)]
        COLACreateMerchantUrl = 722,
        [IntValueAttribute(723)]
        COLAFindCustomerUrl = 723,


        //ChatBotService Urls
        [IntValueAttribute(641)]
        ChatBotGetAccountStatus = 641,
        [IntValueAttribute(642)]
        ChatBotUPITXnStatus = 642,
        [IntValueAttribute(643)]
        ChatBotServiceUrl = 643,
        [IntValueAttribute(725)]
        ChatBotRESTServiceUrl = 725,
        [IntValueAttribute(645)]
        ChatBotServiceRequestStatusUrl = 645,
        [IntValueAttribute(651)]
        ChatBotTxnStatus = 651,
        [IntValueAttribute(719)]
        ChatBotGetUserDetails = 719,

        //GyanKosh
        [IntValueAttribute(776)]
        GyanKoshServiceUrl = 776,

        //CallLog Service url
        [IntValueAttribute(649)]
        CallLogServiceUrl = 649,
        [IntValueAttribute(705)]
        ESBFindcustomerCallLogUrl = 705,
        [IntValueAttribute(706)]
        ESBgetAccountRestrictionCallLog = 706,
        [IntValueAttribute(707)]
        EsbGetWalkinCustomerCallLog = 707,
        [IntValueAttribute(708)]
        EsbAuthenticateurlCallLog = 708,
        [IntValueAttribute(709)]
        EsbLoginurlCallLog = 709,
        [IntValueAttribute(710)]
        EsbTokenValidateCallLog = 710,
        [IntValueAttribute(721)]
        EsbTransactionStatusUrl = 721,
        [IntValueAttribute(807)]
        EsbCallLogMiniStatementUrl = 807,

        #region SSO
        //Mahesh SSO 10022020
        [IntValueAttribute(653)]
        SSOServiceUrl = 653, // UI Service Generate Token URL Service ID = 5
        [IntValueAttribute(654)]
        SSORestServiceUrl = 654, // UI Rest Service URL Service ID = 5
        [IntValueAttribute(742)]
        SSOAccountLimitServiceUrl = 742, //Service ID = 115
        [IntValueAttribute(743)]
        SSOESBGenerateOTPURL = 743,      //Service ID = 115
        [IntValueAttribute(744)]
        SSOESBFindCustomerURL = 744,      //Service ID = 115
        [IntValueAttribute(745)]
        SSOESBPurchaseTransactionURL = 745,      //Service ID = 115
        [IntValueAttribute(746)]
        SSOESBreversalTransactionURL = 746,      //Service ID = 115
        [IntValueAttribute(750)]
        SSOESBTxnStatus = 750,                   //Service ID = 115
        [IntValueAttribute(752)]
        SSOESBLoginToken = 752,                  //Service ID = 115  -- this is not in production
        [IntValueAttribute(754)]
        SSOESBAuthenticateUrl = 754,            //Service ID = 115
        [IntValueAttribute(755)]
        SSOESBUserLogin = 755,                  //Service ID = 115

        #endregion
        [IntValueAttribute(384)]
        EsbFTVehicleregServiceURL = 384,
        [IntValueAttribute(385)]
        EsbFTBlockUnblockURL = 385,
        [IntValueAttribute(396)]
        EsbGetTagDetailsURL = 396,
        [IntValueAttribute(397)]
        EsbClosedTagURL = 397,
        [IntValueAttribute(898)]
        EsbFTGetcustomerdetailsURL = 898,
        [IntValueAttribute(9026)]
        EsbFTBPAYVehicleregServiceURL = 9026,
        [IntValueAttribute(9027)]
        ESBBarcodeRegStatus = 9027,
        [IntValueAttribute(9028)]
        ESBVehicleRegStatus = 9028,
        [IntValueAttribute(9030)]
        ESBPrefilledVehicleRegDetails = 9030,
        [IntValueAttribute(9031)]
        EsbRegistrationDeletionURL = 9031,

        [IntValueAttribute(453)]
        EsbAadharValidateToken = 453,
        [IntValueAttribute(454)]
        EsbAadharAuthenticationUrl = 454,
        [IntValueAttribute(455)]
        EsbAadharNewTokenUrl = 455,
        [IntValueAttribute(19)]
        EsbUpdateCustomerURL = 19,

        // for merchnat Registration
        [IntValueAttribute(524)]
        ESBMerchantRegistrationURL = 524,
        [IntValueAttribute(525)]
        ESBGetMerchantRegistrationStatusURL = 525,
        [IntValueAttribute(563)]
        ESBGetExceptionMerchantRegURL = 563,

        #region "Lending Transaction Service"
        [IntValueAttribute(240)]
        EsbLendingCGTUploadUrl = 240,
        [IntValueAttribute(243)]
        EsbLendingRECGTUploadUrl = 243,
        [IntValueAttribute(244)]
        EsbLendingSaralhhvUploadUrl = 244,
        [IntValueAttribute(245)]
        EsbLendingSarallucSolarDownload = 245,
        [IntValueAttribute(246)]
        EsbLendingSaralSolarUpload = 246,
        [IntValueAttribute(257)]
        EsbLendingEsbCGTDownLoadUrl = 257,
        [IntValueAttribute(249)]
        EsbHolidayDemandDownloadUrl = 249,
        [IntValueAttribute(250)]
        EsbMaturityDemandDownloadUrl = 250,
        [IntValueAttribute(251)]
        EsbRegularDemandDownloadUrl = 251,
        [IntValueAttribute(252)]
        EsbGroupCenterAttendanceUrl = 252,
        [IntValueAttribute(253)]
        EsbLoanTxnDataUrl = 253,
        [IntValueAttribute(254)]
        EsbGTRDownLoadwebServiceUrl = 254,
        [IntValueAttribute(255)]
        EsbRECGTDownloadwebServiceUrl = 255,
        [IntValueAttribute(256)]
        EsbHHVDownLoadwebServiceUrl = 256,
        [IntValueAttribute(269)]
        EsbUploadGRTDataUrl = 269,
        [IntValueAttribute(270)]
        EsbCreditInquiryServiceUrl = 270,
        [IntValueAttribute(273)]
        EsbAdvanceAndForeClosureUrl = 273,
        [IntValueAttribute(274)]
        EsbESBCustomSearchUrl = 274,
        [IntValueAttribute(275)]
        EsbGetCenterGroupDataUrl = 275,
        [IntValueAttribute(276)]
        EsbDisbursementCustomersdataUrl = 276,
        [IntValueAttribute(277)]
        EsbgetEnrollmentDetailsUrl = 277,
        [IntValueAttribute(278)]
        EsbPostcustomerDisbursementUrl = 278,
        [IntValueAttribute(280)]
        Esb25LegTransactionRepayFYIUrl = 280,
        [IntValueAttribute(281)]
        EsbHOApprovalUrl = 281,
        [IntValueAttribute(283)]
        EsbProbableCenterDownloadUrl = 283,
        [IntValueAttribute(292)]
        EsbTransactionUpdateHoverUrl = 292,
        [IntValueAttribute(296)]
        EsbTransactionRepaymentHoverUrl = 296,
        [IntValueAttribute(297)]
        EsbEODCompletionUrl = 297,
        [IntValueAttribute(325)]
        EsbJayamminiStmtUrl = 325,
        [IntValueAttribute(259)]
        LocalLendingTransUrl = 259,
        [IntValueAttribute(386)]
        EsbJayamEnrollmentAccountOpening = 386,

        #endregion

        #region "Maker Checker"
        /* Maker Checker */
        [IntValueAttribute(261)]
        EsbGetmakerqueue = 261,
        [IntValueAttribute(262)]
        EsbGetCheckerQueue = 262,
        [IntValueAttribute(263)]
        EsbMakerposting = 263,
        [IntValueAttribute(264)]
        EsbMakercancel = 264,
        [IntValueAttribute(265)]
        EsbCheckerApproveRequest = 265,
        [IntValueAttribute(266)]
        EsbCheckerRejectRequest = 266,

        [IntValueAttribute(468)]
        CBSPostingCBSCheckerQueList = 468,
        [IntValueAttribute(469)]
        CBSPostingCBSCheckerApprove = 469,
        [IntValueAttribute(470)]
        CBSPostingCBSCheckerReject = 470,

        #endregion

        #region RTGS
        [IntValueAttribute(279)]
        EsbRTGSTransactionURL = 279,
        #endregion

        #region
        [IntValueAttribute(284)]
        EsbBeneVerificatioUrl = 284,
        #endregion

        #region IMPS/NEFT
        [IntValueAttribute(288)]
        EsbIMPSTransaction = 288,
        [IntValueAttribute(289)]
        EsbNEFTTransaction = 289,
        #endregion

        [IntValueAttribute(345)]
        URLBpayLoyalty = 345,
        [IntValueAttribute(346)]
        URLCDMService = 346,
        [IntValueAttribute(509)]
        URLWhiteLabelPushApi = 509,

        #region "Fino Money Transfer"
        [IntValueAttribute(359)]
        EsbFinoMoneyTransferService = 359,
        [IntValueAttribute(313)]
        EsbFinoMoneyTransferGenerateToken = 313,
        [IntValueAttribute(314)]
        EsbFinoMoneyTransferValidateToken = 314,
        [IntValueAttribute(360)]
        EsbFinoMoneyTransactionUrl = 360,
        [IntValueAttribute(361)]
        EsbFinoMoneyVerificationUrl = 361,
        [IntValueAttribute(363)]
        UrlInventoryMgmtUrl = 363,
        [IntValueAttribute(375)]
        URLUPIService = 375,

        #endregion

        #region Shopkeeper Insurance Policy DMS
        [IntValueAttribute(380)]
        EsbTrackPolicyDmsServiceURL = 380,
        [IntValueAttribute(381)]
        EsbGetPendingPolicyDetailsServiceURL = 381,
        [IntValueAttribute(382)]
        EsbUpdatePolicyDetailsServiceURL = 382,

        #endregion


        #region "Fast Tag"
        [IntValueAttribute(383)]
        FTVehicleRegistrationService = 383,
        [IntValueAttribute(384)]
        EsbFTVehicleRegistrationService = 384,
        [IntValueAttribute(390)]
        EsbTagIssuranceUrl = 390,
        [IntValueAttribute(394)]
        DMSTagVerification = 394,
        #endregion

        #region "IFT File"
        [IntValueAttribute(472)]
        FTIFTFileService = 472,

        #endregion

        #region "Inventory,BULKIMPS,PushNotification"
        [IntValueAttribute(622)]
        InventoryService = 622,
        [IntValueAttribute(623)]
        BULKIMPSService = 623,
        [IntValueAttribute(624)]
        PushNotificationService = 624,
        #endregion

        #region "CASH IN PROCESS"
        [IntValueAttribute(638)]
        CashInProcess = 638,
        #endregion

        [IntValueAttribute(389)]
        ESBAEPSMiniStatementUrl = 389,
        [IntValueAttribute(391)]
        EsbGetUHIDStatusDetailsServiceURL = 391,

        [IntValueAttribute(393)]
        EsbUrlLeadFormLastAction = 393,
        [IntValueAttribute(398)]
        EsbUrlCIFKYCCheck = 398,
        [IntValueAttribute(400)]
        EsbUrlSearchAgent = 400,
        [IntValueAttribute(401)]
        EsbUrlUpdateAgent = 401,
        [IntValueAttribute(510)]
        EsbAuthenticationAPIURL = 510,
        [IntValueAttribute(617)]
        EsbGetAadhaarStatusURL = 617,
        #region "Digital Passbook"
        [IntValueAttribute(573)]
        DigitalServiceURLID = 573,//RN1152,
        [IntValueAttribute(777)]
        CPFIRFraudReport = 777,//RN1852 fraud reporting
        [IntValueAttribute(574)]
        EsbDigitalPassBookAssistedMode = 574,
        #endregion

        #region "Sms Details"
        [IntValueAttribute(986)]
        EsbSmsDetailsURLID = 986,
        [IntValueAttribute(987)]
        EsbOtpDetailsURLID = 987,

        #endregion



        #region "SuryodayAcnClose"
        [IntValueAttribute(576)]
        EsbSuryodayAcnClose = 576,

        #endregion
        #region "Service Request Token Validate"

        [IntValueAttribute(597)]
        EsbServiceRequestValidateTokenUrl = 597,
        [IntValueAttribute(598)]
        EsbServiceRequestCheckAuthenticationUrl = 598,
        [IntValueAttribute(599)]
        EsbServiceRequestNewTokenUrl = 599,


        #endregion
        #region "Send SMS"
        [IntValueAttribute(616)]
        EsbUrlSendSMS = 616,
        #endregion


        # region "MSRTC"
        [IntValueAttribute(391)]
        ESBMSRTCGetCardDetailsUrl = 391,
        [IntValueAttribute(143)]
        ESBGenerateOTPURL = 143,

        #endregion

        #region self declared Kits
        //RN1541
        [IntValueAttribute(712)]
        EsburlGetSelfDeclaredKits = 712,
        [IntValueAttribute(713)]
        EsburlSaveSelfDeclaredKits = 713,
        [IntValueAttribute(714)]
        EsburlGetSelfDeclaredApprovedKits = 714,
        [IntValueAttribute(715)]
        EsburlApproveSelfDeclaredKits = 715,
        #endregion

        #region bbps cg
        [IntValueAttribute(747)]
        Esburlcheckbbpscomplaintstatus = 747,
        [IntValueAttribute(748)]
        strcheckbbpscomplaintdata = 748,
        [IntValueAttribute(749)]
        strSubmitbbpscomplaintdata = 749,
        #endregion


        //added for RN1760
        [IntValueAttribute(732)]
        EsburlDMskitAckPage = 732,

        # region "DNN"
        [IntValueAttribute(711)]
        ESBDNNUrl = 711,

        #endregion
        # region "DNN"
        [IntValueAttribute(723)]
        ESBPassbookCheckLimit = 723,

        #endregion
        [IntValueAttribute(757)]
        EsbEJLogsPagination = 757,
        [IntValueAttribute(758)]
        EsbAEPSMicroATMPaginationCount = 758,
        [IntValueAttribute(759)]
        EsbAEPSPagination = 759,
        [IntValueAttribute(760)]
        EsbMAMTPagination = 760,
        [IntValueAttribute(763)]
        EsbAEPSAadharNoPagination = 763,
        [IntValueAttribute(764)]
        EsbAEPSAadharNoNoOfCount = 764,
        [IntValueAttribute(765)]
        EsbAEPSAadharNoPaginationFilterData = 765,

        [IntValueAttribute(6095)]
        EsbPanInquiryBackend = 6095,
        [IntValueAttribute(766)]
        EsbFPVarify = 766,
        [IntValueAttribute(767)]
        strSubmitIIFLRequest = 767,//RN2023 IIFL
        [IntValueAttribute(790)]
        strTokenIIFLCreation = 790,//RN2023 IIFL
        [IntValueAttribute(768)]
        EsbstrDigitalloanStatus = 768,//RN2053 gigital
        [IntValueAttribute(769)]
        EsbstrSubmitDigitalLoanRequest = 769,//digital
        [IntValueAttribute(770)]
        EsbstrTokenDigitalLoanRequest = 770,//RN2053 digital
        [IntValueAttribute(791)]
        EsbstrDocumentMasterFlex = 791,//digital

        [IntValueAttribute(792)]
        EsbstrDocumentupdate = 792,//digital
        [IntValueAttribute(6096)]
        EsbDMSGuardianNumber = 6096,
        [IntValueAttribute(7511)]
        EsbSetDebitCardPinCount = 7511,
        [IntValueAttribute(759)]
        EsbGetCardLimit = 759,
        [IntValueAttribute(7531)]
        EsbSetCardLimit = 7531,
        [IntValueAttribute(754)]
        EsbSetCardLimitwithAuth = 754,
        [IntValueAttribute(4426)]
        EsbDebitCardSecretKeyGeneration = 4426,
        [IntValueAttribute(6097)]
        ESBGetlocation = 6097,
        [IntValueAttribute(6098)]
        ESBWacounter = 6098,

        //Added By Mahesh 08072020
        [IntValueAttribute(779)]
        ESBFindCustomerRequestLimitURL = 779,

        #region [MSL]
        [IntValueAttribute(9017)]
        EsbstrTokenMSL = 9017,
        [IntValueAttribute(9018)]
        EsbstrcheckEligibilityUrl = 9018,
        [IntValueAttribute(9019)]
        EsbstrApplyLoanUrl = 9019,
        [IntValueAttribute(9020)]
        EsbstrCreateApplicationUrl = 9020,
        [IntValueAttribute(9021)]
        EsbstrcheckStatusUrl = 9021,
        [IntValueAttribute(9022)]
        EsbstrWithdrwalUrl = 9022,
        [IntValueAttribute(9023)]
        EsbstrStatmentUrl = 9023,
        #endregion

        #region AepsMatmSmsCustomer
        [IntValueAttribute(745)]
        ESBSMSLimitCheck = 745,
        [IntValueAttribute(747)]
        ESBSearchansSendSMS = 747,
        #endregion
        [IntValueAttribute(618)]
        ESBUPISignedQR = 618,
        [IntValueAttribute(6096)]
        ESBOtpVerificationWithStage1Data = 6096,
        [IntValueAttribute(6097)]
        ESBMerchantLatLong = 6097,
        [IntValueAttribute(7000)]
        EsbFPUploadVkyc = 7000,
        [IntValueAttribute(7002)]
        VKYCGetAMLURL = 7002,
        [IntValueAttribute(6097)]
        EsbIntialFundingTxnEnq = 6097,
        [IntValueAttribute(7010)]
        EsbCCodeDMScalling = 7010,

        // Find customer with version esburl ID
        [IntValueAttribute(830)]
        registrationFindCustomerWithVersion = 830,
        [IntValueAttribute(831)]
        serviceRequestFindCustomerWithVersion = 831,
        [IntValueAttribute(832)]
        MBApplicationFindCustomerWithVersion = 832,
        [IntValueAttribute(833)]
        TransactionFindCustomerWithVersion = 833,
        [IntValueAttribute(834)]
        registrationSearchCustomerWithVersion = 834,
        [IntValueAttribute(835)]
        MBApplicationSearchCustomerWithVersion = 835,
        [IntValueAttribute(836)]
        ColaSearchCustomerWithVersion = 836,
        [IntValueAttribute(837)]
        SSOFindCustomerWithVersion = 837,
        [IntValueAttribute(838)]
        CallLogFindCustomerWithVersion = 838,
        [IntValueAttribute(840)]
        UPIServiceEsbFindCustomerWithVersion = 840,
        [IntValueAttribute(841)]
        LoginServiceEsbFindCustomerWithVersion = 841,
        [IntValueAttribute(853)]
        URLCsahinintent = 853,
        [IntValueAttribute(854)]
        GetCallcenterVPADetails = 854,
        [IntValueAttribute(855)]
        ESBVPABlocktime = 855,
        [IntValueAttribute(856)]
        ESBVPAunblock = 856,
        [IntValueAttribute(859)]
        FTDeleteVPA = 859,
        [IntValueAttribute(860)]
        ESBITRSRStatusUrl = 860,
        [IntValueAttribute(892)]
        ESBSearchWalkinWithLimitOrchestration = 892,
        [IntValueAttribute(893)]
        ESBAccountLimitWithRestrictionOrchestration = 893,
        [IntValueAttribute(915)]
        ESBCashinAdminUservalidation = 915,
        [IntValueAttribute(1010)]
        ESBFetchLICBillPaymentDetailsUrl = 1010,
        [IntValueAttribute(1011)]
        ESBLICBillPaymentChargesUrl = 1011,
        [IntValueAttribute(1012)]
        ESBLICBillPaymentTransactionUrl = 1012,

        #region "prepaid card"
        [IntValueAttribute(881)]
        EsbPrepaidFindCustomerUrl = 881,
        [IntValueAttribute(882)]
        EsbPrepaidHistoryUrl = 882,
        [IntValueAttribute(883)]
        EsbPrepaidRegistrationUrl = 883,
        [IntValueAttribute(884)]
        EsbPrepaidAddfundsUrl = 884,
        [IntValueAttribute(885)]
        EsbPrepaidCloseUrl = 885,
        [IntValueAttribute(886)]
        EsbPrepaidViewUrl = 886,
        [IntValueAttribute(887)]
        EsbPrepaidReplaceUrl = 887,
        [IntValueAttribute(888)]
        EsbPrepaidBlockUrl = 888,
        [IntValueAttribute(889)]
        EsbPrepaidUnblockUrl = 889,
        [IntValueAttribute(890)]
        EsbPrepaidResetPinUrl = 890,
        [IntValueAttribute(891)]
        EsbPrepaidlimitUrl = 891,
        [IntValueAttribute(892)]
        EsbEmailStatementforPrepaidURL = 892,
        [IntValueAttribute(893)]
        EsbPrepaidSendOtpUrl = 893,
        [IntValueAttribute(894)]
        EsbPrepaidPreferenceUrl = 894,
        [IntValueAttribute(895)]
        EsbPrepaidGetPhysicalUrl = 895,
        [IntValueAttribute(896)]
        EsbPrepaidDebitTransactionUrl = 896,
        [IntValueAttribute(897)]
        ESBFetchTransactionUrl = 897,
        [IntValueAttribute(898)]
        ESPrepaidCardStatusnUrl = 898,
        [IntValueAttribute(899)]
        EsbPrepaidGetlimitUrl = 899,
        #endregion


        #region "DigitalGold"
        [IntValueAttribute(2019)]
        ESBDGfetchBalance = 2019,
        [IntValueAttribute(2020)]
        EsbGoldPincodevalidation = 2020,
        [IntValueAttribute(2021)]
        EsbGoldRedeemDispatchStatus = 2021,
        [IntValueAttribute(2022)]
        EsbGoldRegistration = 2022,
        [IntValueAttribute(2023)]
        EsbGoldBuy = 2023,
        [IntValueAttribute(2024)]
        EsbGoldSell = 2024,
        [IntValueAttribute(2025)]
        EsbGoldProduct = 2025,
        [IntValueAttribute(2026)]
        EsbGoldInvoice = 2026,
        [IntValueAttribute(2027)]
        EsbGoldUpdateKyc = 2027,
        [IntValueAttribute(2030)]
        EsbGoldSellVerify = 2030,
        [IntValueAttribute(20269)]
        EsbGoldSellConfirm = 20269,
        [IntValueAttribute(2029)]
        EsbGoldBuyVerify = 2029,
        [IntValueAttribute(2032)]
        EsbGoldBuyConfirm = 2032,
        [IntValueAttribute(2031)]
        EsbRedeemDispatchStatusVerify = 2031,
        [IntValueAttribute(20343)]
        EsbRedeemDispatchStatusConfirm = 20343,
        [IntValueAttribute(2034)]
        EsbOrderStatus = 2034,
        [IntValueAttribute(2028)]
        EsbUserTxn = 2028,
        [IntValueAttribute(2036)]
        EsbVendorCallBack = 2036,
        #endregion
        [IntValueAttribute(780)]
        DigitalBankingGenericServiceUrl = 780,
        [IntValueAttribute(781)]
        EsbMFPostTransaction = 781,
        [IntValueAttribute(9033)]
        RepaymentBalenceenq = 9033,
        [IntValueAttribute(9034)]
        RepaymentTxnURL = 9034,
        [IntValueAttribute(9035)]
        strRepaynetEsbValidateTokenUrl = 9035,
        [IntValueAttribute(9036)]
        strRepaynetAuthenticationEsbUrl = 9036,
        [IntValueAttribute(9037)]
        strRepaymentLoginTokenEsbUrl = 9037,
        [IntValueAttribute(9038)]
        Repaymenttxnvalidate = 9038,

        #region "TransactionMethodId"
        [IntValueAttribute(104)]
        IMPSChargesMethodId = 104
        #endregion


    }
}
