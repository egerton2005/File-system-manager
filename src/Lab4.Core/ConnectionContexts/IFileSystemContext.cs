using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.CommandResults;
using Itmo.ObjectOrientedProgramming.Lab4.Core.IOSystem.FileShowModes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.IOSystem.FileSystemModes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.ConnectionContexts;

public interface IFileSystemContext
{
    ICommandResult Connect(string destinationPath, IFileSystemMode fsMode);

    ICommandResult Disconnect();

    ICommandResult FileMove(string source, string destination);

    ICommandResult FileDelete(string path);

    ICommandResult FileShow(string path, IFileShowMode fsMode);

    ICommandResult FileCopy(string source, string destination);

    ICommandResult FileRename(string path, string name);

    ICommandResult TreeList(int depth);

    ICommandResult TreeGoTo(string path);
}