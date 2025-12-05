using Itmo.ObjectOrientedProgramming.Lab4.Core.Formatters;
using Itmo.ObjectOrientedProgramming.Lab4.Core.IOSystem.Outputs;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.NodeVisitors;

public class FileSystemTreeVisitor : IFileSystemTreeVisitor
{
    private readonly FileFormatter _formatter;
    private readonly IOutput _output;
    private readonly int _maxDepth;

    public FileSystemTreeVisitor(int maxDepth, FileFormatter formatter, IOutput output)
    {
        _maxDepth = maxDepth;
        _formatter = formatter;
        _output = output;
    }

    public void Visit(LocalFileNode node, int depth)
    {
        WriteNode(_formatter.FormatFile(node.Name, depth, _maxDepth));
    }

    public void Visit(LocalDirectoryNode node, int depth)
    {
        WriteNode(_formatter.FormatDirectory(node.Name, depth, _maxDepth));

        if (depth >= _maxDepth) return;

        foreach (IFileSystemNode element in node.GetChildren())
        {
            element.Accept(this, depth + 1);
        }
    }

    public void WriteNode(string node)
    {
        _output.WriteLine(node);
    }
}