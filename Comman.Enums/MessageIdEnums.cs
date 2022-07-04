using Utility.Attributes;

namespace Common.Enums
{
    public enum MessageTypeId
    {
        [IntValueAttribute(49)]
        LoginSuccess = 1,
        [IntValueAttribute(49)]
        LoginUnSuccess = 2,
        [IntValueAttribute(49)]
        Exception = 3,
        [IntValueAttribute(49)]
        CustomerAccountExists = 4,
        [IntValueAttribute(49)]
        CustomerAccountDoesNotExists = 5,
        [IntValueAttribute(49)]
        BeneficiaryDetailsFound = 6,
        [IntValueAttribute(49)]
        BeneficiaryDetailsNotFound = 7,
        [IntValueAttribute(49)]
        BeneficiaryAdded = 8,
        [IntValueAttribute(49)]
        BeneficiaryCouldNotBeAdded = 9,
        [IntValueAttribute(49)]
        IFSCDetailsFound = 10,
        [IntValueAttribute(49)]
        IFSCDetailsNotFound = 11,
        [IntValueAttribute(49)]
        BiometricVerificationSuccess = 12,
        [IntValueAttribute(49)]
        BiometricVerificationFailed = 13,
        [IntValueAttribute(49)]
        AccountToAccountFundTransferSuccess = 14,
        [IntValueAttribute(49)]
        AccountToAccountFundTransferFailed = 15,
        [IntValueAttribute(49)]
        IMPSFundTransferSuccess = 16,
        [IntValueAttribute(49)]
        IMPSFundTransferFailed = 17,
        [IntValueAttribute(49)]
        NEFTFundTransferSuccess = 18,
        [IntValueAttribute(49)]
        NEFTFundTransferFailed = 19,
        [IntValueAttribute(49)]
        RTGSFundTransferSuccess = 20,
        [IntValueAttribute(49)]
        RTGSFundTransferFailed = 21,
        [IntValueAttribute(49)]
        KYCExists = 22,
        [IntValueAttribute(49)]
        KYCDoesNotExists = 23,
        [IntValueAttribute(49)]
        CustomerDocumentsUploadedSuccessfully = 24,
        [IntValueAttribute(49)]
        CustomerDocumentsCouldNotbeUploadedSuccessfully = 25,
        [IntValueAttribute(49)]
        FingerPrintDetailsisSaved = 26,
        [IntValueAttribute(49)]
        FingerPrintDetailsisnotSaved = 27,
        [IntValueAttribute(49)]
        CustomerAccountNumberIsCreated = 28,
        [IntValueAttribute(49)]
        AccountOpeningCardLinkedSuccess = 361,
        [IntValueAttribute(49)]
        CustomerAccountNumberIsNotCreated = 29,
        [IntValueAttribute(49)]
        CashDepositSuccess = 30,
        [IntValueAttribute(49)]
        CashDepositFailed = 31,
        [IntValueAttribute(49)]
        CASAPLUSFundTransferSuccess = 731,
        [IntValueAttribute(49)]
        CASAPLUSFundTransferFailed = 732,
        [IntValueAttribute(49)]
        CASAPLUSViewBalanceSuccess = 733,
        [IntValueAttribute(49)]
        CASAPLUSViewBalanceFailed = 734,
        [IntValueAttribute(49)]
        CASAPLUSViewStatementSuccess = 808,
        [IntValueAttribute(49)]
        CASAPLUSViewStatementFailed = 809,
        [IntValueAttribute(49)]
        CashWithdrawSuccess = 32,
        [IntValueAttribute(49)]
        CashWithdrawFailed = 33,
        [IntValueAttribute(49)]
        OTPGeneratedSuccessfully = 50,
        [IntValueAttribute(49)]
        OTPGenerationFailed = 51,
        [IntValueAttribute(49)]
        OTPAlreadyUsed = 52,
        [IntValueAttribute(49)]
        OTPVerifiedSuccessfully = 53,
        [IntValueAttribute(49)]
        OTPVerificationFailed = 54,
        [IntValueAttribute(49)]
        OTPHasBeenExpired = 55,
        [IntValueAttribute(49)]
        SMSSentSuccessfully = 56,
        [IntValueAttribute(49)]
        SMSSendingFailed = 57,
        [IntValueAttribute(49)]
        InsertOTPSuccess = 58,
        [IntValueAttribute(49)]
        InsertOTPFailed = 59,
        [IntValueAttribute(49)]
        InsertSMSSuccess = 60,
        [IntValueAttribute(49)]
        InsertSMSFailed = 61,
        [IntValueAttribute(49)]
        ServerError = 64,
        [IntValueAttribute(65)]
        AuthenticateSuccess = 65,
        [IntValueAttribute(66)]
        AuthenticateUnSuccess = 66,
        [IntValueAttribute(49)]
        SessionExpired = 67,
        [IntValueAttribute(49)]
        NotificationSentSuccessfully = 68,
        [IntValueAttribute(49)]
        NotificationSentFailed = 69,
        [IntValueAttribute(49)]
        CustomerDetailsFound = 70,
        [IntValueAttribute(49)]
        CustomerDetailsNotFound = 71,
        [IntValueAttribute(49)]
        BeneficiaryDeleted = 72,
        [IntValueAttribute(49)]
        BeneficiaryCouldNotDeleted = 73,
        [IntValueAttribute(49)]
        EmailloadingSuccessful = 74,
        [IntValueAttribute(49)]
        EmailloadingFailed = 75,
        [IntValueAttribute(49)]
        CashCountSuccess = 76,
        [IntValueAttribute(49)]
        CashCountError = 77,
        [IntValueAttribute(49)]
        MiniStatementSuccessful = 78,
        [IntValueAttribute(49)]
        MiniStatementFailed = 79,
        [IntValueAttribute(49)]
        InterestCertificateFailed = 1011,
        [IntValueAttribute(49)]
        InterestCertificateSuccessful = 1012,
        [IntValueAttribute(49)]
        IFSCCodeSuccess = 80,
        [IntValueAttribute(49)]
        IFSCCodeError = 81,
        [IntValueAttribute(49)]
        InstaKitNumberSuccess = 82,
        [IntValueAttribute(49)]
        InstaKitNumberFailed = 83,
        [IntValueAttribute(49)]
        NSDLSuccess = 84,
        [IntValueAttribute(49)]
        NSDLFailed = 85,
        [IntValueAttribute(49)]
        FingerPrintMatchSucess = 86,
        [IntValueAttribute(49)]
        FingerPrintMatchFailed = 87,
        [IntValueAttribute(49)]
        AUADataFetchSucess = 88,
        [IntValueAttribute(49)]
        AUADataFetchFailed = 89,
        [IntValueAttribute(49)]
        UIDFoundSucess = 90,
        [IntValueAttribute(49)]
        UIDFoundFailed = 91,
        [IntValueAttribute(49)]
        LogoutSuccessful = 92,
        [IntValueAttribute(49)]
        LogoutFailed = 93,
        [IntValueAttribute(49)]
        NEFTTransactionTimingSuccess = 94,
        [IntValueAttribute(49)]
        NEFTTransactionTimingFailed = 95,
        [IntValueAttribute(49)]
        AuthContextDetailsSuccess = 96,
        [IntValueAttribute(49)]
        AuthContextDetailsFailed = 97,
        [IntValueAttribute(49)]
        UnableToGetEncryptionKey = 98,
        [IntValueAttribute(49)]
        TellerProofSuccess = 99,
        [IntValueAttribute(49)]
        TellerProofFailed = 100,
        [IntValueAttribute(49)]
        BranchProofSuccess = 102,
        [IntValueAttribute(49)]
        BranchProofFailed = 103,
        [IntValueAttribute(49)]
        AccountHistorySuccess = 104,
        [IntValueAttribute(49)]
        AccountHistoryFailed = 105,
        [IntValueAttribute(49)]
        CustomerUpdateSuccessfully = 106,
        [IntValueAttribute(49)]
        CustomerUpdateFailed = 107,
        [IntValueAttribute(49)]
        ChargesCheckSuccessfully = 108,
        [IntValueAttribute(49)]
        ChargesCheckFailed = 109,
        [IntValueAttribute(49)]
        PostTransactionSuccessfully = 110,
        [IntValueAttribute(49)]
        PostTransactionFailed = 111,
        [IntValueAttribute(49)]
        DeleteBeneficiarySuccessful = 112,
        [IntValueAttribute(49)]
        DeleteBeneficiaryFailed = 113,
        [IntValueAttribute(49)]
        PanValidationSuccess = 114,
        [IntValueAttribute(49)]
        PanValidationFailed = 115,
        [IntValueAttribute(49)]
        SetSMSCommunicationPreferenceSuccess = 901,
        [IntValueAttribute(49)]
        SetSMSCommunicationPreferenceFailed = 902,
        [IntValueAttribute(49)]
        GetCustomerPhotoSuccess = 116,
        [IntValueAttribute(49)]
        GetCustomerPhotoFailed = 117,
        [IntValueAttribute(49)]
        FpVerificationSuccess = 118,
        [IntValueAttribute(49)]
        FpVerificationFailed = 119,
        [IntValueAttribute(49)]
        UpdateCustomerPhotoSuccess = 120,
        [IntValueAttribute(49)]
        UpdateCustomerPhotoFailed = 121,
        [IntValueAttribute(49)]
        TokenValidationSuccess = 122,
        [IntValueAttribute(49)]
        TokenValidationFailed = 123,
        [IntValueAttribute(49)]
        AddBillerSuccesful = 124,
        [IntValueAttribute(49)]
        AddBillerFailed = 125,
        [IntValueAttribute(49)]
        RechargeQuerySuccessful = 126,
        [IntValueAttribute(49)]
        RechargeQueryFailed = 127,
        [IntValueAttribute(49)]
        ValidateRechargeSuccessful = 128,
        [IntValueAttribute(49)]
        ValidateRechargeFailed = 129,
        [IntValueAttribute(49)]
        PaymentandRechargeDetailsSourceDebitSuccessful = 130,
        [IntValueAttribute(49)]
        PaymentandRechargeDetailsSourceDebitFailed = 131,
        [IntValueAttribute(49)]
        DeleteBillersSuccessful = 132,
        [IntValueAttribute(49)]
        DeleteBillersFailed = 133,
        [IntValueAttribute(49)]
        ViewBillsSuccessful = 134,
        [IntValueAttribute(49)]
        ViewBillsFailed = 135,
        [IntValueAttribute(49)]
        PaymentOnlyDetailsSuccesful = 136,
        [IntValueAttribute(49)]
        PaymentOnlyDetailsFailed = 137,
        [IntValueAttribute(49)]
        ViewBillerAccountSuccessful = 138,
        [IntValueAttribute(49)]
        ViewBillerAccountFailed = 139,
        [IntValueAttribute(49)]
        ViewLastPaidBillsSuccessful = 140,
        [IntValueAttribute(49)]
        ViewLastPaidBillsFailed = 141,
        [IntValueAttribute(49)]
        CheckTransactionStatusSuccessful = 142,
        [IntValueAttribute(49)]
        CheckTransactionStatusFailed = 143,
        [IntValueAttribute(49)]
        BillerValidationsSuccessful = 144,
        [IntValueAttribute(49)]
        BillerValidationsFailed = 145,
        [IntValueAttribute(49)]
        SetAutoPaySuccesful = 146,
        [IntValueAttribute(49)]
        SetAutoPayFailed = 147,
        [IntValueAttribute(49)]
        ViewScheduledBillsSuccesful = 148,
        [IntValueAttribute(49)]
        ViewScheduledBillsFailed = 149,
        [IntValueAttribute(49)]
        Modify_DeleteAutoPaySuccessful = 150,
        [IntValueAttribute(49)]
        Modify_DeleteAutoPayFailed = 151,
        [IntValueAttribute(49)]
        StopScheduledTransactionSuccessful = 152,
        [IntValueAttribute(49)]
        StopScheduledTransactionFailed = 153,
        [IntValueAttribute(49)]
        BillFetchDetailsSuccesful = 154,
        [IntValueAttribute(49)]
        BillFetchDetailsFailed = 155,
        [IntValueAttribute(49)]
        FPTemplatenotfound = 156,
        [IntValueAttribute(49)]
        IMPSWalletAccountSuccess = 158,
        [IntValueAttribute(49)]
        IMPSWalletAccountFailed = 159,
        [IntValueAttribute(49)]
        PassbookUpdationSuccessful = 160,
        [IntValueAttribute(49)]
        PassbookUpdationFailed = 161,
        [IntValueAttribute(49)]
        AadhaarLPGSeedingSuccessful = 162,
        [IntValueAttribute(49)]
        AadhaarLPGSeedingFailed = 163,
        [IntValueAttribute(49)]
        NomineeAdditionSuccessful = 164,
        [IntValueAttribute(49)]
        NomineeAdditionFailed = 165,
        [IntValueAttribute(49)]
        NominationupadationSuccessful = 166,
        [IntValueAttribute(49)]
        NominationupadationFailed = 167,
        [IntValueAttribute(49)]
        DBTLSeedingSuccessful = 168,
        [IntValueAttribute(49)]
        DBTLSeedingFailed = 169,
        [IntValueAttribute(49)]
        RevisionDetailsSuccess = 170,
        [IntValueAttribute(49)]
        RevisionDetailsFailed = 171,
        [IntValueAttribute(49)]
        GetDMSdataSuccess = 172,
        [IntValueAttribute(49)]
        GetDMSdataFailed = 173,
        //Added by Vaibhav
        #region [Krazy Bee Loan]
        [IntValueAttribute(49)]
        KrazybeeDataInsertionSuccess = 700605,
        [IntValueAttribute(49)]
        KrazybeeDataInsertionFailed = 700606,
        [IntValueAttribute(49)]
        IIFlCustomerNotExists = 700607,
        [IntValueAttribute(49)]
        IIFlCustomerExists = 700608,
        #endregion

