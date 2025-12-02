namespace Itmo.ObjectOrientedProgramming.Lab4.Core.ValueObjects;

public class Path
{
    public string FullPath { get; }

    public bool IsAbsolute { get; }

    public Path(string raw)
    {
        FullPath = raw;
        IsAbsolute = FullPath.StartsWith('/');
    }

    public static Path FromLocal(string path, Path basePath)
        => basePath.Combine(new Path(path));

    public Path Combine(Path path)
    {
        return path.IsAbsolute
            ? path
            : new Path($"{FullPath}/{path.FullPath}");
    }

    public override string ToString()
        => FullPath;
}