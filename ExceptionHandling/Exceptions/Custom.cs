using Microsoft.Extensions.Logging;

namespace Exceptions;

/// <summary>
/// The following class attempts to demonstrate how custom exceptions are both created
/// and utilised in a typical .NET environment.
/// </summary>
public class CustomExceptionHandling : IExceptionSimulator
{
    private readonly ILogger _log;

    public CustomExceptionHandling(ILogger log)
    {
        _log = log;
    }

    public void ThrowEx()
    {
    }
}

class CustomException : Exception
{
    
}
