using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.IOSystem.FileShowModes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.Arguments;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Arguments.ResponsibilityChainMods.ShowModes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Arguments;

public class ShowModeArgument : IFlagArgument<FileShowCommandBuilder>
{
    public string Name => "-m";

    private readonly IShowModeChecker _modeDefiner;

    public ShowModeArgument(IShowModeChecker modeDefiner)
    {
        _modeDefiner = modeDefiner;
    }

    public FileShowCommandBuilder Handle(IEnumerator<string> arguments, FileShowCommandBuilder builder)
    {
        if (arguments.MoveNext())
        {
            IFileShowMode? mode = _modeDefiner.Apply(arguments.Current);
            if (mode is not null)
                return builder.WithMode(mode);
        }

        return builder;
    }
}