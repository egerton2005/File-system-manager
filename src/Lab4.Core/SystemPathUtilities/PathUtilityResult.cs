namespace Itmo.ObjectOrientedProgramming.Lab4.Core.SystemPathUtilities;

public abstract record PathUtilityResult<T>
{
    private PathUtilityResult() { }

    public sealed record Success(T Value) : PathUtilityResult<T>;

    public sealed record Failure(IPathUtilityError Error) : PathUtilityResult<T>;
}