namespace Common.Application.Dto
{
    public class OtpRequest
    {
        public string CustomerMobileNo { get; set; }

        public string EventId { get; set; }
        public int MethodId { get; set; }

        public NotifyParameter NotifyParam { get; set; }

        public VerifyParameter VerifyParam { get; set; }

    }
}
