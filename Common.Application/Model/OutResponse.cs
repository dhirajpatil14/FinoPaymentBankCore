namespace Common.Application.Model
{
    public class OutResponse : Common
    {
        public int ResponseCode { get; set; }
        public string DisplayMessage { get; set; }
        public string ResponseMessage { get; set; }
        public string MessageType { get; set; }
        public string ResponseData { get; set; }
        public string MessageId { get; set; }
        public string RouteID { get; set; }
        public int ErrorCode { get; set; }
        public string XMLData { get; set; }
        public bool AuthmanFlag { get; set; }
        public int ServiceID { get; set; }
        public string ResponseMessage_Hindi { get; set; }
    }
}
