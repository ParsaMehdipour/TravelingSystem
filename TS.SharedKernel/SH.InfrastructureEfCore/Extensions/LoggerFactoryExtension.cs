using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace SH.InfrastructureEfCore.Extensions;

public static class LoggerFactoryExtension
{
    private static ILoggerFactory GetLoggerFactory(this IServiceProvider provider)
    {
        return provider.GetRequiredService<ILoggerFactory>();
    }

    public static void SeedLogger(this IServiceProvider provider, string message, LogLevel logLevel = LogLevel.Information)
    {
        provider.GetLoggerFactory().CreateLogger("Seed-Data").Log(logLevel, message);
    }
}