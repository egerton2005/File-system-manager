namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.NodeVisitors;

public interface IFileSystemNode
{
    string Name { get; }

    void Accept(IFileSystemTreeVisitor visitor, int depth);
}