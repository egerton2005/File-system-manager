namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.NodeVisitors;

public class LocalFileNode : IFileSystemNode
{
    public LocalFileNode(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public void Accept(IFileSystemTreeVisitor visitor, int depth)
    {
        visitor.Visit(this, depth);
    }
}