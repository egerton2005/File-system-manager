namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.NodeVisitors;

public interface IFileSystemTreeVisitor
{
    void Visit(FileNode localFileNode);

    void Visit(DirectoryNode node);
}