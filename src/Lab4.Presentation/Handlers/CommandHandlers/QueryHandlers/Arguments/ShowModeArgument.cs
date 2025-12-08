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
        if (iterator.Current != Name)
            return Next is null ? builder : Next.Handle(iterator, builder);

        if (!iterator.MoveNext())
            return builder;

        IFileShowMode? mode = _modeDefiner.Apply(iterator.Current);
        if (mode is not null)
            builder.WithMode(mode);
        if (iterator.MoveNext() && Next is not null) return Next.Handle(iterator, builder);

        return builder;
    }
}