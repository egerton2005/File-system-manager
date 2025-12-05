namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.NodeVisitors;

public interface IFileSystemTreeVisitor
{
    void Visit(LocalFileNode node, int depth);

    void Visit(LocalDirectoryNode node, int depth);
}