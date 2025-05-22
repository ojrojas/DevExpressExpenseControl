namespace ExpenseControl.Services.ExpenseControlApi.Exceptions;

public class WalletNotAvailableException : Exception
{
    public WalletNotAvailableException()
    {
    }

    public WalletNotAvailableException(string? message) : base(message)
    {
    }

    public WalletNotAvailableException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected WalletNotAvailableException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}