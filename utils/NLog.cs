using NLog.Extensions.Logging;

namespace Method;

public class Logger
{
    public Logger(IConfiguration configuration)
    {
        NLog.LogManager.Configuration = new NLogLoggingConfiguration(configuration.GetSection("NLog"));
    }
    public readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
}
