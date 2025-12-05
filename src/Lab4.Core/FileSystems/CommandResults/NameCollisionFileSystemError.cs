namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Errors;

public class NameCollisionFileSystemError : IFileSystemError
{
    public string Message => "Collision of names in file system";
}