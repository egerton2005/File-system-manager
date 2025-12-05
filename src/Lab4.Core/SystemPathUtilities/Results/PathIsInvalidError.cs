namespace Itmo.ObjectOrientedProgramming.Lab4.Core.SystemPathUtilities.Results;

public class PathIsInvalidError : IPathUtilityError
{
    public string Message => "Path is invalid";
}