using Itmo.ObjectOrientedProgramming.Lab4.Core.Formatters;
using Itmo.ObjectOrientedProgramming.Lab4.Core.IOSystem.Outputs;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.NodeVisitors;

public class LocalFileSystemTreeVisitor : IFileSystemTreeVisitor
{
    private readonly IFileFormatter _formatter;
    private readonly IOutput _output;
    private readonly int _maxDepth;
    private int _currentDepth;

    public LocalFileSystemTreeVisitor(int maxDepth, IFileFormatter formatter, IOutput output)
    {
        _maxDepth = maxDepth;
        _formatter = formatter;
        _output = output;
        _currentDepth = 0;
    }

    public void Visit(FileNode localFileNode)
    {
        WriteNode(_formatter.FormatFile(localFileNode.Name, _currentDepth));
    }

    public void Visit(DirectoryNode node)
    {
        WriteNode(_formatter.FormatDirectory(node.Name, _currentDepth));

        if (_currentDepth >= _maxDepth) return;

        _currentDepth += 1;
        foreach (IFileSystemNode element in node.GetChildren())
        {
            element.Accept(this);
        }

        _currentDepth -= 1;
    }

    public void WriteNode(string node)
    {
        _output.WriteLine(node);
    }
}