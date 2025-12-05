using Itmo.ObjectOrientedProgramming.Lab4.Core.IOSystem.FileShowModes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Arguments.ResponsibilityChainMods.ShowModes;

public interface IShowModeChecker
{
    IFileShowMode? Apply(string name);
}