namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.CommandResults;

public class NameNotExistsError : IFileSystemError
{
    public string Message => "File or Directory with the same name not exists";
}