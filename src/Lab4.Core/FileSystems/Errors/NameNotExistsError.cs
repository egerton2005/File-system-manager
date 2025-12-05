namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Errors;

public class NameNotExistsError : IFileSystemError
{
    public string Message => "File or Directory with the same name not exists";
}