using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.CommandResults;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.ResultType;
using Itmo.ObjectOrientedProgramming.Lab4.Core.IOSystem.FileShowModes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.IOSystem.FileSystemModes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

internal class NullFileSystem : IFileSystem
{
    private static ICommandResult FailureResult =>
        new FailureResult(new NotConnectedError().Message);

    public ICommandResult Connect(string destinationPath, IFileSystemMode? fsMode) => FailureResult;

    public ICommandResult Disconnect() => FailureResult;

    public ICommandResult FileMove(string source, string destination) => FailureResult;

    public ICommandResult FileDelete(string path) => FailureResult;

    public ICommandResult FileShow(string path, IFileShowMode? fsMode) => FailureResult;

    public ICommandResult FileCopy(string source, string destination) => FailureResult;

    public ICommandResult FileRename(string path, string name) => FailureResult;

    public ICommandResult TreeList(int depth) => FailureResult;

    public ICommandResult TreeGoTo(string path) => FailureResult;
}