namespace Common.Application.Model
{
    public class Exceptions
    {
        public int LineNumber { get; set; }
        public string FileName { get; set; }

        public string Message { get; set; }

        public string RequestData { get; set; }
    }
}
