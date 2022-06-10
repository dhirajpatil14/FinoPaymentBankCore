namespace Loggers.Logs
{
    public class LogSettings<TRequest>
    {
        public bool LogEnable { get; set; } = true;

        public TRequest Request { get; set; }

        public string LogDbConnection { get; set; }

        public int LayerId { get; set; }

    }
}
