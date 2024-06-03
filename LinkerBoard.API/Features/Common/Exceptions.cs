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

internal sealed class ResourceNotFoundException
    : Exception
{
    internal ResourceNotFoundException()
        : base("Resource not found.")
    { }

    internal ResourceNotFoundException(string message)
        : base(message)
    { }
}