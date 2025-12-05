namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.NodeVisitors;

public class LocalDirectoryNode : IFileSystemNode
{
    public LocalDirectoryNode(string name, string path)
    {
        Name = name;
        Path = path;
    }

    public string Name { get; }

    public string Path { get; }

    public IEnumerable<IFileSystemNode> GetChildren()
    {
        foreach (string dir in Directory.GetDirectories(Path))
            yield return new LocalDirectoryNode(System.IO.Path.GetFileName(dir), dir);

        foreach (string file in Directory.GetFiles(Path))
            yield return new LocalFileNode(System.IO.Path.GetFileName(file));
    }

    public void Accept(IFileSystemTreeVisitor visitor, int depth)
    {
        visitor.Visit(this, depth);
    }
}