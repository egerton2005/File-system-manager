namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Arguments.ResponsibilityChainMods.FilleSystemModes;

public class DefaultFileSystemModeCheckerFactory : IFileSystemModeCheckerFactory
{
    public IFileSystemModeChecker Create()
    {
        return new LocalFileSystemModeLink();
    }
}