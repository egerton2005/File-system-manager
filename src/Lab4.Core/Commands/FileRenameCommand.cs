using Itmo.ObjectOrientedProgramming.Lab4.Core.ConnectionContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.CommandResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class FileRenameCommand : ICommand
{
    public FileRenameCommand(string path, string name)
    {
        Path = path;
        Name = name;
    }

    public string Path { get; }

    public string Name { get; }

    public CommandResult Execute(IFileSystemContext fs)
    {
        return fs.FileRename(Path, Name);
    }
}