using Microsoft.Extensions.Logging;

namespace Workshop2.UnitTesting;

public class BarAppender
{
    private readonly ILogger _logger;

    public BarAppender(ILogger logger)
    {
        _logger = logger;
    }

    public string AppendBar(string stringToAppendTo)
    {
        _logger.Log(LogLevel.Information, $"Appending Bar to {stringToAppendTo}");
        return $"{stringToAppendTo}Bar";
    }
}