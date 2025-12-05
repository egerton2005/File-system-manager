namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.CommandResults;

public class AlreadyConnectedError : IFileSystemError
{
    public string Message => "Already connected";
}