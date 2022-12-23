using System;

namespace Loggers.Logs
{
    public class LogSettings<TRequest>
    {
        public bool LogEnable { get; set; } = true;

        public TRequest Request { get; set; }

        public Enum LogTable { get; set; }

    }
}
