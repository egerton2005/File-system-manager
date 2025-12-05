namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Arguments.ResponsibilityChainMods.ShowModes;

public interface IShowModeLink : IShowModeChecker
{
    IShowModeLink AddNext(IShowModeLink link);
}