        #region [Digital Loan]
        [IntValueAttribute(49)]
        Loantokencreationfailed = 700615,
        [IntValueAttribute(49)]
        DocumentMasterfound = 700616,
        [IntValueAttribute(49)]
        DocumentMasterNotfound = 700617,
        [IntValueAttribute(49)]
        LoanRequestSubmittedSuccessfully = 700618,
        [IntValueAttribute(49)]
        LoanRequestFailed = 700619,
        [IntValueAttribute(49)]
        Lenderfielddetailsfound = 700620,
        [IntValueAttribute(49)]
        Lenderfielddetailsnotfound = 700621,
        [IntValueAttribute(49)]
        Loanstatusavailable = 700622,
        [IntValueAttribute(49)]
        Loanstatusnotavailable = 700623,
        [IntValueAttribute(49)]
        Lenderdetailsfound = 700624,
        [IntValueAttribute(49)]
        Lenderdetailsnotfound = 700625,
        [IntValueAttribute(49)]
        Eligible = 700630,
        [IntValueAttribute(49)]
        NotEligible = 700631,
        [IntValueAttribute(49)]
        LoanDetailsFound = 700632,
        [IntValueAttribute(49)]
        LoanDetailsNotFound = 700633,
        [IntValueAttribute(49)]
        WithdrawalSuccessfull = 700634,
        [IntValueAttribute(49)]
        WithdrawalFailed = 700635,
        [IntValueAttribute(49)]
        AccountStatementGenerate = 700636,
        [IntValueAttribute(49)]
        AccountStatementFailed = 700637,
        [IntValueAttribute(49)]
        RepaymentDone = 700638,
        [IntValueAttribute(49)]
        RepaymentFails = 700639,
        #endregion

        #region [Cleaver Tap Myprofile]
        [IntValueAttribute(49)]
        PreferredlanguageSelected = 700609,
        [IntValueAttribute(49)]
        PreferredlanguageNotAvailable = 700610,
        [IntValueAttribute(49)]
        PreferredlanguageSaved = 700611,
        [IntValueAttribute(49)]
        PreferredlanguageNotSaved = 700612,
        #endregion
        //
        [IntValueAttribute(49)]
        SimpleWalletCreationSuccess = 174,
        [IntValueAttribute(49)]
        SimpleWalletCreationUnSuccess = 175,
        [IntValueAttribute(49)]
        AccountRelationshipAddSuccess = 176,
        [IntValueAttribute(49)]
        AccountRelationshipAddFailed = 177,
        [IntValueAttribute(49)]
        AccountRelationshipDeleteSuccess = 178,
        [IntValueAttribute(49)]
        AccountRelationshipDeleteFailed = 179,
        [IntValueAttribute(49)]
        SearchDMSDetailsSuccess = 180,
        [IntValueAttribute(49)]
        SearchDMSDetailsFailed = 181,
        [IntValueAttribute(49)]
        CustomerDataUpdateSuccess = 182,
        [IntValueAttribute(49)]
        CustomerDataUpdateFailed = 183,
        [IntValueAttribute(49)]
        IMPSTransactionUpdateSuccess = 184,
        [IntValueAttribute(49)]
        IMPSTransactionUpdateFailed = 185,
        [IntValueAttribute(49)]
        UserAlreadyExist = 186,
        [IntValueAttribute(49)]
        CustomerDetailsSuccessful = 187,
        [IntValueAttribute(49)]
        CustomerDetailsFailed = 188,
        [IntValueAttribute(49)]
        AccountDetailsSuccessful = 189,
        [IntValueAttribute(49)]
        AccountDetailsFailed = 190,
        [IntValueAttribute(49)]
        EmailSendSuccessfully = 191,
        [IntValueAttribute(49)]
        EmailSendFailed = 192,
        [IntValueAttribute(49)]
        ServiceReqChargesSuccessful = 193,
        [IntValueAttribute(49)]
        ServiceReqChargesFailed = 194,
        [IntValueAttribute(49)]
        EsbOtpGenerationSuccessful = 197,
        [IntValueAttribute(49)]
        EsbOtpGenerationFailed = 198,
        [IntValueAttribute(49)]
        EsbOtpVerifySuccessful = 199,
        [IntValueAttribute(49)]
        EsbOtpVerifyFailed = 200,
        [IntValueAttribute(49)]
        EsbEsbSMSTemplateSuccessful = 201,
        [IntValueAttribute(49)]
        EsbEsbSMSTemplateFailed = 202,
        [IntValueAttribute(49)]
        OperatorandPlanDetailsFetchSuccessful = 203,
        [IntValueAttribute(49)]
        OperatorandPlanDetailsFetchFailed = 204,
        [IntValueAttribute(49)]
        MasterDataFound = 205,
        [IntValueAttribute(49)]
        MasterDataCouldNotFound = 206,
        [IntValueAttribute(49)]
        TransactionProfileDetailsSuccessful = 207,
        [IntValueAttribute(49)]
        TransactionProfileDetailsFailed = 208,
        [IntValueAttribute(49)]
        MasterVersionReturnSuccessFul = 209,
        [IntValueAttribute(49)]
        MasterVersionReturnFailed = 210,
        [IntValueAttribute(49)]
        MasterCacheResetSuccessful = 211,
        [IntValueAttribute(49)]
        MasterCacheResetfailed = 212,
        [IntValueAttribute(49)]
        GetGLAccountBalanceSuccess = 215,
        [IntValueAttribute(49)]
        GetGLAccountBalanceFailed = 216,
        [IntValueAttribute(49)]
        RemoveAccountRestrictionSuccess = 217,
        [IntValueAttribute(49)]
        RemoveAccountRestrictionFailed = 218,
        [IntValueAttribute(49)]
        GetTransactionAuthProfileSuccess = 219,
        [IntValueAttribute(49)]
        GetTransactionAuthProfileFailed = 220,
        [IntValueAttribute(49)]
        UserUnlockSuccess = 221,
        [IntValueAttribute(49)]
        UserUnlockFailed = 222,
        //UnBlockUser
        [IntValueAttribute(49)]
        UnblockAuthFailed = 800,
        [IntValueAttribute(49)]
        UnblockUserSuccess = 801,
        [IntValueAttribute(49)]
        UnblockUserFailed = 802,
        [IntValueAttribute(49)]
        UnblockUserAlreadyActive = 803,
        [IntValueAttribute(49)]
        UnblockUnabletoProcess = 804,
        [IntValueAttribute(49)]
        UnblockRequestError = 805,
        [IntValueAttribute(49)]
        UnblockUserFound = 806,
        [IntValueAttribute(49)]
        UnblockUserR1NotFound = 807,
        [IntValueAttribute(49)]
        UnblockUserPasswordChangedSuccess = 810,
        [IntValueAttribute(49)]
        UnblockUserMerchantDeviceNotAllowed = 815,
        [IntValueAttribute(49)]
        UnblockUserMerchantPANDoesnotMatch = 818,
        [IntValueAttribute(49)]
        UnblockUserMerchantDOBDoesnotMatch = 819,
        [IntValueAttribute(49)]
        UnblockUserMerchantDOBandPANDoesnotMatch = 820,
        [IntValueAttribute(49)]
        UnblockUserMerchantPANNotFound = 823,
        [IntValueAttribute(49)]
        UnblockUserMerchantContacthelpdesk = 824,
        [IntValueAttribute(49)]
        UnblockUserMerchantExceedsLoginLimit = 825,

