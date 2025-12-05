namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Errors;

public class NotPositiveDepthError : IFileSystemError
{
    public string Message => "Not positive depth error";
}