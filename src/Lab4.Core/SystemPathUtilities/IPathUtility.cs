namespace Itmo.ObjectOrientedProgramming.Lab4.Core.SystemPathUtilities;

public interface IPathUtility
{
    PathUtilityResult ResolveRootPath(string path);

    PathUtilityResult GoToPath(string rootPath, string fromPath, string toPath);

    string CombinePaths(string? basePath, string relative);

    string? GetDirectoryName(string path);
}