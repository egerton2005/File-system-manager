namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Errors;

public class AlreadyConnectedError : IFileSystemError
{
    public string Message => "Already connected";
}