        //End-UnBlockUser
        [IntValueAttribute(49)]
        setMobileBankingPINSuccess = 223,
        [IntValueAttribute(49)]
        setMobileBankingPINFailed = 224,
        [IntValueAttribute(49)]
        RegisterMBCustomerSuccess = 225,
        [IntValueAttribute(49)]
        RegisterMBCustomerFailed = 226,
        [IntValueAttribute(49)]
        changemobilebankingpinsuccess = 227,
        [IntValueAttribute(49)]
        changemobilebankingpinfailed = 228,
        [IntValueAttribute(49)]
        GetSecretQuestionSuccess = 229,
        [IntValueAttribute(49)]
        GetSecretQuestionFailed = 230,
        [IntValueAttribute(49)]
        UpdateSecretQuestionSuccess = 231,
        [IntValueAttribute(49)]
        UpdateSecretFailed = 232,
        [IntValueAttribute(49)]
        SetMerchantStatusSuccess = 641,
        [IntValueAttribute(49)]
        SetMerchantStatusFailed = 642,
        [IntValueAttribute(49)]
        GetMerchantStatusSuccess = 643,
        [IntValueAttribute(49)]
        GetMerchantStatusFailed = 644,
        [IntValueAttribute(49)]
        ValidUserSuccess = 235,
        [IntValueAttribute(49)]
        ValidUserFailed = 236,
        [IntValueAttribute(49)]
        EncryptedKeySuccess = 237,
        [IntValueAttribute(49)]
        EmcryptedKeyFailed = 238,
        [IntValueAttribute(49)]
        BillPaymentTransactionFailed = 252,
        [IntValueAttribute(49)]
        BillPaymentTransactionSuccess = 253,
        [IntValueAttribute(49)]
        BillPayTransactioninProcesskindlycheckministatement = 615,
        [IntValueAttribute(49)]
        RechargeTransactioninProcesskindlycheckministatement = 616,
        [IntValueAttribute(49)]
        ValidateUserSecretQuestionSuccess = 254,
        [IntValueAttribute(49)]
        ValidateUserSecretQuestionFailed = 255,
        [IntValueAttribute(49)]
        RechargeTransactionFailed = 266,
        [IntValueAttribute(49)]
        RechargeTransactionSuccess = 267,
        [IntValueAttribute(49)]
        PasswordResetSuccess = 270,
        [IntValueAttribute(49)]
        PasswordResetFailed = 271,
        [IntValueAttribute(49)]
        PasswordChangeSuccess = 272,
        [IntValueAttribute(49)]
        PasswordChangeFailed = 273,
        [IntValueAttribute(49)]
        SecretQuestionListSuccess = 274,
        [IntValueAttribute(49)]
        SecretQuestionListFailed = 275,
        [IntValueAttribute(49)]
        ExtraBeneficiaryDetailsFound = 213,
        [IntValueAttribute(49)]
        ExtraBeneficiaryDetailsNotFound = 214,
        [IntValueAttribute(49)]
        InvalidRequest = 215,
        [IntValueAttribute(49)]
        GLAccountBalanceDetailsFound = 256,
        [IntValueAttribute(49)]
        GLAccountBalanceDetailsNotFound = 257,

        //BillPaymentTransactionFailed = 252,
        //BillPaymentTransactionSuccess = 253,

        [IntValueAttribute(49)]
        InterBankTransferSuccess = 264,
        [IntValueAttribute(49)]
        InterBankTransferFailed = 265,

        //RechargeTransactionFailed = 266,
        //RechargeTransactionSuccess = 267,

        [IntValueAttribute(49)]
        RemitanceAccountOpeningSuccess = 268,
        [IntValueAttribute(49)]
        RemitanceAccountOpeningFailed = 269,
        [IntValueAttribute(49)]
        InsurancePremiumPaidSuccessful = 298,
        [IntValueAttribute(49)]
        InsurancePremiumPaidFailed = 299,
        [IntValueAttribute(49)]
        InsuranceClaimSuccessful = 613,
        [IntValueAttribute(49)]
        InsuranceClaimFailed = 614,
        [IntValueAttribute(49)]
        PrintFormatDataFound = 743,
        [IntValueAttribute(49)]
        PrintFormatDataNotFound = 744,
        [IntValueAttribute(49)]
        ResetPrintFormatMasterDataSuccess = 745,
        [IntValueAttribute(49)]
        ResetPrintFormatMasterDataFailed = 746,
        [IntValueAttribute(49)]
        GetExternalAccountDetailsSuccessful = 600,
        [IntValueAttribute(49)]
        GetExternalAccountDetailsFailed = 601,
        [IntValueAttribute(49)]
        BeneVerificationChargesSuccess = 300,
        [IntValueAttribute(49)]
        BeneVerificationChargesFailed = 301,
        [IntValueAttribute(49)]
        SequenceListReturnSuccessful = 278,
        [IntValueAttribute(49)]
        SequenceListReturnfailed = 279,
        [IntValueAttribute(49)]
        TabControlsReturnSuccessFul = 280,
        [IntValueAttribute(49)]
        TabControlsReturnFailed = 281,
        [IntValueAttribute(49)]
        CreateCustomerWalletSuccess = 282,
        [IntValueAttribute(49)]
        CreateCustomerWalletFailed = 283,
        [IntValueAttribute(49)]
        FindCustomerSuccess = 284,
        [IntValueAttribute(49)]
        FindCustomerFailed = 285,
        [IntValueAttribute(49)]
        AuthProfileSuccess = 286,
        [IntValueAttribute(49)]
        AuthProfileFailed = 287,
        [IntValueAttribute(49)]
        AuthenticateSuccesss = 288,
        [IntValueAttribute(49)]
        AuthenticateFailed = 289,
        [IntValueAttribute(49)]
        PublicKeySendSuccess = 290,
        [IntValueAttribute(49)]
        PublicKeySendFailed = 291,
        [IntValueAttribute(49)]
        MenuListByChannelSentSuccess = 292,
        [IntValueAttribute(49)]
        MenuListByChannelFailed = 293,
        [IntValueAttribute(49)]
        ProfileTypeTransByChannelSuccess = 294,
        [IntValueAttribute(49)]
        ProfileTypeTransByChannelFailed = 295,
        [IntValueAttribute(49)]
        ProductTransByChannelSuccess = 296,
        [IntValueAttribute(49)]
        ProductTransByChannelFailed = 297,
        [IntValueAttribute(49)]
        ProductWiseTransactionListSuccess = 302,
        [IntValueAttribute(49)]
        ProductWiseTransactionListFailed = 303,
        [IntValueAttribute(49)]
        BeneUpdateSuccess = 304,
        [IntValueAttribute(49)]
        BeneUpdateFailed = 305,
        [IntValueAttribute(49)]
        WalkInCustomerDetailsSuccess = 306,
        [IntValueAttribute(49)]
        WalkInCustomerDetailsFailed = 307,
        [IntValueAttribute(49)]
        WalkInTransactionDetailsSuccess = 308,
        [IntValueAttribute(49)]
        WalkInTransactionDetailsFailed = 309,
        [IntValueAttribute(49)]
        AccountLimitDetailsSuccess = 310,
        [IntValueAttribute(49)]
        AccountLimitDetailsFailed = 311,
        [IntValueAttribute(49)]
        SupervisiorDetailsSuccess = 312,
        [IntValueAttribute(49)]
        SupervisiorDetailsFailed = 313,
        [IntValueAttribute(49)]
        AccountRestrictionInfoSuccess = 314,
        [IntValueAttribute(49)]
        AccountRestrictionInfoFailed = 315,
        [IntValueAttribute(49)]
        AccountOpeningRequestDetailsSuccess = 362,
        [IntValueAttribute(49)]
        AccountOpeningRequestDetailsFailed = 363,
        [IntValueAttribute(49)]
        AccountOpeningEsignSuccess = 715,
        [IntValueAttribute(49)]
        AccountOpeningEsignFailed = 716,
        [IntValueAttribute(49)]
        AccountDetailsSuccess = 617,
        [IntValueAttribute(49)]
        AccountDetailsFail = 618,
        [IntValueAttribute(49)]
        DebitkitDetailsSuccess = 629,
        [IntValueAttribute(49)]
        DebitKitdetailsFailed = 630,
        [IntValueAttribute(49)]
        ServiceRequestCountSuccess = 633,
        [IntValueAttribute(49)]
        ServiceRequestCountFailed = 634,
        [IntValueAttribute(49)]
        LMSAccountBalHoldInfoSuccess = 377,
        [IntValueAttribute(49)]
        LMSAccountBalHoldInfoFailed = 378,
        [IntValueAttribute(49)]
        BeneVerificationSuccess = 316,
        [IntValueAttribute(49)]
        BeneVerificationFailed = 317,
        [IntValueAttribute(49)]
        UserDetailSuccess = 318,
        [IntValueAttribute(49)]
        UserDetailUnSuccess = 319,
        [IntValueAttribute(49)]
        ResetMenuCacheSuccessful = 320,
        [IntValueAttribute(49)]
        ResetMenuCacheFailed = 321,
        [IntValueAttribute(49)]
        ResetProfileSuccessful = 322,
        [IntValueAttribute(49)]
        ResetProfileFailed = 323,
        [IntValueAttribute(49)]
        FavouriteTransactionSuccessful = 324,
        [IntValueAttribute(49)]
        FavouriteTransactionFailed = 325,
        [IntValueAttribute(49)]
        GetAccountStatementSuccessful = 326,
        [IntValueAttribute(49)]
        GetAccountStatementFaliled = 327,
        [IntValueAttribute(49)]
        ManagementHealthAPIsuccessful = 328,
        [IntValueAttribute(49)]
        UpdateKitStatussuccessfull = 329,
        [IntValueAttribute(49)]
        UpdateKitStatusUnsuccessfull = 330,
        [IntValueAttribute(49)]
        WelcomeKITAcknowlegementStatusSuccess = 741,
        [IntValueAttribute(49)]
        WelcomeKITAcknowlegementStatusFailed = 742,
        [IntValueAttribute(49)]
        DMSGetAccountStatusSuccess = 821,
        [IntValueAttribute(49)]
        DMSGetAccountStatusFailed = 822,
        [IntValueAttribute(49)]
        DMSAdharVaultStatusSuccess = 836,
        [IntValueAttribute(49)]
        DMSAdharVaultStatusFailed = 837,
        [IntValueAttribute(49)]
        GetWorkingAddressSuccess = 842,
        [IntValueAttribute(49)]
        GetWorkingAddressFailed = 843,
        [IntValueAttribute(49)]
        GetForm60StatusSuccess = 844,
        [IntValueAttribute(49)]
        GetForm60StatusFailed = 845,
        [IntValueAttribute(49)]
        GetAadhaarLinkStatusSuccess = 846,
        [IntValueAttribute(49)]
        GetAadhaarLinkStatusFailed = 847,
        [IntValueAttribute(49)]
        GetAdharSeedingEnquirySuccess = 870,
        [IntValueAttribute(49)]
        GetAdharSeedingEnquiryFailed = 871,
        [IntValueAttribute(49)]
        GetDMSMobileDedupeSuccess = 872,
        [IntValueAttribute(49)]
        GetDMSMobileDedupeFailed = 873,
        [IntValueAttribute(49)]
        Branchreportsuccess = 331,
        [IntValueAttribute(49)]
        Branchreportfailed = 332,
        [IntValueAttribute(49)]
        Branchchannelreportsuccess = 333,
        [IntValueAttribute(49)]
        Branchchannelreportfailed = 334,
        [IntValueAttribute(49)]
        BranchProductreportsuccess = 335,
        [IntValueAttribute(49)]
        BranchProductreportfailed = 336,
        [IntValueAttribute(49)]
        BranchTranstypereportsuccess = 337,
        [IntValueAttribute(49)]
        BranchTranstypereportfailed = 338,
        [IntValueAttribute(49)]
        Channelreportsuccess = 339,
        [IntValueAttribute(49)]
        Channelreportfailed = 340,
        [IntValueAttribute(49)]
        ChannelProductreportsuccess = 341,
        [IntValueAttribute(49)]
        ChannelProductreportfailed = 342,
        [IntValueAttribute(49)]
        ChannelTranstypereportsuccess = 343,
        [IntValueAttribute(49)]
        ChannelTranstypereportfailed = 344,
        [IntValueAttribute(49)]
        Customerreportsuccess = 345,
        [IntValueAttribute(49)]
        Customerreportfailed = 346,
        [IntValueAttribute(49)]
        Productreportsuccess = 347,
        [IntValueAttribute(49)]
        Productreporfailed = 348,
        [IntValueAttribute(49)]
        Transtypereportsuccess = 349,
        [IntValueAttribute(49)]
        Transtypereportfailed = 350,
        [IntValueAttribute(49)]
        Userreportsuccess = 351,
        [IntValueAttribute(49)]
        Userreportfailed = 352,
        [IntValueAttribute(49)]
        UserProductreportsuccess = 353,
        [IntValueAttribute(49)]
        UserProductreportfailed = 354,
        [IntValueAttribute(49)]
        UserTranstypereportsuccess = 355,
        [IntValueAttribute(49)]
        UserTranstypereportfailed = 356,
        [IntValueAttribute(49)]
        TransListreportsuccess = 357,
        [IntValueAttribute(49)]
        TransListreportfailed = 358,
        [IntValueAttribute(49)]
        Ministatementreportsuccess = 359,
        [IntValueAttribute(49)]
        Ministatementreportfailed = 360,
        [IntValueAttribute(49)]
        UserWiseProductListSuccess = 361,
        [IntValueAttribute(49)]
        UserWiseProductListFailed = 362,
        [IntValueAttribute(49)]
        ServiceRequestStatusSuccess = 363,
        [IntValueAttribute(49)]
        ServiceRequestStatusFailed = 364,
        [IntValueAttribute(49)]
        CashCollectionVerificationSuccessful = 365,
        [IntValueAttribute(49)]
        CashCollectionVerificationFailed = 366,
        [IntValueAttribute(49)]
        CashCollectionTransactionSuccessful = 611,
        [IntValueAttribute(49)]
        CashCollectionTransactionFailed = 612,
        [IntValueAttribute(49)]
        CashCollectionAdhaarValidationSuccessful = 649,
        [IntValueAttribute(49)]
        CashCollectionAdhaarValidationFailed = 650,
        [IntValueAttribute(49)]
        SupervisorUserDetailsSuccess = 371,
        [IntValueAttribute(49)]
        SupervisorUserDetailsFailed = 372,
        [IntValueAttribute(49)]
        LockUserDetailsSuccess = 373,
        [IntValueAttribute(49)]
        LockUserDetailsFailed = 374,
        [IntValueAttribute(49)]
        UnLockUserDetailsSuccess = 375,
        [IntValueAttribute(49)]
        UnLockUserDetailsFailed = 376,
        [IntValueAttribute(49)]
        RemoveAccountRestrictSuccess = 377,
        [IntValueAttribute(49)]
        RemoveAccountRestrictFailed = 378,
        [IntValueAttribute(49)]
        KeyExchangedSuccessful = 379,
        [IntValueAttribute(49)]
        CardTransactionSuccessful = 380,
        [IntValueAttribute(49)]
        BalanceEnquirySuccessful = 381,
        [IntValueAttribute(49)]
        cardtransactionBalanceEnquiryFailed = 604,
        [IntValueAttribute(49)]
        CardTransactioncashwithdrawalFailed = 605,
        [IntValueAttribute(49)]
        KeyExchangedFailed = 606,
        [IntValueAttribute(49)]
        SetCardPinSuccessfull = 382,
        [IntValueAttribute(49)]
        Invaliduserid = 912,
        [IntValueAttribute(49)]
        InvalidTerminal = 913,
        [IntValueAttribute(49)]
        Transactionfailed = 914,
        [IntValueAttribute(49)]
        verifyTPINSuccess = 403,
        [IntValueAttribute(49)]
        verifyTPINFailed = 404,
        [IntValueAttribute(49)]
        GetclosureAmountSuccess = 405,
        [IntValueAttribute(49)]
        GetclosureAmountFailed = 406,
        [IntValueAttribute(49)]
        EJLogsSuccess = 700540,
        [IntValueAttribute(49)]
        EJLogsFailure = 700541,

