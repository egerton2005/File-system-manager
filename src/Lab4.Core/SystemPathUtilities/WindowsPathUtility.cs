using Itmo.ObjectOrientedProgramming.Lab4.Core.SystemPathUtilities.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.SystemPathUtilities;

public class WindowsPathUtility : IPathUtility
{
    public PathUtilityResult GoToPath(string rootPath, string fromPath, string toPath)
    {
        toPath = NormalizeSlashes(StripQuotes(toPath));

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
        basePath = NormalizeSlashes(basePath ?? string.Empty);
        relative = NormalizeSlashes(relative);

        if (string.IsNullOrEmpty(basePath))
            return relative;

        if (string.IsNullOrEmpty(relative))
            return basePath;

        return basePath + '\\' + relative;
    }

    public string? GetDirectoryName(string path)
    {
        PathUtilityResult result = GoToPath(string.Empty, string.Empty, path);
        if (result is PathUtilityResult.Failure f)
            return null;
        return Path.GetDirectoryName(((PathUtilityResult.Success)result).Value);
    }

    private static bool IsAbsolute(string path)
    {
        path = NormalizeSlashes(path);

        return path.Length >= 3 &&
               char.IsLetter(path[0]) &&
               path[1] == ':' &&
               path[2] == '\\';
    }

    private static string NormalizeSlashes(string path)
    {
        path = path.Replace('/', '\\');
        if (path.EndsWith('\\'))
            path = path[..^1];
        if (path.StartsWith('\\'))
            path = path[1..];
        return path;
    }

    private static string StripQuotes(string path)
    {
        if (string.IsNullOrWhiteSpace(path)) return path;
        path = path.Trim();

        if ((path.StartsWith('"') && path.EndsWith('"')) || (path.StartsWith('\'') && path.EndsWith('\'')))
            return path.Substring(1, path.Length - 2);

        return path;
    }

    private static PathUtilityResult Normalize(string path)
    {
        path = NormalizeSlashes(path);

        string[] parts = path.Split('\\', StringSplitOptions.RemoveEmptyEntries);

        if (parts.Length == 0)
            return new PathUtilityResult.Failure(new PathIsInvalidError());

        string drive = parts[0];
        if (drive.Length != 2 || drive[1] != ':')
            return new PathUtilityResult.Failure(new PathIsInvalidError());

        var stack = new Stack<string>();
        stack.Push(drive);

        foreach (string part in parts.Skip(1))
        {
            string clear = StripQuotes(part);
            if (clear == ".") continue;
            if (clear == "..")
            {
                if (stack.Count > 1)
                    stack.Pop();
                else
                    return new PathUtilityResult.Failure(new PathIsInvalidError());
                continue;
            }

            if (string.IsNullOrWhiteSpace(clear))
                continue;

            stack.Push(clear);
        }

        string result = string.Join("\\", stack.Reverse());
        return new PathUtilityResult.Success(result);
    }
}