using Itmo.ObjectOrientedProgramming.Lab4.Core.ConnectionContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.CommandResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class FileMoveCommand : ICommand
{
    public string SourcePath { get; }

    public string DestinationPath { get; }

    public FileMoveCommand(string source, string destination)
    {
        SourcePath = source;
        DestinationPath = destination;
    }

    public ICommandResult Execute(IFileSystemContext fs)
    {
        return fs.FileMove(SourcePath, DestinationPath);
    }
}