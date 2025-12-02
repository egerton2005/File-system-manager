namespace Itmo.ObjectOrientedProgramming.Lab4.Core.SystemPathUtilities;

public interface IPathUtility
{
    PathUtilityResult<string> ResolveRootPath(string path);

    PathUtilityResult<string> GoToPath(string rootPath, string fromPath, string toPath);

    string CombinePaths(string? basePath, string relative);
}