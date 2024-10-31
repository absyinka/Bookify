namespace Bookify.Application.Exceptions;

public sealed class ConcurrencyException : Exception
{
    public ConcurrencyException(string Message, Exception innerException)
        : base(Message, innerException)
    {

    }
}
