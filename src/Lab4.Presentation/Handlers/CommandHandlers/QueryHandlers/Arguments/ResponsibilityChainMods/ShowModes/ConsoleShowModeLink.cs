using Itmo.ObjectOrientedProgramming.Lab4.Core.IOSystem.FileShowModes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Arguments.ResponsibilityChainMods.ShowModes;

public class ConsoleShowModeLink : ShowModeLinkBase
{
    private const string Name = "console";

    public override IFileShowMode? Apply(string name)
    {
        if (name == Name)
            return new ConsoleFileShowMode();
        return CallNext(name);
    }
}