        [IntValueAttribute(49)]
        Croselfaild = 747,
        [IntValueAttribute(49)]
        Croselsucess = 748,
        [IntValueAttribute(49)]
        AccountRistrictionSuccess = 700615,
        [IntValueAttribute(49)]
        AccountRistrictionFailed = 700616,
        // Customer Grievance Data Get mesages
        [IntValueAttribute(49)]
        CustomerGrievanceDataGetFailed = 603,
        [IntValueAttribute(49)]
        CustomerGrievanceDataGetSuccessful = 602,
        [IntValueAttribute(49)]
        TrackSuryesSuccess = 635,
        [IntValueAttribute(49)]
        TrackSurveysFailed = 636,
        [IntValueAttribute(49)]
        AccountCheckSuccess = 637,
        [IntValueAttribute(49)]
        AccountCheckFailed = 638,
        [IntValueAttribute(49)]
        DMSChequeIssuanceValidationSuccess = 811,
        [IntValueAttribute(49)]
        DMSChequeIssuanceValidationFailed = 812,
        [IntValueAttribute(49)]
        DMSChequeIssuanceAPISuccess = 813,
        [IntValueAttribute(49)]
        DMSChequeIssuanceAPIFailed = 814,
        [IntValueAttribute(49)]
        DMSKitRequestSuccess = 697,
        [IntValueAttribute(49)]
        DMSKitRequestFailed = 698,
        [IntValueAttribute(49)]
        DMSKitStatusUpdatedSuccess = 647,
        [IntValueAttribute(49)]
        DMSKitStatusUpdatedFailed = 648,
        [IntValueAttribute(49)]
        DMSKitSearchSuccess = 701,
        [IntValueAttribute(49)]
        DMSKitSearchFailed = 702,
        [IntValueAttribute(49)]
        UpdateSISuccess = 651,
        [IntValueAttribute(49)]
        UpdateSIFailed = 652,
        [IntValueAttribute(49)]
        ViewSIListSuccess = 653,
        [IntValueAttribute(49)]
        ViewSIListFailed = 654,
        [IntValueAttribute(49)]
        CreateSIRequestSuccess = 655,
        [IntValueAttribute(49)]
        CreateSIRequestFailed = 656,
        [IntValueAttribute(49)]
        DeleteSISuccess = 657,
        [IntValueAttribute(49)]
        DeleteSIFailed = 658,
        [IntValueAttribute(49)]
        TagDetailsSuccess = 707,
        [IntValueAttribute(49)]
        TagDetailFailed = 708,
        [IntValueAttribute(49)]
        TagDetailsGetSuccess = 709,
        [IntValueAttribute(49)]
        TagDetailsGetFailed = 710,
        [IntValueAttribute(49)]
        IFTFileApprovedSuccess = 717,
        [IntValueAttribute(49)]
        IFTFileApprovedFailed = 718,
        [IntValueAttribute(49)]
        GetFileDetailsSuccess = 719,
        [IntValueAttribute(49)]
        GetFileDetailsFailed = 720,
        [IntValueAttribute(49)]
        GetCheckerDashboardDataSuccess = 747,
        [IntValueAttribute(49)]
        GetCheckerDashboardDataFailed = 748,
        [IntValueAttribute(49)]
        GetApproverDashboardDataSuccess = 749,
        [IntValueAttribute(49)]
        GetApproverDashboardDataFailed = 750,

        //DMT PPI Transaction Messages
        [IntValueAttribute(49)]
        SearchWalkingCustomersSuccess = 367,
        [IntValueAttribute(49)]
        WalkinCustomerLimitSuccess = 368,
        [IntValueAttribute(49)]
        WalkinDMTImpsNeftSuccess = 430,
        [IntValueAttribute(49)]
        SearchWalkingCustomersFailed = 370,
        [IntValueAttribute(49)]
        WalkinCustomerLimitFailed = 371,
        [IntValueAttribute(49)]
        WalkinDMTImpsNeftFailed = 431,

