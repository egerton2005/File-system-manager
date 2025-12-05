using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.CommandResults;
using Itmo.ObjectOrientedProgramming.Lab4.Core.IOSystem.FileShowModes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.IOSystem.FileSystemModes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.ConnectionContexts;

public interface IFileSystemContext
{
    CommandResult Connect(string destinationPath, IFileSystemMode fsMode);

    CommandResult Disconnect();

    CommandResult FileMove(string source, string destination);

    CommandResult FileDelete(string path);

    CommandResult FileShow(string path, IFileShowMode fsMode);

    CommandResult FileCopy(string source, string destination);

    CommandResult FileRename(string path, string name);

    CommandResult TreeList(int depth);

    CommandResult TreeGoTo(string path);
}