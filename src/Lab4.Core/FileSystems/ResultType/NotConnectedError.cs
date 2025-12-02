namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.ResultType;

public class NotConnectedError : IFileSystemError
{
    public string Message => "Not connected";
}