        //Lending Acc
        [IntValueAttribute(49)]
        HHVDownloadSuccess = 434,
        [IntValueAttribute(49)]
        HHVDownloadFailed = 435,
        [IntValueAttribute(49)]
        CGTUploadSuccess = 436,
        [IntValueAttribute(49)]
        CGTUploadFailed = 437,
        [IntValueAttribute(49)]
        RCGTUploadSuccess = 438,
        [IntValueAttribute(49)]
        RCGTUploadFailed = 439,
        [IntValueAttribute(49)]
        SaralHHVUploadSuccess = 440,
        [IntValueAttribute(49)]
        SaralHHVUploadfailed = 441,
        [IntValueAttribute(49)]
        LUCSolarDownloadSuccess = 442,
        [IntValueAttribute(49)]
        LUCSolarDownloadFailed = 443,
        [IntValueAttribute(49)]
        LUCSolarUploadSuccess = 444,
        [IntValueAttribute(49)]
        LUCSolarUploadfailed = 445,
        [IntValueAttribute(49)]
        HolidayDemandDownloadSuccess = 446,
        [IntValueAttribute(49)]
        HolidayDemandDownloadFailed = 447,
        [IntValueAttribute(49)]
        MaturityDemandDownloadSuccess = 448,
        [IntValueAttribute(49)]
        MaturityDemandDownloadFailed = 449,
        [IntValueAttribute(49)]
        RegularDemandDownloadSuccess = 450,
        [IntValueAttribute(49)]
        RegularDemandFailed = 451,
        [IntValueAttribute(49)]
        GroupCenterAttendanceSuccess = 452,
        [IntValueAttribute(49)]
        GroupCenterAttendanceFailed = 453,
        [IntValueAttribute(49)]
        LoanTxnDataSuccess = 454,
        [IntValueAttribute(49)]
        LoanTxnDataFailed = 456,
        [IntValueAttribute(49)]
        GTRDownLoadwebServiceSuccess = 457,
        [IntValueAttribute(49)]
        GTRDownLoadwebServiceFailed = 458,
        [IntValueAttribute(49)]
        RECGTDownloadwebServiceSuccess = 459,
        [IntValueAttribute(49)]
        RECGTDownloadwebServiceFailed = 460,
        [IntValueAttribute(49)]
        HHVDownLoadwebServiceSuccess = 461,
        [IntValueAttribute(49)]
        HHVDownLoadwebServiceFailed = 462,
        [IntValueAttribute(49)]
        GRTUploadDataSuccess = 471,
        [IntValueAttribute(49)]
        GRTUploadDataFailed = 472,
        [IntValueAttribute(49)]
        CreditinquiryServiceSuccess = 473,
        [IntValueAttribute(49)]
        CreditinquiryServiceFailed = 474,
        [IntValueAttribute(49)]
        AdvanceNForeClosureSuccess = 475,
        [IntValueAttribute(49)]
        AdvanceNForeClosureFailed = 476,
        [IntValueAttribute(49)]
        ESBCustomSearchSuccess = 477,
        [IntValueAttribute(49)]
        ESBCustomSearchFailed = 478,
        [IntValueAttribute(49)]
        GetCenterGroupDataSuccess = 479,
        [IntValueAttribute(49)]
        GetCenterGroupDataFailed = 480,
        [IntValueAttribute(49)]
        DisbursementCustomersDataSuccess = 481,
        [IntValueAttribute(49)]
        DisbursementCustomersDataFailed = 482,
        [IntValueAttribute(49)]
        GetEnrollmentDetailSuccess = 483,
        [IntValueAttribute(49)]
        GetEnrollmentDetailFailed = 484,
        [IntValueAttribute(49)]
        PostcustomerDisbursementSuccess = 485,
        [IntValueAttribute(49)]
        PostcustomerDisbursementFailed = 486,
        [IntValueAttribute(49)]
        Esb25LegTransactionRepaySuccess = 487,
        [IntValueAttribute(49)]
        Esb25LegTransactionRepayFailed = 488,
        [IntValueAttribute(49)]
        EsbHOApprovalSuccess = 489,
        [IntValueAttribute(49)]
        EsbHOApprovalFailed = 490,
        [IntValueAttribute(49)]
        EsbProbableCenterDownloadSuccess = 491,
        [IntValueAttribute(49)]
        EsbProbableCenterDownloadFailed = 492,
        [IntValueAttribute(49)]
        EsbAdvanceAndForeClosureSuccess = 515,
        [IntValueAttribute(49)]
        EsbAdvanceAndForeClosureFailed = 516,
        [IntValueAttribute(49)]
        EsbTransactionUpdateHoverSuccess = 517,
        [IntValueAttribute(49)]
        EsbTransactionUpdateHoverFailed = 518,
        [IntValueAttribute(49)]
        EsbTransactionRepaymentHoverSuccess = 519,
        [IntValueAttribute(49)]
        EsbTransactionRepaymentHoverFailed = 520,
        [IntValueAttribute(49)]
        EsbEODCompletionSuccess = 521,
        [IntValueAttribute(49)]
        EsbEODCompletionFailed = 522,
        [IntValueAttribute(49)]
        CardStatusUpdateSuscess = 509,
        [IntValueAttribute(49)]
        CardStatusUpdateFailed = 510,
        [IntValueAttribute(49)]
        CardIssuanceSuccess = 511,
        [IntValueAttribute(49)]
        CardIssuanceFailed = 512,
        [IntValueAttribute(49)]
        JayamMMiniStmtSuccess = 639,
        [IntValueAttribute(49)]
        JayamMiniStmtFailed = 640,
        [IntValueAttribute(49)]
        RivigoDisbursementSuccess = 645,
        [IntValueAttribute(49)]
        RivigoDisbursementFailed = 646,
        [IntValueAttribute(49)]
        UserSurveySuccess = 659,
        [IntValueAttribute(49)]
        UserSurveyFailed = 660,
        [IntValueAttribute(49)]
        JayamEnrollmentAccountOpeningSuccess = 665,
        [IntValueAttribute(49)]
        JayamEnrollmentAccountOpeningFailed = 666,

        #region Fast Tag
        [IntValueAttribute(49)]
        FasttagVehicleregSucessful = 669,
        [IntValueAttribute(49)]
        FasttagVehicleregFailed = 670,
        [IntValueAttribute(49)]
        FasttagregistrationdetailsFound = 671,
        [IntValueAttribute(49)]
        FasttagregistrationdetailsnotFound = 673,

        [IntValueAttribute(49)]
        FastagBarcodeMappingSuccessful = 8012,
        [IntValueAttribute(49)]
        FastagBarcodeMappingFailed = 8013,
        [IntValueAttribute(49)]
        registeredVehicleStatusSuccessful = 8014,
        [IntValueAttribute(49)]
        registeredVehicleStatusFailed = 8015,
        [IntValueAttribute(49)]
        BpayPrefilledVehicleDetailssuccess = 8016,
        [IntValueAttribute(49)]
        BpayPrefilledVehicleDetailsFailed = 8017,
        [IntValueAttribute(49)]
        BpayRegistrationDeletionSucessful = 8018,
        [IntValueAttribute(49)]
        BpayRegistrationDeletionfailed = 8019,



        [IntValueAttribute(49)]
        VehicleTagIssuranceSuccessful = 675,
        [IntValueAttribute(49)]
        VehicleTagIssuranceFailed = 676,
        [IntValueAttribute(49)]
        VehiclePostTransactionSuccessful = 674,
        [IntValueAttribute(49)]
        VehiclePostTransactionFailed = 672,
        [IntValueAttribute(49)]
        VehicleVerificationCodeSuccessful = 679,
        [IntValueAttribute(49)]
        VehicleVarificationCodeFailed = 680,
        [IntValueAttribute(49)]
        VerificationCodeSendSucessfully = 681,
        [IntValueAttribute(49)]
        VerificationCodeSendFailed = 682,
        [IntValueAttribute(49)]
        TagblockSucessfully = 685,
        [IntValueAttribute(49)]
        TagblockFailed = 686,
        [IntValueAttribute(49)]
        TagUnblockSucessfully = 687,
        [IntValueAttribute(49)]
        TagUnblockFailed = 688,
        [IntValueAttribute(49)]
        DMSTagVerificationSuccessful = 689,
        [IntValueAttribute(49)]
        DMSTagVerificationFailed = 690,
        [IntValueAttribute(49)]
        ExceptionAmountSuccessful = 691,
        [IntValueAttribute(49)]
        ExceptionAmountFailed = 692,
        [IntValueAttribute(49)]
        TagCloseSucessful = 693,
        [IntValueAttribute(49)]
        TagCloseFailed = 694,
        [IntValueAttribute(49)]
        TagReissuanceSucessful = 699,
        [IntValueAttribute(49)]
        TagReissuanceFailed = 700,
        [IntValueAttribute(49)]
        GetTransactionDetailsSuccessful = 711,
        [IntValueAttribute(49)]
        GetTransactionDetailsFailed = 712,
        [IntValueAttribute(49)]
        UpdateCBSStatusSuccess = 713,
        [IntValueAttribute(49)]
        UpdateCBSStatusFailed = 714,
        [IntValueAttribute(49)]
        FasttaInvalidRequest = 1371,
        [IntValueAttribute(49)]
        FasttaInvalidVehicleDetails = 1372,
        [IntValueAttribute(49)]
        FasttagWalletisalreadyOpen = 1373,
        [IntValueAttribute(49)]
        Fasttagcustcustomeraccountdetailfailed = 1374,
        [IntValueAttribute(49)]
        Fasttagvehiclisblacklist = 1375,
        [IntValueAttribute(49)]
        FasttagUnabletoconnectremotserver = 1376,
        [IntValueAttribute(49)]
        FasttagMinistatment = 1377,
        [IntValueAttribute(49)]
        FasttagVehiclealredyregister = 1378,
        [IntValueAttribute(49)]
        FasttagVehiclealnotregister = 1379,
        [IntValueAttribute(49)]
        FasttagUPADetailFound = 1380,
        [IntValueAttribute(49)]
        FasttagUPADetailnotFound = 1381,
        [IntValueAttribute(49)]
        FasttagDetailnotFound = 1382,
        [IntValueAttribute(49)]
        FasttagServernotresponding = 1383,
        [IntValueAttribute(49)]
        Fasttagupaaccnoupdatesuccess = 1384,
        [IntValueAttribute(49)]
        Fasttagupaaccnoupdatefailed = 1385,
        [IntValueAttribute(49)]
        Fasttagvirtualaddnotfound = 1386,
        [IntValueAttribute(49)]
        FasttagSuccess = 1387,
        [IntValueAttribute(49)]
        FasttagFailed = 1388,
        [IntValueAttribute(49)]
        FasttagRecordnotfound = 1389,
        [IntValueAttribute(49)]
        FasttagVehicletypeupdatesucessfully = 1390,
        [IntValueAttribute(49)]
        FasttagVehicletypeupdatefailed = 1391,
        [IntValueAttribute(49)]
        FasttagOTPverifyfailed = 1393,
        [IntValueAttribute(49)]
        FasttagFPverifyfailed = 1394,
        [IntValueAttribute(49)]
        Fasttagotpexpired = 1395,
        [IntValueAttribute(49)]
        Fasttagverifycodesucess = 1396,
        [IntValueAttribute(49)]
        Fasttagverifycodefailed = 1397,
        [IntValueAttribute(49)]
        Fasttaginternalservererror = 1398,
        [IntValueAttribute(49)]
        Fasttagverifycodesucessti = 1399,
        [IntValueAttribute(49)]
        Fasttagverifycodefailedti = 1400,


        #endregion

        [IntValueAttribute(49)]
        GetIINMasterDataSuccess = 735,
        [IntValueAttribute(49)]
        GetIINMasterDataFailed = 736,
        [IntValueAttribute(49)]
        ResetIINMasterDataSuccess = 737,
        [IntValueAttribute(49)]
        ResetIINMasterDataFailed = 738,

        #region CashProcess message
        [IntValueAttribute(49)]
        CashProcessUserDetailsSuccess = 407,
        [IntValueAttribute(49)]
        CashProcessUserDetailsFailed = 408,
        [IntValueAttribute(49)]
        CashProcessVaultDetailsSuccess = 409,
        [IntValueAttribute(49)]
        CashProcessVaultDetailsFailed = 410,
        [IntValueAttribute(49)]
        CashProcessVaultBalanceSuccess = 413,
        [IntValueAttribute(49)]
        CashProcessVaultBalanceFailed = 414,
        [IntValueAttribute(49)]
        EodProcessUserdetailsSuccess = 625,
        [IntValueAttribute(49)]
        EodUserDetailsFailed = 626,
        [IntValueAttribute(49)]
        EodProcessTransactionSuccess = 627,
        [IntValueAttribute(49)]
        EodProcessTransactionFailed = 628,
        [IntValueAttribute(49)]
        EodBranchcloseProcessSuccess = 631,
        [IntValueAttribute(49)]
        EodBranchcloseProcessFailed = 632,
        [IntValueAttribute(49)]
        EodUserDetailsfailed = 918,
        [IntValueAttribute(49)]
        CBSPostingGetUserDtailsSuccess = 725,
        [IntValueAttribute(49)]
        CBSPostingGetUserDtailsFailed = 726,
        [IntValueAttribute(49)]
        CBSPostTransactionSuccess = 727,
        [IntValueAttribute(49)]
        CBSPostTransactionFailed = 728,
        [IntValueAttribute(49)]
        DMSTrackRevisionSuccess = 729,
        [IntValueAttribute(49)]
        DMSTrackRevisionFailed = 730,

        #endregion

        #region Reversal Transaction
        [IntValueAttribute(49)]
        ReversalTransactionSuccess = 411,
        [IntValueAttribute(49)]
        ReversalTransactionFailed = 412,
        #endregion

