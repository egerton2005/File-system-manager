namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Arguments.ResponsibilityChainMods.FilleSystemModes;

public interface IFileSystemModeLink : IFileSystemModeChecker
{
    IFileSystemModeLink AddNext(IFileSystemModeLink link);
}