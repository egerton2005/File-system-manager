namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Errors;

public class IncorrectPathFileSystemError : IFileSystemError
{
    public string Message => "The path you entered is incorrect.";
}