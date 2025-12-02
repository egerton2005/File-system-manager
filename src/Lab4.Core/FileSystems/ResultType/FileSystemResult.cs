namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.ResultType;

public abstract record FileSystemResult<T>
{
    private FileSystemResult() { }

    public sealed record Success(T? Text) : FileSystemResult<T>;

    public sealed record Failure(IFileSystemError Error) : FileSystemResult<T>;
}