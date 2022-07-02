using Loggers.Logs.Model;
using System.Threading.Tasks;

namespace Loggers.Logs
{
    public interface ILoggerService
    {
        Task<int> WriteCorelationLogAsync(CorelationLoggerRequest loggerRequest);

        Task<int> WriteFillLogAsync(FillLoggerRequest loggerRequest);

    }
}
