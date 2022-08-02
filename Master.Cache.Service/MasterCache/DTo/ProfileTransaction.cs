using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Master.Cache.Service.MasterCache.DTo
{
    public class ProfileTransaction
    {
        public string ProfileTypeID { get; set; }

        [JsonIgnore]
        public string ChannelID { get; set; }
        [JsonIgnore]
        public string UserTypeID { get; set; }
        [JsonIgnore]
        public string UserTypeName { get; set; }
        
        public string TransactionTypeID { get; set; }
        public string TransactionType { get; set; }
        public string TransactionTypeName { get; set; }
        public string PerTransactionLimit { get; set; }
        public string MinTransLimit { get; set; }
        public string MaxTransLimit { get; set; }
        public string AuthTypeID { get; set; }
        public string AuthTypeName { get; set; }
        public string ProductTypeID { get; set; }
        public Boolean Status { get; set; }
        public Boolean IsFinancial { get; set; }
        public Boolean Denomination { get; set; }
        public Boolean IsSplit { get; set; }
        public string NoofRetry { get; set; }
        public string FallBackAuth { get; set; }
        public string DMSId { get; set; }
        public string PageUrl { get; set; }
        public string RFU { get; set; }
        public string UserGrossLimit { get; set; }
        public string NoofFallBack { get; set; }
        public Boolean CashContributionStatus { get; set; }
        public Boolean IsOnlyWalkin { get; set; }
        public string TransactionTypeKey { get; set; }
    }
}
