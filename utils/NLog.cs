using NLog.Extensions.Logging;

namespace Method;

public class Logger
{
    private readonly IConfiguration configuration;
    public Logger()
    {
        NLog.LogManager.Configuration = new NLogLoggingConfiguration(configuration.GetSection("NLog"));
    }
    public static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
}
