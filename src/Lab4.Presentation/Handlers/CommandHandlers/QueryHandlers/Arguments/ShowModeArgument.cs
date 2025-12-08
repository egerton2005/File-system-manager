using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.IOSystem.FileShowModes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Arguments.ResponsibilityChainMods.ShowModes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Arguments;

public class ShowModeArgument : SubCommandArgumentHandlerBase<FileShowCommandBuilder>
{
    public string Name => "-m";

    private readonly IShowModeChecker _modeDefiner;

    public ShowModeArgument(IShowModeChecker modeDefiner)
    {
        _modeDefiner = modeDefiner;
    }

    public override FileShowCommandBuilder Handle(IEnumerator<string> iterator, FileShowCommandBuilder builder)
    {
        var remainingArguments = new List<string>();
        do
        {
            if (iterator.Current != Name)
            {
                remainingArguments.Add(iterator.Current);
                continue;
            }

            if (!iterator.MoveNext())
                return Next is null ? builder : Next.Handle(remainingArguments.GetEnumerator(), builder);

            IFileShowMode? mode = _modeDefiner.Apply(iterator.Current);
            if (mode is not null)
                builder.WithMode(mode);
        }
        while (iterator.MoveNext());

        return Next is null ? builder : Next.Handle(remainingArguments.GetEnumerator(), builder);
    }
}