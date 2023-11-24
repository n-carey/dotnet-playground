using Microsoft.Extensions.Logging;

namespace Exceptions;

public interface IExceptionSimulator
{
    void ThrowEx();
}

public class StandardExceptionHandling : IExceptionSimulator
{
    private readonly ILogger _log;

    public StandardExceptionHandling(ILogger log)
    {
        _log = log;
    }

    public void ThrowEx()
    {
        ThrowException(new NullReferenceException());
        ThrowException(new NotImplementedException());
        ThrowException(new SystemException());
    }

    private void ThrowException(Exception expected)
    {
        try
        {
            throw expected;
        }
        // These catches specify the actual type of exception to capture. This can be useful when we
        // want to handle specific exceptions a certain way.
        //
        // For example, if it's an database connection we may want to way a few seconds before trying
        // again since blips of this nature aren't uncommon.
        catch (NullReferenceException ex)
        {
            _log.LogInformation($"Expected: System.NullReferenceException, received: {ex.GetType().FullName}");
        }
        catch(NotImplementedException ex)
        {
            _log.LogInformation($"Expected: System.NotImplementedException, received: {ex.GetType().FullName}");
        }
        // The following is a generic catch-all for error handling. Without this the process would have
        // ended.
        catch(Exception ex)
        {
            _log.LogInformation($"Expected: AnyException, received: {ex.GetType().FullName}");
        }
        finally
        {
            _log.LogInformation("This is the 'finally' block. It's always called after a catch.");
        }
    }
}