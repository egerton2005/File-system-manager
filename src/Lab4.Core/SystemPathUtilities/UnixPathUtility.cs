using Itmo.ObjectOrientedProgramming.Lab4.Core.SystemPathUtilities.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.SystemPathUtilities;

public class UnixPathUtility : IPathUtility
{
    public PathUtilityResult ResolveRootPath(string path)
    {
        path = StripQuotes(path);

        if (!IsAbsolute(path))
            return new PathUtilityResult.Failure(new PathIsInvalidError());
        return Normalize(path);
    }

    public PathUtilityResult GoToPath(string rootPath, string fromPath, string toPath)
    {
        toPath = StripQuotes(toPath);

        string rawPath = IsAbsolute(toPath)
            ? toPath
            : CombinePaths(fromPath, toPath);

        PathUtilityResult normalized = Normalize(rawPath);

        if (normalized is PathUtilityResult.Failure)
            return normalized;

        string normalizedPath = ((PathUtilityResult.Success)normalized).Value;

        if (!normalizedPath.StartsWith(rootPath))
            return new PathUtilityResult.Failure(new PathIsInvalidError());

        return normalized;
    }

    public string CombinePaths(string? basePath, string relative)
    {
        if (string.IsNullOrEmpty(basePath))
            return relative;

        if (string.IsNullOrEmpty(relative))
            return basePath;

        if (basePath.EndsWith('/'))
            return basePath + relative;

        return basePath + "/" + relative;
    }

    public string? GetDirectoryName(string path)
    {
        PathUtilityResult result = ResolveRootPath(path);
        if (result is PathUtilityResult.Failure f)
            return null;
        return Path.GetDirectoryName(((PathUtilityResult.Success)result).Value);
    }

    public string? GetFileName(string path)
    {
        PathUtilityResult result = ResolveRootPath(path);
        if (result is PathUtilityResult.Failure f)
            return null;
        return Path.GetFileName(((PathUtilityResult.Success)result).Value);
    }

    private static bool IsAbsolute(string path)
    {
        if (string.IsNullOrWhiteSpace(path))
            return false;

        return path.StartsWith('/');
    }

    private static string StripQuotes(string path)
    {
        if (string.IsNullOrWhiteSpace(path)) return path;
        path = path.Trim();
        if ((path.StartsWith('\"') && path.EndsWith('\"')) || (path.StartsWith('\'') && path.EndsWith('\'')))
            return path.Substring(1, path.Length - 2);
        return path;
    }

    private static PathUtilityResult Normalize(string path)
    {
        string[] parts = path.Split('/', StringSplitOptions.RemoveEmptyEntries);
        var stack = new Stack<string>();

        foreach (string part in parts)
        {
            string clearPart = StripQuotes(part);
            if (clearPart == ".") continue;
            if (clearPart == "..")
            {
                if (stack.Count > 0)
                    stack.Pop();
                else
                    return new PathUtilityResult.Failure(new PathIsInvalidError());
                continue;
            }

            stack.Push(clearPart);
        }

        return new PathUtilityResult.Success("/" + string.Join('/', stack.Reverse()));
    }
}