namespace Itmo.ObjectOrientedProgramming.Lab4.Core.SystemPathUtilities;

public class PathIsEmptyError : IPathUtilityError
{
    public string Message => "Path is empty";
}