        #region Bucket
        [IntValueAttribute(49)]
        UpdateBucketBalanceSuccess = 415,
        [IntValueAttribute(49)]
        UpdateBucketBalanceFailed = 416,
        #endregion

        #region AEPS transaction
        [IntValueAttribute(49)]
        AEPStransactionSuccess = 417,
        [IntValueAttribute(49)]
        AEPSTransactionFailed = 418,
        [IntValueAttribute(49)]
        AEPSBalanceEnquirySuccess = 424,
        [IntValueAttribute(49)]
        AEPSBalanceEnquiryFailed = 427,

        #endregion

        #region Petty Transaction
        [IntValueAttribute(49)]
        PettyCashDepositSuccess = 419,
        [IntValueAttribute(49)]
        PettyCashDepositFailed = 420,
        [IntValueAttribute(49)]
        PettyCashWithdrawSuccess = 421,
        [IntValueAttribute(49)]
        PettyCashWithdrawFailed = 422,
        [IntValueAttribute(49)]
        PettyGlBalanceSuccess = 423,
        [IntValueAttribute(49)]
        PettyGlBalanceFailed = 426,
        [IntValueAttribute(49)]
        PettyLimitexpense = 917,
        #endregion

        #region Reversal Transaction
        [IntValueAttribute(49)]
        CashOutTransactionSuccess = 428,
        [IntValueAttribute(49)]
        CashOutTransactionFailed = 429,
        #endregion

        #region Maker Checker Message
        [IntValueAttribute(49)]
        GetMakerSuccess = 493,
        [IntValueAttribute(49)]
        GetMakerFailed = 494,
        [IntValueAttribute(49)]
        GetCheckerSuccess = 495,
        [IntValueAttribute(49)]
        GetCheckerFailed = 496,
        [IntValueAttribute(49)]
        MakerPostSuccess = 497,
        [IntValueAttribute(49)]
        MakerPostFailed = 498,
        [IntValueAttribute(49)]
        MakerCancelSuccess = 499,
        [IntValueAttribute(49)]
        MakerCancelFailed = 500,
        [IntValueAttribute(49)]
        CheckerApprovedSuccess = 501,
        [IntValueAttribute(49)]
        CheckerApprovedFailed = 502,
        [IntValueAttribute(49)]
        CheckerRejectSuccess = 503,
        [IntValueAttribute(49)]
        CheckerRejectFailed = 504,
        #endregion

        #region IMPS/NEFT
        [IntValueAttribute(49)]
        IMPSTransactionSuccess = 607,
        [IntValueAttribute(49)]
        IMPSTransactionFailed = 608,
        [IntValueAttribute(49)]
        NEFTTransactionSuccess = 609,
        [IntValueAttribute(49)]
        NEFTTranscationFailed = 610,
        #endregion

        #region RTGS
        [IntValueAttribute(49)]
        RTGSChargesSuccess = 505,
        [IntValueAttribute(49)]
        RTGSChargesFailed = 506,
        [IntValueAttribute(49)]
        RTGSTransactionSuccess = 507,
        [IntValueAttribute(49)]
        RTGSTransactionFailed = 508,
        #endregion RTGS

        #region CDM
        [IntValueAttribute(49)]
        CDMVerificationFailed = 622,
        [IntValueAttribute(49)]
        CDMTransactionFailed = 620,

        #endregion

        #region Shopkeeper Policy Insurance
        [IntValueAttribute(49)]
        IPRUShubrakshaFetchDetailsFailed = 739,
        [IntValueAttribute(49)]
        IPRUShubrakshaFetchDetailsSuccessfully = 740,
        #endregion

        #region Shopkeeper Policy Insurance
        [IntValueAttribute(49)]
        ShopkeeperPolicyFetchDetailsSuccessfully = 661,
        [IntValueAttribute(49)]
        ShopkeeperPolicyFetchDetailsFailed = 662,
        [IntValueAttribute(49)]
        ShopkeeperPolicyUpdateDetailsSuccessfully = 663,
        [IntValueAttribute(49)]
        ShopkeeperPolicyUpdateDetailsFailed = 664,

        #endregion

        #region Hospicash Policy Insurance
        [IntValueAttribute(49)]
        HospicashPolicyFetchDetailsSuccessfully = 667,
        [IntValueAttribute(49)]
        HospicashPolicyFetchDetailsFailed = 668,
        [IntValueAttribute(49)]
        HospicashPolicyFetchUHIDStatusDetailsSuccessfully = 677,
        [IntValueAttribute(49)]
        HospicashPolicyFetchUHIDStatusDetailsFailed = 678,

        #endregion

        #region Lombard Two Wheeler
        [IntValueAttribute(49)]
        TWMasterDetailsFetchSuccessfully = 721,
        [IntValueAttribute(49)]
        TWMasterDetailsFetchFailed = 722,
        [IntValueAttribute(49)]
        TWQuoteGenerationSuccessfully = 723,
        [IntValueAttribute(49)]
        TWQuoteGenerationFailed = 724,

        #endregion

        #region Last Action Lead Form
        [IntValueAttribute(49)]
        LastActionLeadFormSuccess = 683,
        [IntValueAttribute(49)]
        LastActionLeadFormFailed = 684,

        #endregion

        [IntValueAttribute(49)]
        CIFKYCDetailsSuccess = 695,
        [IntValueAttribute(49)]
        CIFKYCDetailsFailed = 696,
        [IntValueAttribute(49)]
        SearchAgentSuccess = 703,
        [IntValueAttribute(49)]
        SearchAgentFailed = 704,
        [IntValueAttribute(49)]
        UpdateAgentSuccess = 705,
        [IntValueAttribute(49)]
        UpdateAgentFailed = 706,
        //Max Id (706)
        #region RMF
        [IntValueAttribute(49)]
        RMFFolioFailed = 700532,
        [IntValueAttribute(49)]
        RMFFolioSuccess = 700533,
        [IntValueAttribute(49)]
        RMFTxnSuccess = 700534,
        [IntValueAttribute(49)]
        RMFTxnFailed = 700535,
        [IntValueAttribute(49)]
        RMFSchemeDetailsSuccess = 700536,
        [IntValueAttribute(49)]
        RMFSchemeDetailsFailed = 700537,
        [IntValueAttribute(49)]
        RMFRedemptionSuccess = 700538,
        [IntValueAttribute(49)]
        RMFRedemptionFailed = 700539,
        #endregion RMF

        [IntValueAttribute(49)]
        GLZeroizationSuccess = 816,
        [IntValueAttribute(49)]
        GLZeroizationFailed = 817,
        [IntValueAttribute(49)]
        TransactionReporst_StatementSRTaken = 826,
        [IntValueAttribute(49)]
        TransactionReporst_StatementSRUnabletoProcess = 827,
        [IntValueAttribute(49)]
        TransactionReporst_StatementSREmailVerifyLinkSent = 828,
        [IntValueAttribute(49)]
        TransactionReporst_StatementSREmailVerifyLinkSentFailed = 829,
        [IntValueAttribute(49)]
        TransactionReporst_StatementSREmailUpdationFailed = 830,
        [IntValueAttribute(49)]
        TransactionReporst_StatementSREmailNotUpdated = 831,
        [IntValueAttribute(49)]
        TransactionReporst_StatementSREmailVerified = 832,
        [IntValueAttribute(49)]
        TransactionReporst_StatementSREmailVPending = 833,
        [IntValueAttribute(49)]
        TransactionReporst_StatementSREmailUpdatedSuccess = 834,
        [IntValueAttribute(49)]
        TransactionReporst_StatementSREmailVerifyLinkExpired = 835,
        [IntValueAttribute(49)]
        TransactionReporst_StatementSREmailAlredyVerified = 838,
        [IntValueAttribute(49)]
        TransactionReporst_StatementSRInvalid = 839,


        #region "Cashin bank"
        [IntValueAttribute(49)]
        Cashinbanklocationfound = 8007,
        [IntValueAttribute(49)]
        Cashinbanklocationnotfound = 8008,
        [IntValueAttribute(49)]
        CashinbankImagefound = 8009,
        [IntValueAttribute(49)]
        CashinbankImagenotfound = 8010,
        [IntValueAttribute(49)]
        CashinbankInvalidRequest = 8011,

        #endregion

        #region "Digital Passbook"
        [IntValueAttribute(49)]
        DigitalPassbookSuccess = 700542,
        [IntValueAttribute(49)]
        DigitalPassbookFailed = 700543,
        [IntValueAttribute(49)]
        DigitalPassbookPDFFailed = 700544,
        #endregion

        #region "Sms Details"
        [IntValueAttribute(49)]
        SmsDetailskSuccess = 800702,
        [IntValueAttribute(49)]
        SmsDetailsFailed = 800703,
        #endregion

        #region "Suryoday Account Close"
        [IntValueAttribute(49)]
        SuryodayAcnCloseSuccess = 840,
        [IntValueAttribute(49)]
        SuryodayAcnCloseFail = 841,
        #endregion

        #region "Cash in Match data"
        [IntValueAttribute(49)]
        CashInInsertBankStnmtSuccess = 848,
        [IntValueAttribute(49)]
        CashInInsertBankStnmtFailuer = 849,
        [IntValueAttribute(49)]
        CashInMatchBankStnmtSuccess = 850,
        [IntValueAttribute(49)]
        CashInMatchBankStnmtFailuer = 851,
        [IntValueAttribute(49)]
        CashInUpdateBankStnmtSuccess = 852,
        [IntValueAttribute(49)]
        CashInUpdateBankStnmtFailuer = 853,
        [IntValueAttribute(49)]
        CashInViewBankStnmtSuccess = 854,
        [IntValueAttribute(49)]
        CashInBankStnmtFileFailuer = 855,
        [IntValueAttribute(49)]
        CashInBankStnmtMatchBalanceFailuer = 856,

        #endregion

        #region ReferalLoan
        [IntValueAttribute(49)]
        ReferalLoanVerificationSuccess = 857,
        [IntValueAttribute(49)]
        ReferalLoanVerificationFailed = 858,

        #endregion

        #region merchant payouts
        [IntValueAttribute(49)]
        GetPayoutdata = 857,
        [IntValueAttribute(49)]
        GetPayoutdataFailure = 858,
        #endregion

        #region self declared kits
        [IntValueAttribute(49)]
        GetSelfdeclaredkitdata = 859,
        [IntValueAttribute(49)]
        GetSelfdeclaredkitdataFailure = 860,
        [IntValueAttribute(49)]
        Selfdeclaredkitsave = 861,
        [IntValueAttribute(49)]
        SelfdeclaredkitsaveFailure = 862,
        [IntValueAttribute(49)]
        GetKitdataapproval = 863,
        [IntValueAttribute(49)]
        GetKitdataapprovalFailure = 864,
        [IntValueAttribute(49)]
        Approvekitdata = 865,
        [IntValueAttribute(49)]
        ApprovekitdataFailure = 866,

        #endregion

        [IntValueAttribute(49)]
        PincodeValidateSuccess = 867,
        [IntValueAttribute(49)]
        PincodeValidateFailedWithRestriction = 868,
        [IntValueAttribute(49)]
        PincodeValidateFailed = 869,

