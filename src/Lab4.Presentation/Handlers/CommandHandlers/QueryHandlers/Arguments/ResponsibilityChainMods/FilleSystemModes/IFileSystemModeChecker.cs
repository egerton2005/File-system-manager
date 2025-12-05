using Itmo.ObjectOrientedProgramming.Lab4.Core.IOSystem.FileSystemModes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Arguments.ResponsibilityChainMods.FilleSystemModes;

public interface IFileSystemModeChecker
{
    IFileSystemMode? Apply(string name);
}