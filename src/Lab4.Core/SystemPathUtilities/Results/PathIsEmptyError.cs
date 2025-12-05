namespace Itmo.ObjectOrientedProgramming.Lab4.Core.SystemPathUtilities.Results;

public class PathIsEmptyError : IPathUtilityError
{
    public string Message => "Path is empty";
}