        #region bbps cust comp 1846
        [IntValueAttribute(49)]
        checkbbpscomplaintstatusSuccess = 876,
        [IntValueAttribute(49)]
        checkbbpscomplaintstatusFailed = 877,
        [IntValueAttribute(49)]
        checkbbpscomplaintdataSuccess = 878,
        [IntValueAttribute(49)]
        checkbbpscomplaintdataFailed = 879,
        [IntValueAttribute(49)]
        SubmitbbpscomplaintdataSuccess = 874,
        [IntValueAttribute(49)]
        SubmitbbpscomplaintdataFailed = 875,
        #endregion

        #region Foreign Remittance
        [IntValueAttribute(49)]
        AgentCreationSuccess = 1600,
        [IntValueAttribute(49)]
        AgentCreationFailed = 1601,
        [IntValueAttribute(49)]
        FRTransactionSuccess = 1602,
        [IntValueAttribute(49)]
        FRTransactionFailed = 1603,
        [IntValueAttribute(49)]
        FRGetTransactionSuccess = 1604,
        [IntValueAttribute(49)]
        FRGetTransactionFailed = 1605,
        [IntValueAttribute(49)]
        FRJVVerificationSuccess = 1606,
        [IntValueAttribute(49)]
        FRJVVerificationFailed = 1607,
        [IntValueAttribute(49)]
        FRMasterdataSuccess = 1608,
        [IntValueAttribute(49)]
        FRMasterdataFailed = 1609,
        [IntValueAttribute(49)]
        FRAgentSuccess = 1610,
        [IntValueAttribute(49)]
        FRAgentFailed = 1611,
        [IntValueAttribute(49)]
        FRUpdateagentSuccess = 1612,
        [IntValueAttribute(49)]
        FRUpdateagentFailed = 1613,
        [IntValueAttribute(49)]
        FRRevisiondataSuccess = 1614,
        [IntValueAttribute(49)]
        FRRevisiondataFailed = 1615,
        [IntValueAttribute(49)]
        FRRevisionSuccess = 1616,
        [IntValueAttribute(49)]
        FRRevisionFailed = 1617,
        [IntValueAttribute(49)]
        FRDocDmsSuccess = 1618,
        [IntValueAttribute(49)]
        FRDocDmsFailed = 1619,
        [IntValueAttribute(49)]
        FRAckPdfSuccess = 1620,
        [IntValueAttribute(49)]
        FRAckPdfFailed = 1621,
        [IntValueAttribute(49)]
        FRCAReportPdfSuccess = 1622,
        [IntValueAttribute(49)]
        FRCAReportPdfFailed = 1623,
        [IntValueAttribute(49)]
        FRMerAgreementSuccess = 1624,
        [IntValueAttribute(49)]
        FRMerAgreementFailed = 1625,
        #endregion

        [IntValueAttribute(49)]
        PanUpdateInCBsSuccess = 2001,
        [IntValueAttribute(49)]
        PanUpdateInCBSFailed = 2002,
        [IntValueAttribute(49)]
        AccountClosureChargesSuccess = 904,
        [IntValueAttribute(49)]
        AccountClosureChargesFailed = 905,
        [IntValueAttribute(49)]
        DMSGuardianNumberFound = 1001,
        [IntValueAttribute(49)]
        DMSGuardianNumberNotFound = 1002,
        [IntValueAttribute(49)]
        LatLongUpdateSuccessfully = 1003,
        [IntValueAttribute(49)]
        LatLongUpdateFailed = 1004,
        [IntValueAttribute(49)]
        DMSSRCounterSuccess = 1005,
        [IntValueAttribute(49)]
        DMSSRCounterFailed = 1006,
        [IntValueAttribute(49)]
        ITRStatusSuccess = 906,
        [IntValueAttribute(49)]
        ITRStatusFailed = 907,

        #region CustomerSupport
        [IntValueAttribute(49)]
        custSupportSuccess = 908,
        [IntValueAttribute(49)]
        custSupportFailed = 909,
        #endregion

        #region ForBillPayService
        [IntValueAttribute(49)]
        FingerPrintAuthenFailed = 910,
        [IntValueAttribute(49)]
        AadharAuthenFailed = 911,
        [IntValueAttribute(49)]
        operationtimeOutMiniStatement = 915,
        [IntValueAttribute(49)]
        operationtimeOut = 916,
        #endregion

        #region Insurance
        [IntValueAttribute(49)]
        InsurancePremiumMismatch = 1111,
        [IntValueAttribute(49)]
        InsuranceInvalidBadRequest = 1112,
        [IntValueAttribute(49)]
        InsuranceBuildLatestVr = 1113,
        [IntValueAttribute(49)]
        InsuranceOVDDetails = 1114,
        [IntValueAttribute(49)]
        InsuranceCloseExternalAccFalied = 1115,
        [IntValueAttribute(49)]
        InsuranceOtpAuthFailed = 1116,
        [IntValueAttribute(49)]
        InsuranceFPverificationFalied = 1117,
        [IntValueAttribute(49)]
        InsuranceTranTypeMismatch = 1118,

        #endregion

        #region FPBFinancial RestService
        [IntValueAttribute(49)]
        AccountOverrideChargesSuccess = 1111,
        [IntValueAttribute(49)]
        AccountOverrideChargesFailed = 1112,
        [IntValueAttribute(49)]
        AnalysisFlagIs1 = 1113,
        [IntValueAttribute(49)]
        InvalidErrorTxnLimitService = 1114,
        [IntValueAttribute(49)]
        TxnLimitDetailsNotAvailable = 1115,
        [IntValueAttribute(49)]
        UnableToParseTxnLimitRequest = 1116,
        [IntValueAttribute(49)]
        InvalidErrorInGetAccountOverrideChargesAPI = 1117,
        [IntValueAttribute(49)]
        ChargeOverrideDetailsNotAvailable = 1118,
        [IntValueAttribute(49)]
        UnableToParseChargeOverrideRequest = 1119,
        [IntValueAttribute(49)]
        TxnNotAllowedForSelectedProduct = 1120,
        [IntValueAttribute(49)]
        TransactionAllowed = 1121,
        [IntValueAttribute(49)]
        InvalidErrorInRestrictTxnByProductService = 1122,
        [IntValueAttribute(49)]
        UnableToParseRequestData = 1123,
        #endregion

        #region BusinessLogic TransactionLimit Contract
        [IntValueAttribute(49)]
        TxnLimitExceededTransactionFailed = 1124,
        [IntValueAttribute(49)]
        Success = 1125,
        [IntValueAttribute(49)]
        TxnLimitsDetailsNotFound = 1126,
        [IntValueAttribute(49)]
        RecordNotFound = 1127,
        [IntValueAttribute(49)]
        UnableToPerformTxnnCustomerNotExists = 1128,
        [IntValueAttribute(49)]
        OverrideChargesCalculationFailed = 1129,
        [IntValueAttribute(49)]
        OverrideConditionNotMatchedFetchChargesFromFIS = 1130,
        [IntValueAttribute(49)]
        OverrideChargesNotConfigured = 1131,
        [IntValueAttribute(49)]
        AccountChargesOverrideDetailsNotFound = 1132,
        [IntValueAttribute(49)]
        TxnNotAllowedForWallet = 1133,
        #endregion

        #region FPBNonFinancial RestService
        [IntValueAttribute(49)]
        UserNotAuthorizedToProceedTransaction = 1134,
        [IntValueAttribute(49)]
        NEFTTransactionNotAllowed = 1135,
        [IntValueAttribute(49)]
        BeneIFSCOrAccNumberCannotBeNullorEmpty = 1136,
        [IntValueAttribute(49)]
        Mobilenumbershouldnotbenullorempty = 1137,
        [IntValueAttribute(49)]
        TxnDetailsNotAvailableRequestData = 1138,
        [IntValueAttribute(49)]
        WalkinTransaction = 1139,
        [IntValueAttribute(49)]
        TxnTypeNotConfiguredForRestrictionProductCode = 1140,
        [IntValueAttribute(49)]
        ProductCodeNotConfigured = 1370,
        #endregion

        #region BusinessLogic NonFinancial Contract
        [IntValueAttribute(49)]
        NotalwdprfrmCshnaprvl = 1141,
        [IntValueAttribute(49)]
        trnsctnbtwnctoftime = 1142,
        [IntValueAttribute(49)]
        DearCstmrAplgsincnvnceplstrysvcaftr = 1143,
        [IntValueAttribute(49)]
        Rcrdnotfndfr = 1144,
        [IntValueAttribute(49)]
        Unbletofndcutoftime = 1145,
        [IntValueAttribute(49)]
        PostTrnsctnnotfound = 1146,
        #endregion

