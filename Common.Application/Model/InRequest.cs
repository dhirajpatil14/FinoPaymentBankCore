namespace Common.Application.Model
{
    public class InRequest : Common
    {
        public int MethodId { get; set; }
        public string TellerId { get; set; }
        public string TokenId { get; set; }
        public bool IsEncrypt { get; set; }
        public string RequestData { get; set; }
        public string XAuthToken { get; set; }
        public int ChannelID { get; set; }
        public string ProductCode { get; set; }
        public int ServiceID { get; set; }
    }
}
