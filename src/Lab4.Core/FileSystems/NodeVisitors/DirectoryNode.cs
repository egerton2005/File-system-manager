namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.NodeVisitors;

public class DirectoryNode : IFileSystemNode
{
    public DirectoryNode(string name, string path)
    {
        Name = name;
        Path = path;
    }

    public string Name { get; }

    public string Path { get; }

    public IEnumerable<IFileSystemNode> GetChildren()
    {
        foreach (string dir in Directory.GetDirectories(Path))
            yield return new DirectoryNode(System.IO.Path.GetFileName(dir), dir);

        foreach (string file in Directory.GetFiles(Path))
            yield return new FileNode(System.IO.Path.GetFileName(file));
    }

    public void Accept(IFileSystemTreeVisitor visitor)
    {
        visitor.Visit(this);
    }
}