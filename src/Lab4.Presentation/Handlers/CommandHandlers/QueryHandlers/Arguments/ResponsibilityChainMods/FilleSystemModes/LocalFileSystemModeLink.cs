using Itmo.ObjectOrientedProgramming.Lab4.Core.IOSystem.FileSystemModes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Arguments.ResponsibilityChainMods.FilleSystemModes;

public class LocalFileSystemModeLink : FileSystemModeLinkBase
{
    private const string Name = "local";

    public override IFileSystemMode? Apply(string name)
    {
        if (name == Name)
            return new LocalFileSystemMode();
        return CallNext(name);
    }
}