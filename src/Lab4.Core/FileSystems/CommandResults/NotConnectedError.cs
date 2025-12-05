namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.CommandResults;

public class NotConnectedError : IFileSystemError
{
    public string Message => "Not connected";
}