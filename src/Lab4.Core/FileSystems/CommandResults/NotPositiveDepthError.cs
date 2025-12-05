namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.CommandResults;

public class NotPositiveDepthError : IFileSystemError
{
    public string Message => "Not positive depth error";
}