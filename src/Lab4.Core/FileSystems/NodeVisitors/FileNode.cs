namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.NodeVisitors;

public class FileNode : IFileSystemNode
{
    public FileNode(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public void Accept(IFileSystemTreeVisitor visitor)
    {
        visitor.Visit(this);
    }
}