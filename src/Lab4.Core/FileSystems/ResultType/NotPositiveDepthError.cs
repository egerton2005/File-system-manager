namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.ResultType;

public class NotPositiveDepthError : IFileSystemError
{
    public string Message => "Not positive depth error";
}