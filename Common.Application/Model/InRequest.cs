namespace Common.Application.Model
{
    public class InRequest
    {
        public string RequestId { get; set; }
        public int MethodId { get; set; }
        public string TellerId { get; set; }
        public string SessionId { get; set; }
        public string TokenId { get; set; }
        public bool IsEncrypt { get; set; }
        protected string RequestData { get; set; }

        public string SessionExpiryTime { get; set; }

        public string XAuthToken { get; set; }
        public int ChannelID { get; set; }
        public string ProductCode { get; set; }


    }
}
