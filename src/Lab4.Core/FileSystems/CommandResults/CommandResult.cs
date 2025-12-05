namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.CommandResults;

public abstract record CommandResult
{
    private CommandResult() { }

    public sealed record Success() : CommandResult;

    public sealed record Failure(IFileSystemError Error) : CommandResult;
}