namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Arguments.ResponsibilityChainMods.ShowModes;

public class DefaultShowModeCheckerFactory : IShowModeCheckerFactory
{
    public IShowModeChecker Create()
    {
        return new ConsoleShowModeLink();
    }
}