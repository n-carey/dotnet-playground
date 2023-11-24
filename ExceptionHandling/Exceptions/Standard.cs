using Microsoft.Extensions.Logging;

namespace Exceptions;

/// <summary>
/// The following class attempts to demonstrate some of the core concepts around error/exception
/// handling in .NET.
/// </summary>
public class StandardExceptionHandling : IExceptionSimulator
{
    private readonly ILogger _log;

    public StandardExceptionHandling(ILogger log)
    {
        _log = log;
    }

    public void ThrowEx()
    {
        // These calls simply demonstrate the different types of exceptions that can be thrown
        // and how we can handle those in a typical try/catch/finally block.
        ThrowSimpleException(new NullReferenceException());
        ThrowSimpleException(new NotImplementedException());
        ThrowSimpleException(new SystemException());

        // The following attempts to log appropriate information about the exception thrown
        // using the information present at the time (scope and exception info).
        ThrowExWithLogging();
    }

    private void ThrowSimpleException(Exception expected)
    {
        try
        {
            throw expected;
        }
        // These catches specify the actual type of exception to capture. This can be useful when we
        // want to handle specific exceptions a certain way.
        //
        // For example, if it's a database connection we may want to wait a few seconds before trying
        // again since blips of this nature aren't uncommon.
        catch (NullReferenceException ex)
        {
            _log.LogInformation($"Expected: System.NullReferenceException, received: {ex.GetType().FullName}");
        }
        catch (NotImplementedException ex)
        {
            _log.LogInformation($"Expected: System.NotImplementedException, received: {ex.GetType().FullName}");
        }
        // The following is a generic catch-all for error handling. Without this the process would have
        // ended.
        //
        // Generally, this should be avoided where possible. We should aim to be deliberate with
        // our implementations of try/catch/finally blocks and especially with the kinds of exceptions we
        // expect to be thrown. It all contributes to overall more robust solutions.
        catch (Exception ex)
        {
            _log.LogInformation($"Expected: AnyException, received: {ex.GetType().FullName}");
        }
        finally
        {
            _log.LogInformation("This is the 'finally' block. It's always called after a catch.");
        }
    }

    private void ThrowExWithLogging()
    {
        var proposedIndex = 10;
        List<string> testList = new();
        try
        {
            var nonExistant = testList[proposedIndex];
        }
        catch (ArgumentOutOfRangeException ex)
        {
            _log.LogError(
                $"Error retrieving element from list. Attempted to pull index {proposedIndex} with only {testList.Count} items.\nStacktrace:\n{ex.StackTrace}");
        }
    }
}