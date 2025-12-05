namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.CommandResults;

public class NotSupportedError : IFileSystemError
{
    public string Message { get; }

    public NotSupportedError(string? message = null)
    {
        Message = message ?? "Undefined error";
    }
}