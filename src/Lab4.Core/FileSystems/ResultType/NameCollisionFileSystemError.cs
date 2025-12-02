namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.ResultType;

public class NameCollisionFileSystemError : IFileSystemError
{
    public string Message => "Collision of names in file system";
}