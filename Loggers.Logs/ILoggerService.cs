using System.Threading.Tasks;

namespace Loggers.Logs
{
    public interface ILoggerService
    {
        Task<int> WriteLogAsync<TLogSettings>(LogSettings<TLogSettings> loggerRequest);
    }
}
