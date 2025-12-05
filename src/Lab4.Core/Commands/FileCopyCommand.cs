using Itmo.ObjectOrientedProgramming.Lab4.Core.ConnectionContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.CommandResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class FileCopyCommand : ICommand
{
    public string SourcePath { get; }

    public string DestinationPath { get; }

    public FileCopyCommand(string source, string destination)
    {
        SourcePath = source;
        DestinationPath = destination;
    }

    public CommandResult Execute(IFileSystemContext fs)
    {
        return fs.FileCopy(SourcePath, DestinationPath);
    }
}
