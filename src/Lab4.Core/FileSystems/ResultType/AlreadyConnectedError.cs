namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.ResultType;

public class AlreadyConnectedError : IFileSystemError
{
    public string Message => "Already connected";
}