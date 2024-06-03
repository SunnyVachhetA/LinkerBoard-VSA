namespace LinkerBoard.API.Features.Common;

internal sealed class UnprocessableException
    : Exception
{
    internal UnprocessableException()
        : base("Unprocessable entity.")
    { }
    
    internal UnprocessableException(string message)
        : base(message)
    { }
}
