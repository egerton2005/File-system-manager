namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Errors;

public class NotConnectedError : IFileSystemError
{
    public string Message => "Not connected";
}