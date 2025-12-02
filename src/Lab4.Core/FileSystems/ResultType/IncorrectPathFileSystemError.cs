namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.ResultType;

public class IncorrectPathFileSystemError : IFileSystemError
{
    public string Message => "The path you entered is incorrect.";
}