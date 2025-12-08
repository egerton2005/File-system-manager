namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

public class LocalFileSystem : IFileSystem
{
    public Stream GetFileStream(string path)
        => File.OpenRead(path);

    public void FileMove(string source, string destination)
        => File.Move(source, destination);

    public void FileDelete(string path)
        => File.Delete(path);

    public void FileCopy(string source, string destination)
        => File.Copy(source, destination);

    public string? Combine(string? rootPath, string? fromPath, string toPath)
    {
        toPath = NormalizeSlashes(StripQuotes(toPath));

        if (IsAbsolute(toPath))
        {
            if (string.IsNullOrEmpty(rootPath))
                return toPath;
            return rootPath + '\\' + toPath;
        }

        string? relative = Normalize(toPath);

        if (string.IsNullOrEmpty(relative))
            return null;

        if (string.IsNullOrEmpty(fromPath))
            return toPath;
        string? resultPath = Normalize(fromPath + '\\' + relative);
        if (resultPath is null || (rootPath is not null && !resultPath.StartsWith(rootPath)))
            return null;
        return resultPath;
    }

    public string? GetDirectoryName(string path)
    {
        string? result = Combine(string.Empty, string.Empty, path);
        if (result is null)
            return null;
        return Path.GetDirectoryName(result);
    }

    private static bool IsAbsolute(string path)
    {
        path = NormalizeSlashes(path);

        return (path.Length >= 3 &&
                char.IsLetter(path[0]) &&
                path[1] == ':' &&
                path[2] == '\\') || (path.Length > 0 && path[0] == '\\');
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

    private static string? Normalize(string path)
    {
        path = NormalizeSlashes(path);

        string[] parts = path.Split('\\', StringSplitOptions.RemoveEmptyEntries);

        if (parts.Length == 0)
            return null;

        var stack = new Stack<string>();
        stack.Push(parts[0]);

        foreach (string part in parts.Skip(1))
        {
            string clear = StripQuotes(part);
            if (clear == ".") continue;
            if (clear == "..")
            {
                if (stack.Count > 1)
                    stack.Pop();
                else
                    return null;
                continue;
            }

            if (string.IsNullOrWhiteSpace(clear))
                continue;

            stack.Push(clear);
        }

        return string.Join("\\", stack.Reverse());
    }
}