        [IntValueAttribute(49)]
        TxnUnderProccessCheckMiniStatment = 1147,
        [IntValueAttribute(49)]
        AccountClosureFnctnltyNotApplicableWlts = 1148,
        [IntValueAttribute(49)]
        ChannelIDNotFound = 1149,
        [IntValueAttribute(49)]
        UserClassNotFound = 1150,
        [IntValueAttribute(49)]
        ProductTypeNotFound = 1151,
        [IntValueAttribute(49)]
        DearCustomerFunctionalityInoperativeBtwnCutOffTime = 1152,
        [IntValueAttribute(49)]
        TxnDeclinedDueCreditRestrictionAccount = 1153,
        [IntValueAttribute(49)]
        CASAPLUSViewBlnceFailed = 1154,
        [IntValueAttribute(49)]
        TxnAmountMustLessMerchantLimit = 1155,
        [IntValueAttribute(49)]
        InvalidAccountNumber = 1156,
        [IntValueAttribute(49)]
        TxnNotAllowed = 1157,
        [IntValueAttribute(49)]
        CustomerConsumeLimitFound = 1158,
        [IntValueAttribute(49)]
        CustomerConsumeLimitNotFound = 1159,
        [IntValueAttribute(49)]
        CashWithdrawlTxnLimitDtlsNotFoundUser = 1160,
        [IntValueAttribute(49)]
        ServiceNotRespondingException = 1161,
        [IntValueAttribute(49)]
        InvalidMerchantDetails = 1162,
        [IntValueAttribute(49)]
        DearMerchantContactBranchOrSalesOfficerForSupport = 1163,
        [IntValueAttribute(49)]
        RequestDataNotFound = 1164,
        [IntValueAttribute(49)]
        MerchentLimitSuccess = 1165,
        [IntValueAttribute(49)]
        MerchentLimitFail = 1166,
        [IntValueAttribute(49)]
        GetMerchantLimitFailed = 1167,
        [IntValueAttribute(49)]
        MerchantNotAsCustomer = 1168,
        [IntValueAttribute(49)]
        AccountDetailsNotFound = 1169,
        [IntValueAttribute(49)]
        NotalwdtoprfrmCshnaprvl = 1170,
        [IntValueAttribute(49)]
        CutOffTimeFndCstmrSuccess = 1171,
        [IntValueAttribute(49)]
        Acntnbrprdctcdnomtchdinfndcstmr = 1172,
        [IntValueAttribute(49)]
        Cstmracntisinvld = 1173,
        //InvalidRequest = 1174,
        [IntValueAttribute(49)]
        UnableProcceedTxnPleaseTryAagain = 1175,
        [IntValueAttribute(49)]
        SuccessfullyInserted = 1176,
        [IntValueAttribute(49)]
        YourRequestHasSubmittedSuccessfully = 1177,
        [IntValueAttribute(49)]
        FailedToInsert = 1178,
        [IntValueAttribute(49)]
        AlertNameAlreadyPresent = 1179,
        [IntValueAttribute(49)]
        MerchantNotifictionDetailsSuccess = 1180,
        [IntValueAttribute(49)]
        NoNewMessage = 1181,
        [IntValueAttribute(49)]
        ServerNotRespondingPleaseTryAgainLater = 1182,
        [IntValueAttribute(49)]
        RemoteServerReturnedError = 1183,
        [IntValueAttribute(49)]
        AutoTxnChargesRequest = 1184,
        [IntValueAttribute(49)]
        Banknameshuldnotbeempty = 1185,
        [IntValueAttribute(49)]
        UnablePerformTxnDueIMPSNotAllowedSelectedBank = 1186,
        [IntValueAttribute(49)]
        ForslctdbankIMPSNEFTtrnsctnnotallowed = 1187,
        [IntValueAttribute(49)]
        UnblprfrmtrnsctndueTrnsctntypeshuldnotnley = 1188,
        [IntValueAttribute(49)]
        AutoTxnSuccess = 1189,
        [IntValueAttribute(49)]
        AutoTxnFailed = 1190,
        [IntValueAttribute(49)]
        ErrorInSystemWhileApproving = 1191,
        [IntValueAttribute(49)]
        GLAccountNumberNotFound = 1192,
        [IntValueAttribute(49)]
        LimitApprovedSuccessfully = 1193,
        [IntValueAttribute(49)]
        RequestedLimitCancelled = 1194,
        [IntValueAttribute(49)]
        RecordExistsInCBS = 1195,
        [IntValueAttribute(49)]
        RecordNotExistsInCBS = 1196,
        [IntValueAttribute(49)]
        ApproveStatusUpdated = 1197,
        [IntValueAttribute(49)]
        ErrorUpdatingApproved = 1198,
        [IntValueAttribute(49)]
        MerchantNameNotFound = 1199,
        [IntValueAttribute(49)]
        NoRecordFound = 1200,
        [IntValueAttribute(49)]
        DuplicateRqustNumber = 1201,
        [IntValueAttribute(49)]
        ModeOfTxnDataFound = 1202,
        [IntValueAttribute(49)]
        BankDataFound = 1203,
        [IntValueAttribute(49)]
        BankDataNotFound = 1204,
        [IntValueAttribute(49)]
        DataFound = 1205,
        [IntValueAttribute(49)]
        CashInIntntCountFound = 1206,
        [IntValueAttribute(49)]
        CashInIntntCountNotFound = 1207,
        [IntValueAttribute(49)]
        DplcteRqustNmbr = 1208,
        [IntValueAttribute(49)]
        CustomerNumberShouldNotNull = 1209,
        [IntValueAttribute(49)]
        FngrPrintnotactvtd = 1210,
        [IntValueAttribute(49)]
        CustomerFPDataAvailable = 1211,
        [IntValueAttribute(49)]
        CustomerFPDataNotExist = 1212,
        [IntValueAttribute(49)]
        FngrPrintnotmatched = 1213,
        [IntValueAttribute(49)]
        CustomerSupportDetailsuccess = 1214,
        [IntValueAttribute(49)]
        CustomerSupportDtlsDataSelectionFailed = 1215,
        [IntValueAttribute(49)]
        RequstError = 1216,
        [IntValueAttribute(49)]
        Merchantrtinginformation = 1217,
        [IntValueAttribute(49)]
        Merchantrtinginformationnotavailable = 1218,
        [IntValueAttribute(49)]
        ServiceisRestricted = 1219,
        [IntValueAttribute(49)]
        DataNotFound = 1220,
        [IntValueAttribute(49)]
        NoDetailsFound = 1221,
        [IntValueAttribute(49)]
        RecordNotFoundBLLDB = 1222,
        [IntValueAttribute(49)]
        RequestNotContainXCorelationID = 1223,
        [IntValueAttribute(49)]
        RequestDataEmpty = 1224,
        [IntValueAttribute(49)]
        InvalidJSONTxnResponse = 1225,
        [IntValueAttribute(49)]
        TxnResponseNotFound = 1226,
        [IntValueAttribute(49)]
        UnableParseResponse = 1227,
        [IntValueAttribute(49)]
        TxnDetailsNotFoundThisTxnType = 1229,
        [IntValueAttribute(49)]
        AEPSTxnLimitDetailsNotFoundThisUser = 1230,
        [IntValueAttribute(49)]
        InvalidUserId = 1231,
        [IntValueAttribute(49)]
        InvalidTerminalId = 1232,
        [IntValueAttribute(49)]
        BAVVerifiedSuccess = 1233,
        [IntValueAttribute(49)]
        AEPSCashDepositTxnFailed = 1234,
        [IntValueAttribute(49)]
        AEPSCashDepositSuccess = 1235,
        [IntValueAttribute(49)]
        AEPSCashDepositFailed = 1236,
        [IntValueAttribute(49)]
        AepsTwoFactorAuthDataInsertSuccess = 1237,
        [IntValueAttribute(49)]
        AepsTwoFactorAuthDataInsertFailed = 1238,
        [IntValueAttribute(49)]
        ESBServerUnavailable = 1239,
        [IntValueAttribute(49)]
        InvalidBadRequestf = 1240,
        [IntValueAttribute(49)]
        AEPSMiniStatementFailed = 1241,

        #region Rewards
        [IntValueAttribute(49)]
        ServerNotRes = 1300,
        [IntValueAttribute(49)]
        RewardDataFound = 1301,
        [IntValueAttribute(49)]
        RewardDataNotFound = 1302,
        [IntValueAttribute(49)]
        ClavaxDataFound = 1305,
        [IntValueAttribute(49)]
        ClavaxDataNotFound = 1306,
        [IntValueAttribute(49)]
        RewardStmtFound = 1307,
        [IntValueAttribute(49)]
        RewardStmtNotFound = 1308,
        #endregion

        #region Registration
        [IntValueAttribute(49)]
        StrCifID = 1320,
        [IntValueAttribute(49)]
        StrCifIDNotAvailable = 1321,
        [IntValueAttribute(49)]
        SuccessFlag = 1322,
        [IntValueAttribute(49)]
        FailedFlag = 1323,
        [IntValueAttribute(49)]
        InvalidUserID = 1324,
        [IntValueAttribute(49)]
        InvalidTerminalID = 1325,
        [IntValueAttribute(49)]
        PanValidationFailedRequest = 1326,
        [IntValueAttribute(49)]
        PanValidationFailed_AttemptExceed = 1327,
        [IntValueAttribute(49)]
        PanValidationFailed_PanCount = 1328,
        [IntValueAttribute(49)]
        PanValidationFailed_signfailed = 1329,
        [IntValueAttribute(49)]
        PanValidationFailed_AddressNotFound = 1330,
        [IntValueAttribute(49)]
        MerlatLongSuccess = 1331,
        [IntValueAttribute(49)]
        MerlatLongFailed = 1332,
        [IntValueAttribute(49)]
        RequestdataNotFound = 1333,
        [IntValueAttribute(49)]
        AcctNoNotFound = 1334,
        [IntValueAttribute(49)]
        EKYCStatusFound = 1335,
        [IntValueAttribute(49)]
        EKYCStatusNotFound = 1336,
        [IntValueAttribute(49)]
        ReqFormatErr = 1337,
        [IntValueAttribute(49)]
        MerStatusUpdate = 1338,
        [IntValueAttribute(49)]
        MerStatusUpdateFailed = 1339,
        [IntValueAttribute(49)]
        AddProd_pincode = 1340,
        [IntValueAttribute(49)]
        AddProd_AllowCust = 1341,
        [IntValueAttribute(49)]
        CustDataFound = 1342,
        [IntValueAttribute(49)]
        CustDataNotFound = 1343,
        #endregion

        #region Lic Billpayment
        [IntValueAttribute(49)]
        FetchLICBillpaymentDetailSuccess = 1350,
        [IntValueAttribute(49)]
        FetchLICBillpaymentDetailFailed = 1351,
        [IntValueAttribute(49)]
        FetchLICBillpaymentChargesSuccess = 1352,
        [IntValueAttribute(49)]
        FetchLICBillpaymentChargesFailed = 1353,
        [IntValueAttribute(49)]
        PostLICBillpaymentTransactionSuccess = 1354,
        [IntValueAttribute(49)]
        PostLICBillpaymentTransactionFailed = 1355,
        #endregion

        #region Cc Billpayment
        [IntValueAttribute(49)]
        FetchCcBillpaymentDetailSuccess = 1360,
        [IntValueAttribute(49)]
        FetchCcBillpaymentDetailFailed = 1361,
        [IntValueAttribute(49)]
        FetchCcBillpaymentChargesSuccess = 1362,
        [IntValueAttribute(49)]
        FetchCcBillpaymentChargesFailed = 1363,
        [IntValueAttribute(49)]
        PostCcBillpaymentTransactionSuccess = 1364,
        [IntValueAttribute(49)]
        PostCcBillpaymentTransactionFailed = 1365,
        #endregion

        #region CMS Cash Collection
        [IntValueAttribute(49)]
        TokenNotGenerated = 700600,
        [IntValueAttribute(49)]
        DownloadLatest = 700601,
        [IntValueAttribute(49)]
        SuspiciousTransactionDetected = 700602,
        [IntValueAttribute(49)]
        AmtMismatch = 700603,
        [IntValueAttribute(49)]
        BlankToken = 700604,
        [IntValueAttribute(49)]
        MagmaCustValidation = 700613,
        #endregion
        [IntValueAttribute(49)]
        invalidMapperID = 1401,

        #region CMSLogin DNN
        [IntValueAttribute(49)]
        GetCMSTickerDataSuccess = 8020,
        [IntValueAttribute(49)]
        GetCMSTickerDataFailed = 8021,
        [IntValueAttribute(49)]
        GetCMSImageBannerDataSuccess = 8022,
        [IntValueAttribute(49)]
        GetCMSImageBannerDataFailed = 8023,
        [IntValueAttribute(49)]
        GetCMSGyankoshDataSuccess = 8024,
        [IntValueAttribute(49)]
        GetCMSGyankoshDataFailed = 8025,
        [IntValueAttribute(49)]
        GetCMSLatestSchemesDataSuccess = 8026,
        [IntValueAttribute(49)]
        GetCMSLatestSchemesDataFailed = 8027,
        [IntValueAttribute(49)]
        GetCMSSliderImageDataSuccess = 8028,
        [IntValueAttribute(49)]
        GetCMSSliderImageDataFailed = 8029
        #endregion
    }


}
