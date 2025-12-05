namespace Itmo.ObjectOrientedProgramming.Lab4.Core.SystemPathUtilities.Results;

public abstract record PathUtilityResult
{
    private PathUtilityResult() { }

    public sealed record Success(string Value) : PathUtilityResult;

    public sealed record Failure(IPathUtilityError Error) : PathUtilityResult;
}