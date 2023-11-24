namespace Exceptions;

public interface IExceptionSimulator
{
    void ThrowEx();
}

public class StandardExceptionHandling : IExceptionSimulator
{
    public void ThrowEx()
    {
        throw new NotImplementedException();
    }
}